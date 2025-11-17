using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLBanDoAnNhanh.BLL;   // để dùng PosFastFoodsDataContext

namespace QLBanDoAnNhanh
{
    public partial class frmReport_InvoiceByDate : Form
    {
        public frmReport_InvoiceByDate()
        {
            InitializeComponent();
        }

        private void frmReport_InvoiceByDate_Load(object sender, EventArgs e)
        {
            // Mặc định: hôm nay
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            
            // Xóa mọi data source cũ (nếu có)
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.RefreshReport();

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1); // lấy hết ngày
            if (from > to)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 1) Lấy dữ liệu qua BLL
            var service = new OrderService();
            var list = service.GetInvoicesByDateRange(from, to); // List<InvoiceReportDto>

            // 2) Trỏ tới file RDLC (đã set Copy to Output)
            string reportPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                             "Reports", "rptInvoiceByDate.rdlc");

            // 3) Nạp vào ReportViewer
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = reportPath;

            // TÊN dataset PHẢI trùng với RDLC: "InvoiceByDateDataSet"
            var rds = new ReportDataSource("InvoiceByDateDataSet", list);
            reportViewer1.LocalReport.DataSources.Add(rds);

            // 4) Set tham số hiển thị
            var parameters = new[]
            {
                new ReportParameter("FromDate", dtpFrom.Value.ToString("dd/MM/yyyy")),
                new ReportParameter("ToDate",   dtpTo.Value.ToString("dd/MM/yyyy"))
            };
            reportViewer1.LocalReport.SetParameters(parameters);

            // 5) Refresh
            reportViewer1.RefreshReport();
        }
    }
}
