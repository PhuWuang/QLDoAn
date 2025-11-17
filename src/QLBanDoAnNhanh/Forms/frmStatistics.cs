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
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // 1. Get the start and end dates from the DateTimePickers
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            // Ensure the start date is not later than the end date
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Call the BLL to perform the calculation
            var orderService = new QLBanDoAnNhanh.BLL.OrderService();
            decimal totalRevenue = orderService.GetTotalRevenueByDateRange(startDate, endDate);

            // 3. Display the result in the Label with the correct currency
            lbRevenueResult.Text = totalRevenue.ToString("n0") + "VNĐ";

            // 4. Lấy doanh thu theo loại sản phẩm
            var revenueByType = orderService.GetRevenueByTypeProduct(startDate, endDate);

            // 5. Vẽ lại Pie chart
            var series = chartTypeProduct.Series[0];
            series.Points.Clear();

            foreach (var kvp in revenueByType)
            {
                // kvp.Key  = tên loại sản phẩm
                // kvp.Value = tổng doanh thu của loại đó
                int pointIndex = series.Points.AddY((double)kvp.Value);
                var point = series.Points[pointIndex];

                point.AxisLabel = kvp.Key;   // hiện tên dưới biểu đồ
                point.LegendText = kvp.Key;  // hiện tên trong Legend
                point.Label = kvp.Value.ToString("n0"); // số tiền trên từng miếng bánh
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmStatistics_Load(object sender, EventArgs e)
        {
            // 1. Nạp danh sách năm (ví dụ 2022 -> năm hiện tại)
            int currentYear = DateTime.Now.Year;
            for (int year = 2022; year <= currentYear; year++)
            {
                cboYear.Items.Add(year);
            }

            if (cboYear.Items.Count > 0)
            {
                cboYear.SelectedItem = currentYear;
            }

            // 2. Nạp danh sách tháng 1..12 cho 2 combobox
            for (int month = 1; month <= 12; month++)
            {
                cboFromMonth.Items.Add(month);
                cboToMonth.Items.Add(month);
            }

            // Giá trị mặc định: từ tháng 1 đến tháng 12
            cboFromMonth.SelectedItem = 1;
            cboToMonth.SelectedItem = 12;
        }

        private void btnViewByMonth_Click(object sender, EventArgs e)
        {
            // 1. Lấy giá trị năm, từ tháng, đến tháng từ combobox
            if (cboYear.SelectedItem == null ||
                cboFromMonth.SelectedItem == null ||
                cboToMonth.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn năm và khoảng tháng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int year = (int)cboYear.SelectedItem;
            int fromMonth = (int)cboFromMonth.SelectedItem;
            int toMonth = (int)cboToMonth.SelectedItem;

            // Đảm bảo fromMonth <= toMonth
            if (fromMonth > toMonth)
            {
                MessageBox.Show("Tháng bắt đầu không được lớn hơn tháng kết thúc.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Gọi BLL để lấy dữ liệu
            var service = new QLBanDoAnNhanh.BLL.OrderService();
            var data = service.GetMonthlyRevenue(year, fromMonth, toMonth);

            // 3. Vẽ lại biểu đồ cột
            var series = chartMonthlyRevenue.Series[0];
            series.Points.Clear();

            for (int month = fromMonth; month <= toMonth; month++)
            {
                decimal total = 0m;
                if (data.ContainsKey(month))
                {
                    total = data[month];
                }

                int pointIndex = series.Points.AddXY(month, (double)total);
                var point = series.Points[pointIndex];

                point.AxisLabel = "Tháng " + month;
                point.Label = total.ToString("n0"); // hiện số tiền trên cột
            }
        }
    }
}
