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
    }
}