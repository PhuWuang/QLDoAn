namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class OrderLineDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } // tiện hiển thị
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }
}
