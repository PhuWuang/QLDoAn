using System;

namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class InvoiceReportDto
    {
        public int IdOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public string EmployeeName { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class InvoiceLineItem
    {
        public string Item { get; set; }
        public int Qty { get; set; } // Dùng int cho số lượng
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
    }
}
