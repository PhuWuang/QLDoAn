using System.Linq;
using QLBanDoAnNhanh.BLL.DTOs;
using QLBanDoAnNhanh.DAL; // để nhìn thấy DAL entities

namespace QLBanDoAnNhanh.BLL.Mappers
{
    public static class DalToDtoMapper
    {
        public static ProductDto ToDto(this Product e) => e == null ? null : new ProductDto
        {
            IdProduct = e.IdProduct,
            NameProduct = e.NameProduct,
            PriceProduct = e.PriceProduct,
            Descriptions = e.Descriptions,
            Images = e.Images?.ToArray(),
            IdTypeProduct = e.IdTypeProduct,
            IsActive = e.IsActive
        };

        public static TypeProductDto ToDto(this TypeProduct e) => e == null ? null : new TypeProductDto
        {
            IdTypeProduct = e.IdTypeProduct,
            NameType = e.NameType,
            IsActive = e.IsActive,
            DisplayOrder = e.DisplayOrder
        };

        public static EmployeeDto ToDto(this Employee e) => e == null ? null : new EmployeeDto
        {
            IdEmployee = e.IdEmployee,
            NameEmployee = e.NameEmployee,
            Email = e.Email,
            RoleId = e.IdRole,
            RoleName = e.Role?.NameRole,
            IsActive = e.IsActive
        };

        public static OrderDto ToDto(this Order o) => o == null ? null : new OrderDto
        {
            IdOrder = o.IdOrder,
            EmployeeId = o.EmployeeId,
            CreateDate = o.CreateDate,
            Total = o.Total,
            Lines = o.OrderDetails.Select(d => new OrderLineDto
            {
                ProductId = d.ProductId,
                ProductName = d.Product?.NameProduct,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice
            }).ToList()
        };
    }
}
