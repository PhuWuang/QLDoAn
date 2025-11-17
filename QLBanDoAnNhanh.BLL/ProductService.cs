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
    public class ProductService
    {
        // 1. Dùng cho frmMain
        public List<ProductDto> GetByTypeId(int typeId)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create())) // Thêm ngoặc ()
            { // Thêm ngoặc {
                return uow.Products.GetByTypeId(typeId).Select(p => p.ToDto()).ToList();
            } // Thêm ngoặc }
        }

        // 2. Dùng cho frmItemDetail, frmEditItem
        public ProductDto GetById(int id)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
                return uow.Products.GetById(id).ToDto();
        }

        // 3. Dùng cho frmMain (khi load "Tất cả")
        public List<ProductDto> GetAllActiveProducts()
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create())) { 
                // (Bạn cần đảm bảo đã thêm hàm GetAllActive() vào ProductRepository.cs)
                var query = uow.Products.GetAllActive();
                return query.Select(p => p.ToDto()).ToList();
            }
        }

        // 4. Dùng cho frmAddItem
        public bool CreateProduct(ProductDto dto)
        {
            try
            {
                using (var uow = new UnitOfWork(DataContextFactory.Create()))
                {

                    // Map DTO -> DAL Entity
                    var dalProduct = new Product
                    {
                        NameProduct = dto.NameProduct,
                        PriceProduct = dto.PriceProduct,
                        Descriptions = dto.Descriptions,
                        Images = dto.Images,
                        IdTypeProduct = dto.IdTypeProduct,
                        CreatedBy = dto.CreatedBy, // Cần truyền IdEmployee từ UI
                        IsActive = true,
                        CreatedAt = DateTime.Today,
                    };

                    uow.Products.Insert(dalProduct);
                    uow.Commit();
                    return true;
                }
            }
            catch { return false; }
        }

        // 5. Dùng cho frmEditItem
        public bool UpdateProduct(ProductDto dto)
        {
            try
            {
                using (var uow = new UnitOfWork(DataContextFactory.Create()))
                {

                    var pExisting = uow.Products.GetById(dto.IdProduct);
                    if (pExisting == null) return false;

                    // Map DTO -> DAL Entity (Dùng hàm Update của Repo)
                    var pNew = new Product
                    {
                        NameProduct = dto.NameProduct,
                        PriceProduct = dto.PriceProduct,
                        Descriptions = dto.Descriptions,
                        Images = dto.Images,
                        IdTypeProduct = dto.IdTypeProduct
                    };

                    uow.Products.Update(pExisting, pNew);
                    uow.Commit();
                    return true;
                }
            }
            catch { return false; }
        }

        // 6. Dùng cho frmItemDetail (Sold Out)
        public bool ToggleActive(int id)
        {
            try
            {
                using (var uow = new UnitOfWork(DataContextFactory.Create()))
                {
                    var p = uow.Products.GetById(id);
                    if (p == null) return false;

                    p.IsActive = !p.IsActive; // Đảo ngược trạng thái
                    uow.Commit();
                    return true;
                }
            }
            catch { return false; }
        }

        // 7. Dùng cho frmItemDetail (Delete)
        public string DeleteProduct(int id)
        {
            try
            {
                using (var uow = new UnitOfWork(DataContextFactory.Create()))
                {
                    string result = uow.Products.SafeDelete(id);
                    uow.Commit();
                    return result; // "Deleted", "Deactivated", "NotFound"
                }
            }
            catch { return "Error"; }
        }

        // 8. Dùng cho frmMain (Search)
        public List<ProductDto> SearchByNameAndTypeId(string keyword, int typeId)
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                var query = uow.Products.SearchByName(keyword);
                if (typeId > 0)
                {
                    query = query.Where(p => p.IdTypeProduct == typeId);
                }
                return query.Select(p => p.ToDto()).ToList();
            }
        }
    }
}