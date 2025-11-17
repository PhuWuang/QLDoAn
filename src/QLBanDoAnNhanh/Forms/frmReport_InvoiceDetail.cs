using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Microsoft.Reporting.WinForms;

namespace QLBanDoAnNhanh.Forms
{
    public partial class frmReport_InvoiceDetail : Form
    {

        private readonly List<InvoiceLineVM> _items;
        private readonly InvoiceHeaderVM _header;

        public frmReport_InvoiceDetail(List<InvoiceLineVM> items, InvoiceHeaderVM header)
        {
            InitializeComponent();
            _items = items ?? new List<InvoiceLineVM>();
            _header = header ?? new InvoiceHeaderVM();
        }


        private void frmReport_InvoiceDetail_Load(object sender, EventArgs e)
        {
            string reportPath = Path.Combine(Application.StartupPath, "Reports", "rptInvoiceDetail.rdlc");
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("Không tìm thấy report: " + reportPath);
                return;
            }

            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.ReportPath = reportPath;

            var rds = new ReportDataSource("InvoiceLineDataSet", _items); // tên dataset phải TRÙNG RDLC
            reportViewer1.LocalReport.DataSources.Add(rds);

            var ps = new[]
            {
        new ReportParameter("StoreName", _header.StoreName ?? ""),
        new ReportParameter("Phone",     _header.Phone ?? ""),
        new ReportParameter("Email",     _header.Email ?? ""),
        new ReportParameter("Address",   _header.Address ?? ""),
        new ReportParameter("Employee",  _header.Employee ?? ""),
        new ReportParameter("PrintedAt", _header.PrintedAt.ToString("dd/MM/yyyy HH:mm")),
        new ReportParameter("VATRate",   _header.VATRate.ToString(System.Globalization.CultureInfo.InvariantCulture))
    };
            reportViewer1.LocalReport.SetParameters(ps);

            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.PageWidth;
            reportViewer1.RefreshReport();
        }
    }
}
