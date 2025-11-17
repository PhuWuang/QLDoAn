using System;
using System.Collections.Generic;
using System.Linq;
using QLBanDoAnNhanh.BLL.DTOs;
using QLBanDoAnNhanh.BLL.Mappers;
using QLBanDoAnNhanh.DAL;
using QLBanDoAnNhanh.DAL.Repositories;

namespace QLBanDoAnNhanh.BLL
{
    // Đổi namespace thành .Services nếu bạn muốn
    public class OrderService
    {
        // 1. Dùng cho frmMain (Thanh toán)
        // Dán code này để THAY THẾ hàm CreateOrder cũ

        public OrderDto CreateOrder(int employeeId, Dictionary<int, (int qty, decimal price)> items)
        {
            var lines = items.Select(item => (
                productId: item.Key,
                qty: item.Value.qty,
                unitPrice: item.Value.price
            )).ToList();

            if (!lines.Any())
            {
                throw new Exception("Không thể tạo đơn hàng rỗng.");
            }

            int newOrderId = 0; // <-- SỬA 1: Khai báo ID ở ngoài

            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                var dalOrder = uow.Orders.CreateOrder(employeeId, lines);
                uow.Commit();
                newOrderId = dalOrder.IdOrder; // <-- SỬA 2: Gán ID vào biến ngoài
            }

            // Lấy lại đầy đủ thông tin (kèm chi tiết) để trả về UI
            using (var uow2 = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                // SỬA 3: Dùng newOrderId
                var newOrder = uow2.Orders.GetByIdWithDetails(newOrderId);
                return newOrder.ToDto();
            }
        }

        // 2. Dùng cho frmInvoiceDetail
        public OrderDto GetOrderById(int orderId)
        {
            using (var uow = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                var dalOrder = uow.Orders.GetByIdWithDetails(orderId);
                return dalOrder.ToDto();
            }
        }

        // 3. Dùng cho frmStatistics
        public decimal GetTotalRevenueByDateRange(DateTime from, DateTime to)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                var toDate = to.Date.AddDays(1);
                return uow.Orders.QueryByDateRange(from.Date, toDate)
                                 .Sum(o => (decimal?)o.Total) ?? 0m;
            }
        }
        // 3b. Dùng cho frmStatistics - doanh thu theo loại sản phẩm (Pie chart)
        public Dictionary<string, decimal> GetRevenueByTypeProduct(DateTime from, DateTime to)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                var toDate = to.Date.AddDays(1);

                // Lấy tất cả OrderDetail trong khoảng ngày
                var query = uow.Orders
                    .QueryByDateRange(from.Date, toDate)
                    .SelectMany(o => o.OrderDetails)
                    .Where(d => d.Product != null && d.Product.TypeProduct != null);

                // Nhóm theo tên loại sản phẩm và tính tổng tiền = Qty * UnitPrice
                var grouped = query
                    .GroupBy(d => d.Product.TypeProduct.NameType)
                    .Select(g => new
                    {
                        TypeName = g.Key,
                        Total = g.Sum(d => (decimal?)(d.Quantity * d.UnitPrice)) ?? 0m
                    })
                    .ToList();

                // Trả về dạng Dictionary: [Tên loại] -> Tổng doanh thu
                return grouped.ToDictionary(x => x.TypeName, x => x.Total);
            }
        }
        public Dictionary<int, decimal> GetMonthlyRevenue(int year, int fromMonth, int toMonth)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                // Giới hạn from/to hợp lệ
                if (fromMonth < 1) fromMonth = 1;
                if (toMonth > 12) toMonth = 12;
                if (fromMonth > toMonth)
                {
                    // Đơn giản: đảo lại, hoặc bạn có thể ném exception
                    int tmp = fromMonth;
                    fromMonth = toMonth;
                    toMonth = tmp;
                }

                // Tính khoảng ngày [fromDate, toDate)
                var fromDate = new DateTime(year, fromMonth, 1);
                var toDate = new DateTime(year, toMonth, 1).AddMonths(1); // đầu tháng sau

                var query = uow.Orders
                    .QueryByDateRange(fromDate, toDate);

                var grouped = query
                    .GroupBy(o => o.CreateDate.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        Total = g.Sum(o => (decimal?)(o.Total)) ?? 0m
                    })
                    .ToList();

                // Dictionary: [tháng] -> tổng doanh thu tháng đó
                return grouped.ToDictionary(x => x.Month, x => x.Total);
            }
        }


        // 4. Dùng cho frmInvoiceList (Search)
        public List<OrderDto> SearchOrders(int? orderId, DateTime from, DateTime to)
        {
            using (var uow = new UnitOfWork(DataContextFactory.CreateWithIncludes()))
            {
                var toDate = to.Date.AddDays(1);
                var query = uow.Orders.QueryByDateRange(from.Date, toDate);

                if (orderId.HasValue)
                {
                    query = query.Where(o => o.IdOrder == orderId.Value);
                }

                return query.OrderByDescending(o => o.CreateDate)
                            .Select(o => o.ToDto())
                            .ToList();
            }
        }

        // 5. Dùng cho frmInvoiceList (Load)
        public List<OrderDto> GetAllOrders()
        {
            return SearchOrders(null, DateTime.MinValue, DateTime.MaxValue);
        }
        /// <summary>
        /// Lấy danh sách hóa đơn theo khoảng ngày [from, to)
        /// (to là exclusive để lấy hết ngày: truyền vào dtpTo.Date.AddDays(1))
        /// </summary>
        public List<InvoiceReportDto> GetInvoicesByDateRange(
            DateTime from, DateTime to,
            int? employeeId = null,      // tuỳ chọn lọc theo nhân viên
            string keyword = null        // tuỳ chọn: lọc theo IdOrder/EmployeeName
        )
        {
            using (var db = DataContextFactory.CreateWithIncludes())
            {
                var q = db.Orders
                    .Where(o => o.CreateDate >= from && o.CreateDate < to);

                if (employeeId.HasValue)
                    q = q.Where(o => o.EmployeeId == employeeId.Value);

                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    var kw = keyword.Trim();
                    q = q.Where(o =>
                        // nếu IdOrder là số, có thể parse và so sánh
                        o.IdOrder.ToString().Contains(kw)
                        || (o.Employee != null && o.Employee.NameEmployee.Contains(kw))
                    );
                }

                var result = q
                    .Select(o => new InvoiceReportDto
                    {
                        IdOrder = o.IdOrder,
                        CreatedAt = o.CreateDate,
                        EmployeeName = o.Employee != null ? o.Employee.NameEmployee : "",
                        // Tổng tiền theo chi tiết
                        TotalAmount = o.OrderDetails.Sum(d => (decimal?)(d.Quantity * d.UnitPrice)) ?? 0m
                    })
                    .OrderBy(x => x.CreatedAt)
                    .ToList();

                return result;
            }
        }
        public List<TopProductReportItem> GetTopProducts(DateTime from, DateTime to, int topN)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                if (topN <= 0) topN = 10;

                var toDate = to.Date.AddDays(1);

                // Lấy tất cả OrderDetail trong khoảng ngày
                var query = uow.Orders
                    .QueryByDateRange(from.Date, toDate)
                    .SelectMany(o => o.OrderDetails)
                    .Where(d => d.Product != null && d.Product.TypeProduct != null);

                // Nhóm theo món, tính Quantity & TotalRevenue
                var grouped = query
                    .GroupBy(d => new
                    {
                        d.Product.NameProduct,
                        d.Product.TypeProduct.NameType
                    })
                    .Select(g => new TopProductReportItem
                    {
                        ProductName = g.Key.NameProduct,
                        TypeName = g.Key.NameType,
                        Quantity = g.Sum(x => x.Quantity),
                        TotalRevenue = g.Sum(x => (decimal?)(x.Quantity * x.UnitPrice)) ?? 0m
                    })
                    .OrderByDescending(x => x.Quantity)
                    .ThenByDescending(x => x.TotalRevenue)
                    .Take(topN)
                    .ToList();

                return grouped;
            }
        }

    }
}