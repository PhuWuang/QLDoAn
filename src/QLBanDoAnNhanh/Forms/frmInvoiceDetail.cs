using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanDoAnNhanh
{
    public partial class frmInvoiceDetail : Form
    {
        public frmInvoiceDetail()
        {
            InitializeComponent();
        }
        private int _orderId; // Biến để lưu ID
        public frmInvoiceDetail(int orderId)
        {
            InitializeComponent();
            _orderId = orderId; // Gán ID nhận được vào biến
        }

        private void frmInvoiceDetail_Load(object sender, EventArgs e)
        {
            var orderService = new QLBanDoAnNhanh.BLL.OrderService();
            var order = orderService.GetOrderById(_orderId);

            if (order == null)
            {
                MessageBox.Show("Không tìm thấy thông tin hóa đơn.");
                this.Close();
                return;
            }

            // Hiển thị thông tin chung
            lbMaHD.Text = order.IdOrder.ToString();
            lbNgayTao.Text = order.CreateDate?.ToString("dd/MM/yyyy HH:mm");
            lbNhanVien.Text = order.Employee?.NameEmployee;
            lbTongTien.Text = order.Total?.ToString("N0") + " VNĐ";

            // Hiển thị danh sách món ăn
            var detailsData = order.OrderDetails.Select(d => new {
                TenMon = d.Product.NameProduct,
                SoLuong = d.quantity,
                DonGia = d.Product.PriceProduct,
                ThanhTien = d.quantity * d.Product.PriceProduct
            }).ToList();

            dgvOrderDetails.DataSource = detailsData;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
