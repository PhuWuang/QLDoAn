using System.Collections.Generic;
using System.Linq;
using QLBanDoAnNhanh.BLL.DTOs;
using QLBanDoAnNhanh.BLL.Mappers;
using QLBanDoAnNhanh.DAL;
using QLBanDoAnNhanh.DAL.Repositories;

namespace QLBanDoAnNhanh.BLL
{
    // Đổi namespace thành .Services nếu bạn muốn tổ chức trong thư mục Services
    public class TypeProductService
    {
        public List<TypeProductDto> GetActiveTypesOrdered()
        {
            using (var uow = new UnitOfWork(DataContextFactory.Create()))
            {
                return uow.Types.GetAllActiveOrdered()
                          .Select(t => t.ToDto())
                          .ToList();
            }
        }

        // Thêm các hàm CRUD cho danh mục sau (khi làm form Category)
    }
}