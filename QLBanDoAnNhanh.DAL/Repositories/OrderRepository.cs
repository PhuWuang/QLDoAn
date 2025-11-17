using System;
using System.Collections.Generic;
using System.Linq;

namespace QLBanDoAnNhanh.DAL.Repositories
{
    public class OrderRepository
    {
        private readonly PosFastFoodsDataContext _db;
        public OrderRepository(PosFastFoodsDataContext db) => _db = db;

        public Order GetByIdWithDetails(int id) =>
            _db.Orders.SingleOrDefault(o => o.IdOrder == id); // nếu đã set LoadOptions (OrderDetails, Product) tại DataContextFactory

        public IQueryable<Order> QueryByDateRange(DateTime fromUtc, DateTime toUtc) =>
            _db.Orders.Where(o => o.CreateDate >= fromUtc && o.CreateDate < toUtc);

        /// <summary>Tạo đơn + chi tiết trong một SubmitChanges()</summary>
        public Order CreateOrder(int employeeId, IEnumerable<(int productId, int qty, decimal unitPrice)> lines)
        {
            var order = new Order
            {
                EmployeeId = employeeId,
                CreateDate = DateTime.Today,
                Total = 0m
            };
            _db.Orders.InsertOnSubmit(order);

            decimal total = 0m;
            foreach (var ln in lines)
            {
                var d = new OrderDetail
                {
                    Order = order,
                    IdOrder = order.IdOrder, // sẽ có sau SubmitChanges, L2S tự xử lý qua quan hệ
                    IdProduct = ln.productId,
                    Quantity = ln.qty,
                    UnitPrice = ln.unitPrice
                };
                _db.OrderDetails.InsertOnSubmit(d);
                total += ln.qty * ln.unitPrice;
            }

            order.Total = total;
            return order;
        }

        /// <summary>Hủy đơn: demo khung – xóa cứng sẽ kéo theo chi tiết vì FK CASCADE; dùng cẩn trọng.</summary>
        public void DeleteHard(int id)
        {
            var o = _db.Orders.SingleOrDefault(x => x.IdOrder == id);
            if (o != null) _db.Orders.DeleteOnSubmit(o);
        }
    }
}
