using System;
using System.Collections.Generic;

namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class OrderDto
    {
        public int IdOrder { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public decimal Total { get; set; }
        public List<OrderLineDto> Lines { get; set; } // <-- SỬA 1 (Xóa)

        // THÊM 2 (Thêm constructor)
        public OrderDto()
        {
            Lines = new List<OrderLineDto>();
        }
    }
}