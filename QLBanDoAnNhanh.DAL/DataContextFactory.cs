using System.Configuration;
using System.Data.Linq; // <-- CẦN THÊM DÒNG NÀY

namespace QLBanDoAnNhanh.DAL
{
    public static class DataContextFactory
    {
        public static PosFastFoodsDataContext Create()
        {
            var cs = ConfigurationManager.ConnectionStrings["PosFastFoodsV2"].ConnectionString;
            var db = new PosFastFoodsDataContext(cs);
            db.CommandTimeout = 30;
            return db;
        }

        // HÀM BỊ THIẾU CỦA BẠN LÀ ĐÂY
        public static PosFastFoodsDataContext CreateWithIncludes()
        {
            var db = Create();
            var lo = new DataLoadOptions();

            // Cấu hình LINQ tự động "Include" các bảng liên quan
            lo.LoadWith<Order>(o => o.OrderDetails);
            lo.LoadWith<OrderDetail>(d => d.Product);
            lo.LoadWith<Employee>(e => e.Role); // Load Role khi lấy Employee

            db.LoadOptions = lo;
            return db;
        }
    }
}