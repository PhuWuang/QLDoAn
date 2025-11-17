using System;

namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class TopProductReportItem
    {
        public string ProductName { get; set; }
        public string TypeName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
