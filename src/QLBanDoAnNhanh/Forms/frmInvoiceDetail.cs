using System;
using System.Globalization; // <-- THÊM
using System.Linq;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL; // <-- THÊM
using QLBanDoAnNhanh.BLL.DTOs; // <-- THÊM

namespace QLBanDoAnNhanh
{
    public partial class frmInvoiceDetail : Form
    {
        private int _orderId; // Biến để lưu ID
        private CultureInfo _culture = new CultureInfo("vi-VN"); // Dùng chung

        // Xóa hàm public frmInvoiceDetail() (không tham số)
        // Form này bắt buộc phải có orderId

        public frmInvoiceDetail(int orderId)
        {
            InitializeComponent();
            _orderId = orderId; // Gán ID nhận được vào biến
        }

        private void frmInvoiceDetail_Load(object sender, EventArgs e)
        {
            var orderService = new QLBanDoAnNhanh.BLL.OrderService();
            // 1. SỬA: Nhận về OrderDto
            var orderDto = orderService.GetOrderById(_orderId);

            if (orderDto == null)
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn.");
                this.Close();
                return;
            }

            // 2. Hiển thị thông tin chung (dùng DTO)
            lbMaHD.Text = orderDto.IdOrder.ToString();
            lbNgayTao.Text = orderDto.CreateDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm"); // Bỏ '?'

            // SỬA: DTO của bạn chỉ có EmployeeId (xem ghi chú bên dưới)
            lbNhanVien.Text = orderDto.EmployeeId.ToString();

            lbTongTien.Text = orderDto.Total.ToString("N0", _culture) + " VNĐ"; // Bỏ '?' và sửa tiền tệ

            // 3. Hiển thị danh sách món ăn (dùng DTO.Lines)
            var detailsData = orderDto.Lines.Select(d => new {
                TenMon = d.ProductName, // Sửa thuộc tính
                SoLuong = d.Quantity, // Sửa thuộc tính
                DonGia = d.UnitPrice.ToString("N0", _culture), // Sửa: Lấy giá lúc bán
                ThanhTien = d.LineTotal.ToString("N0", _culture) // Sửa: Lấy tổng lúc bán
            }).ToList();

            dgvOrderDetails.DataSource = detailsData;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}