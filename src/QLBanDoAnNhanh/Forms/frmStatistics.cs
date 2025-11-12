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
            lbRevenueResult.Text = totalRevenue.ToString("0.00") + "$";
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
