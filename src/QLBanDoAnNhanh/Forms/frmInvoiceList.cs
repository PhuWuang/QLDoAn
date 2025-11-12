using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL; // <-- THÊM
using QLBanDoAnNhanh.BLL.DTOs; // <-- THÊM
using System.Globalization; // <-- THÊM

namespace QLBanDoAnNhanh
{
    public partial class frmInvoiceList : Form
    {
        private OrderService _orderService; // <-- Tạo biến dùng chung
        private CultureInfo _culture = new CultureInfo("vi-VN"); // Dùng chung

        public frmInvoiceList()
        {
            InitializeComponent();
            _orderService = new OrderService(); // Khởi tạo 1 lần
        }

        private void frmInvoiceList_Load(object sender, EventArgs e)
        {
            // Mặc định load 30 ngày gần nhất
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
            dtpEndDate.Value = DateTime.Now;

            // Tải dữ liệu bằng hàm Search
            btnSearch_Click(sender, e);
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng không nhấn vào header
            if (e.RowIndex >= 0)
            {
                // Lấy ID của hóa đơn từ cột "ID"
                int orderId = (int)dgvInvoices.Rows[e.RowIndex].Cells["ID"].Value;

                // Tạo và hiển thị form chi tiết, truyền ID qua
                frmInvoiceDetail detailForm = new frmInvoiceDetail(orderId);
                detailForm.ShowDialog();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Chuẩn bị tham số
            int? orderId = null;
            if (!string.IsNullOrWhiteSpace(txtSearchMaHD.Text) && int.TryParse(txtSearchMaHD.Text, out int id))
            {
                orderId = id;
            }

            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            // Gọi xuống BLL (BLL trả về List<OrderDto>)
            var searchResult = _orderService.SearchOrders(orderId, startDate, endDate);

            // SỬA LỖI: Hiển thị kết quả (dùng DTO)
            var displayData = searchResult.Select(o => new {
                ID = o.IdOrder,
                Date = o.CreateDate.ToLocalTime(), // Chuyển sang giờ địa phương
                Employee = o.EmployeeId, // SỬA: Dùng EmployeeId (DTO không có Name)
                Total = o.Total.ToString("N0", _culture) + " VNĐ" // SỬA: Tiền tệ VNĐ
            }).ToList();

            dgvInvoices.DataSource = displayData;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchMaHD.Clear();
            // Gọi lại sự kiện Load để tải lại
            frmInvoiceList_Load(sender, e);
        }
    }
}