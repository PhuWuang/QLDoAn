using System.Linq;

namespace QLBanDoAnNhanh.DAL.Repositories
{
    public class ProductRepository
    {
        private readonly PosFastFoodsDataContext _db;
        public ProductRepository(PosFastFoodsDataContext db) => _db = db;

        public IQueryable<Product> GetByTypeId(int typeId) =>
            _db.Products.Where(p => p.IdTypeProduct == typeId && p.IsActive);

        public IQueryable<Product> SearchByName(string keyword) =>
            _db.Products.Where(p => p.IsActive && p.NameProduct.Contains(keyword));

        public Product GetById(int id) =>
            _db.Products.SingleOrDefault(p => p.IdProduct == id);

        public void Insert(Product p) => _db.Products.InsertOnSubmit(p);

        public void Update(Product pExisting, Product pNew)
        {
            // Khung tối thiểu: gán các cột cho phép sửa
            pExisting.NameProduct = pNew.NameProduct;
            pExisting.PriceProduct = pNew.PriceProduct;
            pExisting.Descriptions = pNew.Descriptions;
            pExisting.Images = pNew.Images;        // ảnh có thể null nếu không đổi
            pExisting.IdTypeProduct = pNew.IdTypeProduct;
            // IsActive không đổi ở đây (tùy nghiệp vụ)
        }

        /// <summary>
        /// Xóa an toàn: nếu Product đã xuất hiện trong OrderDetail → ẩn (IsActive=false), ngược lại xóa cứng.
        /// </summary>
        public string SafeDelete(int id)
        {
            var p = _db.Products.SingleOrDefault(x => x.IdProduct == id);
            if (p == null) return "NotFound";
            bool hasUsed = _db.OrderDetails.Any(od => od.ProductId == id);
            if (hasUsed) { p.IsActive = false; return "Deactivated"; }
            _db.Products.DeleteOnSubmit(p); return "Deleted";
        }
        public IQueryable<Product> GetAllActive() =>
            _db.Products.Where(p => p.IsActive);
    }
}
