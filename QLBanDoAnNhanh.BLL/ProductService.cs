using QLBanDoAnNhanh.DAL;
using QLBanDoAnNhanh.DAL.Models;
using QLBanDoAnNhanh.Models;
using System.Collections.Generic;

namespace QLBanDoAnNhanh.BLL
{
    public class ProductService
    {
        private ProductDAL _productDAL;

        public ProductService()
        {
            _productDAL = new ProductDAL();
        }

        // Hàm này gọi xuống DAL để lấy danh sách sản phẩm
        public List<Product> GetByTypeId(int typeId)
        {
            return _productDAL.GetByTypeId(typeId);
        }

        // HÀM MỚI: Gọi xuống DAL để thực hiện tìm kiếm
        public List<Product> SearchByNameAndTypeId(string name, int typeId)
        {
            return _productDAL.SearchByNameAndTypeId(name, typeId);
        }
        // HÀM MỚI: Xử lý nghiệp vụ thêm sản phẩm
        public bool CreateProduct(Product product)
        {
            // Logic nghiệp vụ: không cho phép thêm sản phẩm có tên đã tồn tại
            if (_productDAL.ProductExists(product.NameProduct))
            {
                // Trả về false nếu tên đã tồn tại
                return false;
            }

            // Nếu tên hợp lệ, gọi xuống DAL để lưu
            return _productDAL.CreateProduct(product);
        }
        // HÀM MỚI: Xử lý nghiệp vụ cập nhật sản phẩm
        public bool UpdateProduct(Product product)
        {
            // Logic nghiệp vụ: không cho phép đổi tên thành một sản phẩm khác đã tồn tại
            if (_productDAL.ProductExists(product.NameProduct, product.IdProduct))
            {
                return false; // Trả về false nếu tên đã tồn tại ở một sản phẩm khác
            }

            // Nếu tên hợp lệ, gọi xuống DAL để cập nhật
            return _productDAL.UpdateProduct(product);
        }
        // HÀM BỔ SUNG: Lấy thông tin chi tiết một sản phẩm theo ID
        public Product GetById(int id)
        {
            return _productDAL.GetById(id);
        }
        // HÀM MỚI: Xử lý nghiệp vụ xóa hoặc ẩn sản phẩm
        // Trả về chuỗi để báo cho UI biết hành động nào đã được thực hiện
        public string DeleteProduct(int productId)
        {
            // Lấy thông tin sản phẩm
            var product = _productDAL.GetById(productId);
            if (product == null)
            {
                return "NotFound"; // Sản phẩm không tồn tại
            }

            // Logic nghiệp vụ cốt lõi:
            // Kiểm tra xem sản phẩm có trong hóa đơn nào không
            if (_productDAL.IsProductInAnyOrder(productId))
            {
                // Nếu có, chỉ ẩn đi (chuyển IsActive = false)
                product.IsActive = false;
                if (_productDAL.UpdateProduct(product))
                {
                    return "Deactivated"; // Báo là đã ẩn
                }
            }
            else
            {
                // Nếu không, xóa vĩnh viễn
                if (_productDAL.DeleteProductById(productId))
                {
                    return "Deleted"; // Báo là đã xóa
                }
            }

            return "Error"; // Nếu có lỗi xảy ra
        }
        // HÀM MỚI BỔ SUNG: Gọi DAL để lấy tất cả loại sản phẩm
        public List<TypeProduct> GetAllTypes()
        {
            return _productDAL.GetAllTypes();
        }
    }
}