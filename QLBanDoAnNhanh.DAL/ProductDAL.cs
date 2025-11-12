using QLBanDoAnNhanh.DAL.Models;
using QLBanDoAnNhanh.Models;
using System.Collections.Generic;
using System.Linq;

namespace QLBanDoAnNhanh.DAL
{
    public class ProductDAL
    {
        private PosFastFood _context;

        public ProductDAL()
        {
            _context = new PosFastFood();
        }

        // Hàm này lấy tất cả sản phẩm thuộc một loại nhất định
        public List<Product> GetByTypeId(int typeId)
        {
            return _context.Products.Where(p => p.IdTypeProduct == typeId).ToList();
        }

        // Hàm này tìm sản phẩm theo tên (không phân biệt hoa thường) và theo loại
        public List<Product> SearchByNameAndTypeId(string name, int typeId)
        {
            // THAY ĐỔI DUY NHẤT NẰM Ở ĐÂY: Dùng .Contains() thay vì ==
            return _context.Products
                           .Where(p => p.IdTypeProduct == typeId && p.NameProduct.ToLower().Contains(name.ToLower()))
                           .ToList();
        }
        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }
        // HÀM MỚI: Thêm một sản phẩm mới vào CSDL
        public bool CreateProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChanges() > 0;
        }

        // HÀM MỚI: Kiểm tra xem tên sản phẩm đã tồn tại chưa (không phân biệt hoa thường)
        public bool ProductExists(string name)
        {
            return _context.Products.Any(p => p.NameProduct.ToLower() == name.ToLower());
        }
        // HÀM MỚI: Cập nhật thông tin một sản phẩm đã có
        public bool UpdateProduct(Product product)
        {
            // Đánh dấu đối tượng là đã bị thay đổi
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            return _context.SaveChanges() > 0;
        }

        // HÀM MỚI (Overload): Kiểm tra tên sản phẩm tồn tại, ngoại trừ chính nó
        public bool ProductExists(string name, int currentProductId)
        {
            // Tìm bất kỳ sản phẩm nào có tên trùng, nhưng ID phải khác với ID sản phẩm đang sửa
            return _context.Products.Any(p => p.NameProduct.ToLower() == name.ToLower() && p.IdProduct != currentProductId);
        }
        // HÀM MỚI: Kiểm tra xem sản phẩm có nằm trong bất kỳ chi tiết hóa đơn nào không
        public bool IsProductInAnyOrder(int productId)
        {
            return _context.OrderDetails.Any(od => od.IdProduct == productId);
        }

        // HÀM MỚI: Xóa vĩnh viễn một sản phẩm khỏi CSDL
        public bool DeleteProductById(int productId)
        {
            var product = _context.Products.Find(productId);
            if (product == null) return false;

            _context.Products.Remove(product);
            return _context.SaveChanges() > 0;
        }
        // HÀM MỚI BỔ SUNG: Lấy tất cả danh sách loại sản phẩm
        public List<TypeProduct> GetAllTypes()
        {
            return _context.TypeProducts.ToList();
        }
    }
}