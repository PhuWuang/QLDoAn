using QLBanDoAnNhanh.DAL.Models;
using QLBanDoAnNhanh.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QLBanDoAnNhanh.DAL
{
    public class OrderDAL
    {
        private PosFastFood _context;

        public OrderDAL()
        {
            _context = new PosFastFood();
        }

        // Hàm này nhận một đối tượng Order đã được xử lý ở BLL và chỉ việc lưu nó
        public bool CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            // SaveChanges() trả về số dòng bị ảnh hưởng, > 0 là thành công
            return _context.SaveChanges() > 0;
        }
        // HÀM MỚI: Lấy tất cả các hóa đơn, kèm theo thông tin nhân viên đã tạo hóa đơn đó
        public List<Order> GetAllOrders()
        {
            // .Include("Employee") sẽ tự động join với bảng Employee
            return _context.Orders.Include("Employee").OrderByDescending(o => o.CreateDate).ToList();
        }
        // HÀM MỚI: Lấy thông tin chi tiết của một hóa đơn duy nhất
        public Order GetOrderById(int orderId)
        {
            return _context.Orders
                           .Include("Employee") // Lấy thông tin nhân viên
                           .Include("OrderDetails.Product") // Lấy chi tiết hóa đơn VÀ sản phẩm tương ứng
                           .FirstOrDefault(o => o.IdOrder == orderId);
        }
        // HÀM MỚI: Tìm kiếm hóa đơn theo nhiều tiêu chí
        public List<Order> SearchOrders(int? orderId, DateTime? startDate, DateTime? endDate)
        {
            var query = _context.Orders.Include("Employee").AsQueryable();

            // 1. Lọc theo Mã Hóa Đơn nếu có
            if (orderId.HasValue)
            {
                query = query.Where(o => o.IdOrder == orderId.Value);
            }

            // 2. Lọc theo ngày bắt đầu nếu có
            if (startDate.HasValue)
            {
                query = query.Where(o => o.CreateDate >= startDate.Value);
            }

            // 3. Lọc theo ngày kết thúc nếu có
            if (endDate.HasValue)
            {
                // Thêm 1 ngày để bao gồm tất cả hóa đơn trong ngày kết thúc
                var inclusiveEndDate = endDate.Value.Date.AddDays(1);
                query = query.Where(o => o.CreateDate < inclusiveEndDate);
            }

            return query.OrderByDescending(o => o.CreateDate).ToList();
        }
        // HÀM MỚI: Tính tổng doanh thu theo khoảng thời gian
        public decimal GetTotalRevenueByDateRange(DateTime startDate, DateTime endDate)
        {
            // Thêm 1 ngày vào ngày kết thúc để bao gồm tất cả hóa đơn trong ngày đó
            var inclusiveEndDate = endDate.Date.AddDays(1);

            // Lọc các hóa đơn trong khoảng thời gian
            var ordersInDateRange = _context.Orders
                                            .Where(o => o.CreateDate >= startDate.Date && o.CreateDate < inclusiveEndDate);

            // Nếu không có hóa đơn nào, trả về 0
            if (!ordersInDateRange.Any())
            {
                return 0;
            }

            // Tính tổng cột Total và trả về
            return ordersInDateRange.Sum(o => o.Total ?? 0);
        }
    }

}