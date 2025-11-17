using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using QLBanDoAnNhanh.BLL;
using QLBanDoAnNhanh.BLL.DTOs;
using System.Collections.Generic;

namespace QLBanDoAnNhanh.Forms
{
    public partial class frmReport_TopProducts : Form
    {
        public frmReport_TopProducts()
        {
            InitializeComponent();
        }

        private void frmReport_TopProducts_Load(object sender, EventArgs e)
        {

            this.reportViewerTopProducts.RefreshReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            // 1. Lấy input
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            int topN = (int)nudTop.Value;

            if (from > to)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Gọi BLL lấy dữ liệu
            var service = new OrderService();
            List<TopProductReportItem> data = service.GetTopProducts(from, to, topN);

            // 3. Gắn dữ liệu cho ReportViewer
            var rds = new ReportDataSource("TopProductsDataSet", data);
            //  "TopProductsDataSet" PHẢI trùng với Dataset Name trong RDLC

            reportViewerTopProducts.LocalReport.DataSources.Clear();
            reportViewerTopProducts.LocalReport.DataSources.Add(rds);

            // (Tuỳ chọn) Truyền parameter để hiện trên header report
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("FromDate1", from.ToString("dd/MM/yyyy")),
                new ReportParameter("ToDate1", to.ToString("dd/MM/yyyy")),
                new ReportParameter("TopN", topN.ToString())
            };
            // Nếu bạn có tạo 3 ReportParameter này trong RDLC thì mới gọi set
            reportViewerTopProducts.LocalReport.SetParameters(parameters);

            // 4. Refresh
            reportViewerTopProducts.RefreshReport();
        }
    }
}
