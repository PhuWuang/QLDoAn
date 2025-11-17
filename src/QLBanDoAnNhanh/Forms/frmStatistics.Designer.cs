namespace QLBanDoAnNhanh
{
    partial class frmStatistics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lbRevenueResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chartMonthlyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartTypeProduct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboFromMonth = new System.Windows.Forms.ComboBox();
            this.cboToMonth = new System.Windows.Forms.ComboBox();
            this.btnViewByMonth = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeProduct)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 6;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(619, -4);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(37, 29);
            this.guna2ControlBox1.TabIndex = 21;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("UTM Alexander", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(16, 742);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(557, 45);
            this.label6.TabIndex = 25;
            this.label6.Text = "DOANH THU THEO LOẠI SẢN PHẨM";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MM/dd/yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(144, 70);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 30);
            this.dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MM/dd/yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(144, 134);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 30);
            this.dtpEndDate.TabIndex = 1;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Font = new System.Drawing.Font("UTM Alexander", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculate.Location = new System.Drawing.Point(427, 92);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(136, 43);
            this.btnCalculate.TabIndex = 2;
            this.btnCalculate.Text = "Thống kê";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // lbRevenueResult
            // 
            this.lbRevenueResult.AutoSize = true;
            this.lbRevenueResult.Font = new System.Drawing.Font("UTM Alexander", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRevenueResult.ForeColor = System.Drawing.Color.Red;
            this.lbRevenueResult.Location = new System.Drawing.Point(265, 206);
            this.lbRevenueResult.Name = "lbRevenueResult";
            this.lbRevenueResult.Size = new System.Drawing.Size(129, 54);
            this.lbRevenueResult.TabIndex = 3;
            this.lbRevenueResult.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("UTM Alexander", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 38);
            this.label1.TabIndex = 4;
            this.label1.Text = "Từ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("UTM Alexander", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(45, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đến:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("UTM Alexander", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(49, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 38);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tổng cộng:";
            // 
            // chartMonthlyRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMonthlyRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartMonthlyRevenue.Legends.Add(legend1);
            this.chartMonthlyRevenue.Location = new System.Drawing.Point(24, 416);
            this.chartMonthlyRevenue.Name = "chartMonthlyRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu";
            this.chartMonthlyRevenue.Series.Add(series1);
            this.chartMonthlyRevenue.Size = new System.Drawing.Size(587, 300);
            this.chartMonthlyRevenue.TabIndex = 22;
            this.chartMonthlyRevenue.Text = "chart1";
            // 
            // chartTypeProduct
            // 
            chartArea2.Name = "ChartArea1";
            this.chartTypeProduct.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartTypeProduct.Legends.Add(legend2);
            this.chartTypeProduct.Location = new System.Drawing.Point(24, 802);
            this.chartTypeProduct.Name = "chartTypeProduct";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Font = new System.Drawing.Font("UTM Alexander", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series2.IsValueShownAsLabel = true;
            series2.Label = "#PERCENT{P0}";
            series2.Legend = "Legend1";
            series2.LegendText = "#VALX";
            series2.Name = "Series1";
            this.chartTypeProduct.Series.Add(series2);
            this.chartTypeProduct.Size = new System.Drawing.Size(587, 288);
            this.chartTypeProduct.TabIndex = 23;
            this.chartTypeProduct.Text = "chart2";
            title1.Font = new System.Drawing.Font("UTM Alexander", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "TỶ LỆ DOANH THU THEO LOẠI SẢN PHẨM";
            this.chartTypeProduct.Titles.Add(title1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("UTM Alexander", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(114, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(413, 45);
            this.label5.TabIndex = 24;
            this.label5.Text = "DOANH THU THEO THÁNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("UTM Alexander", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(114, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(374, 45);
            this.label4.TabIndex = 7;
            this.label4.Text = "THỐNG KÊ DOANH THU";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnViewByMonth);
            this.panel1.Controls.Add(this.cboToMonth);
            this.panel1.Controls.Add(this.cboFromMonth);
            this.panel1.Controls.Add(this.cboYear);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.chartMonthlyRevenue);
            this.panel1.Controls.Add(this.chartTypeProduct);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtpStartDate);
            this.panel1.Controls.Add(this.dtpEndDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lbRevenueResult);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 432);
            this.panel1.TabIndex = 26;
            // 
            // cboYear
            // 
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("UTM Alexander", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(347, 357);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(121, 30);
            this.cboYear.TabIndex = 26;
            // 
            // cboFromMonth
            // 
            this.cboFromMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFromMonth.Font = new System.Drawing.Font("UTM Alexander", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFromMonth.FormattingEnabled = true;
            this.cboFromMonth.Location = new System.Drawing.Point(24, 357);
            this.cboFromMonth.Name = "cboFromMonth";
            this.cboFromMonth.Size = new System.Drawing.Size(121, 30);
            this.cboFromMonth.TabIndex = 27;
            // 
            // cboToMonth
            // 
            this.cboToMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToMonth.Font = new System.Drawing.Font("UTM Alexander", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToMonth.FormattingEnabled = true;
            this.cboToMonth.Location = new System.Drawing.Point(184, 357);
            this.cboToMonth.Name = "cboToMonth";
            this.cboToMonth.Size = new System.Drawing.Size(121, 30);
            this.cboToMonth.TabIndex = 28;
            // 
            // btnViewByMonth
            // 
            this.btnViewByMonth.Font = new System.Drawing.Font("UTM Alexander", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewByMonth.Location = new System.Drawing.Point(507, 346);
            this.btnViewByMonth.Name = "btnViewByMonth";
            this.btnViewByMonth.Size = new System.Drawing.Size(104, 47);
            this.btnViewByMonth.TabIndex = 29;
            this.btnViewByMonth.Text = "Xem";
            this.btnViewByMonth.UseVisualStyleBackColor = true;
            this.btnViewByMonth.Click += new System.EventHandler(this.btnViewByMonth_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("UTM Alexander", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 27);
            this.label7.TabIndex = 30;
            this.label7.Text = "Từ tháng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("UTM Alexander", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(179, 327);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 27);
            this.label8.TabIndex = 31;
            this.label8.Text = "Đến tháng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("UTM Alexander", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 27);
            this.label9.TabIndex = 32;
            this.label9.Text = "Năm:";
            // 
            // frmStatistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 466);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStatistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmStatistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMonthlyRevenue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTypeProduct)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTypeProduct;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMonthlyRevenue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRevenueResult;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboToMonth;
        private System.Windows.Forms.ComboBox cboFromMonth;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Button btnViewByMonth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}