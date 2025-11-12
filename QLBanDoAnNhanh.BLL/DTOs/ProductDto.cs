namespace QLBanDoAnNhanh.BLL.DTOs
{
    public class ProductDto
    {
        public int IdProduct { get; set; }
        public string NameProduct { get; set; }
        public decimal PriceProduct { get; set; }
        public string Descriptions { get; set; }
        public byte[] Images { get; set; }
        public int IdTypeProduct { get; set; }
        public bool IsActive { get; set; }

        public int CreatedBy { get; set; } // <-- THÊM DÒNG NÀY
    }
}