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
    public partial class frmInvoiceList : Form
    {
        public frmInvoiceList()
        {
            InitializeComponent();
        }

        private void frmInvoiceList_Load(object sender, EventArgs e)
        {
            // 1. Gọi xuống BLL để lấy dữ liệu
            var orderService = new QLBanDoAnNhanh.BLL.OrderService();
            var allOrders = orderService.GetAllOrders();

            // 2. Xử lý và hiển thị dữ liệu lên DataGridView
            // Chúng ta tạo một danh sách tạm (anonymous list) chỉ chứa các cột cần thiết
            var displayData = allOrders.Select(o => new {
                ID = o.IdOrder,
                Date = o.CreateDate,
                Employee = o.Employee?.NameEmployee, // Dùng "?." để tránh lỗi nếu nhân viên null
                Total = o.Total?.ToString("N2") + " $"
            }).ToList();

            dgvInvoices.DataSource = displayData;
        }

        private void dgvInvoices_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo người dùng không nhấn vào header
            if (e.RowIndex >= 0)
            {
                // Lấy ID của hóa đơn từ cột "MaHD" của dòng được nhấn
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

            // Gọi xuống BLL
            var orderService = new QLBanDoAnNhanh.BLL.OrderService();
            var searchResult = orderService.SearchOrders(orderId, startDate, endDate);

            // Hiển thị kết quả (chúng ta sẽ tái cấu trúc phần này ngay sau đây)
            var displayData = searchResult.Select(o => new {
                ID = o.IdOrder,
                Date = o.CreateDate,
                Employee = o.Employee?.NameEmployee,
                Total = o.Total?.ToString("N2") + " $"
            }).ToList();

            dgvInvoices.DataSource = displayData;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSearchMaHD.Clear();
            // Gọi lại sự kiện Load để tải lại toàn bộ danh sách
            frmInvoiceList_Load(sender, e);
        }
    }
}
