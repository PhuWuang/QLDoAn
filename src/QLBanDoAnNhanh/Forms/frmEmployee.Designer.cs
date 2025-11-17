namespace QLBanDoAnNhanh.Forms
{
    partial class frmEmployee
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmployee));
            this.pnlHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.dgvEmployees = new System.Windows.Forms.DataGridView();
            this.colIdEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreatedAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNameEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.lblSearchEmployee = new System.Windows.Forms.Label();
            this.btnReloadEmployee = new System.Windows.Forms.Button();
            this.txtSearchEmployee = new System.Windows.Forms.TextBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.gbNewEmployee = new System.Windows.Forms.GroupBox();
            this.lblNameEmployee = new System.Windows.Forms.Label();
            this.btnCreateEmployee = new System.Windows.Forms.Button();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtConfirmPasswordEmployee = new System.Windows.Forms.TextBox();
            this.lblConfirmPasswordEmployee = new System.Windows.Forms.Label();
            this.txtPasswordEmployee = new System.Windows.Forms.TextBox();
            this.lblPasswordEmployee = new System.Windows.Forms.Label();
            this.txtEmailEmployee = new System.Windows.Forms.TextBox();
            this.lblEmailEmployee = new System.Windows.Forms.Label();
            this.txtNameEmployee = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.gbNewEmployee.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.picIcon);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(999, 71);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(969, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // picIcon
            // 
            this.picIcon.BackColor = System.Drawing.SystemColors.Control;
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(16, 15);
            this.picIcon.Margin = new System.Windows.Forms.Padding(4);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(43, 39);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picIcon.TabIndex = 0;
            this.picIcon.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.Location = new System.Drawing.Point(286, 17);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(389, 37);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Quản lý tài khoản nhân viên";
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlLeft.Controls.Add(this.dgvEmployees);
            this.pnlLeft.Controls.Add(this.pnlSearch);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 71);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(464, 574);
            this.pnlLeft.TabIndex = 1;
            // 
            // dgvEmployees
            // 
            this.dgvEmployees.AllowUserToAddRows = false;
            this.dgvEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdEmployee,
            this.colRole,
            this.colCreatedAt,
            this.colEmail,
            this.colNameEmployee});
            this.dgvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployees.Location = new System.Drawing.Point(0, 60);
            this.dgvEmployees.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmployees.Name = "dgvEmployees";
            this.dgvEmployees.RowHeadersWidth = 51;
            this.dgvEmployees.Size = new System.Drawing.Size(464, 514);
            this.dgvEmployees.TabIndex = 5;
            // 
            // colIdEmployee
            // 
            this.colIdEmployee.DataPropertyName = "IdEmployee";
            this.colIdEmployee.HeaderText = "Id";
            this.colIdEmployee.MinimumWidth = 6;
            this.colIdEmployee.Name = "colIdEmployee";
            this.colIdEmployee.Visible = false;
            // 
            // colRole
            // 
            this.colRole.DataPropertyName = "IsActive";
            this.colRole.HeaderText = "Hoạt động";
            this.colRole.MinimumWidth = 6;
            this.colRole.Name = "colRole";
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.DataPropertyName = "CreatedAt";
            this.colCreatedAt.HeaderText = "Ngày tạo";
            this.colCreatedAt.MinimumWidth = 6;
            this.colCreatedAt.Name = "colCreatedAt";
            // 
            // colEmail
            // 
            this.colEmail.DataPropertyName = "Email";
            this.colEmail.HeaderText = "Email";
            this.colEmail.MinimumWidth = 6;
            this.colEmail.Name = "colEmail";
            // 
            // colNameEmployee
            // 
            this.colNameEmployee.DataPropertyName = "NameEmployee";
            this.colNameEmployee.HeaderText = "Họ tên";
            this.colNameEmployee.MinimumWidth = 6;
            this.colNameEmployee.Name = "colNameEmployee";
            this.colNameEmployee.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.btnSearchEmployee);
            this.pnlSearch.Controls.Add(this.lblSearchEmployee);
            this.pnlSearch.Controls.Add(this.btnReloadEmployee);
            this.pnlSearch.Controls.Add(this.txtSearchEmployee);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(464, 60);
            this.pnlSearch.TabIndex = 4;
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.AutoSize = true;
            this.btnSearchEmployee.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnSearchEmployee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSearchEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchEmployee.Location = new System.Drawing.Point(326, 20);
            this.btnSearchEmployee.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(62, 24);
            this.btnSearchEmployee.TabIndex = 2;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = false;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // lblSearchEmployee
            // 
            this.lblSearchEmployee.AutoSize = true;
            this.lblSearchEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblSearchEmployee.Location = new System.Drawing.Point(4, 16);
            this.lblSearchEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSearchEmployee.Name = "lblSearchEmployee";
            this.lblSearchEmployee.Size = new System.Drawing.Size(64, 21);
            this.lblSearchEmployee.TabIndex = 0;
            this.lblSearchEmployee.Text = "Name: ";
            // 
            // btnReloadEmployee
            // 
            this.btnReloadEmployee.AutoSize = true;
            this.btnReloadEmployee.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnReloadEmployee.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReloadEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReloadEmployee.Location = new System.Drawing.Point(390, 20);
            this.btnReloadEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.btnReloadEmployee.Name = "btnReloadEmployee";
            this.btnReloadEmployee.Size = new System.Drawing.Size(57, 23);
            this.btnReloadEmployee.TabIndex = 3;
            this.btnReloadEmployee.Text = "Reload";
            this.btnReloadEmployee.UseVisualStyleBackColor = false;
            this.btnReloadEmployee.Click += new System.EventHandler(this.btnReloadEmployee_Click);
            // 
            // txtSearchEmployee
            // 
            this.txtSearchEmployee.Location = new System.Drawing.Point(79, 20);
            this.txtSearchEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearchEmployee.Name = "txtSearchEmployee";
            this.txtSearchEmployee.Size = new System.Drawing.Size(236, 22);
            this.txtSearchEmployee.TabIndex = 1;
            this.txtSearchEmployee.TextChanged += new System.EventHandler(this.txtSearchEmployee_TextChanged);
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.gbNewEmployee);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(464, 71);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(535, 574);
            this.pnlRight.TabIndex = 2;
            // 
            // gbNewEmployee
            // 
            this.gbNewEmployee.BackColor = System.Drawing.Color.White;
            this.gbNewEmployee.Controls.Add(this.lblNameEmployee);
            this.gbNewEmployee.Controls.Add(this.btnCreateEmployee);
            this.gbNewEmployee.Controls.Add(this.chkIsActive);
            this.gbNewEmployee.Controls.Add(this.cboRole);
            this.gbNewEmployee.Controls.Add(this.lblRole);
            this.gbNewEmployee.Controls.Add(this.txtConfirmPasswordEmployee);
            this.gbNewEmployee.Controls.Add(this.lblConfirmPasswordEmployee);
            this.gbNewEmployee.Controls.Add(this.txtPasswordEmployee);
            this.gbNewEmployee.Controls.Add(this.lblPasswordEmployee);
            this.gbNewEmployee.Controls.Add(this.txtEmailEmployee);
            this.gbNewEmployee.Controls.Add(this.lblEmailEmployee);
            this.gbNewEmployee.Controls.Add(this.txtNameEmployee);
            this.gbNewEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNewEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gbNewEmployee.ForeColor = System.Drawing.Color.DarkBlue;
            this.gbNewEmployee.Location = new System.Drawing.Point(0, 0);
            this.gbNewEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.gbNewEmployee.Name = "gbNewEmployee";
            this.gbNewEmployee.Padding = new System.Windows.Forms.Padding(4);
            this.gbNewEmployee.Size = new System.Drawing.Size(535, 574);
            this.gbNewEmployee.TabIndex = 0;
            this.gbNewEmployee.TabStop = false;
            this.gbNewEmployee.Text = "Tạo tài khoản mới";
            // 
            // lblNameEmployee
            // 
            this.lblNameEmployee.AutoSize = true;
            this.lblNameEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNameEmployee.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblNameEmployee.Location = new System.Drawing.Point(20, 34);
            this.lblNameEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNameEmployee.Name = "lblNameEmployee";
            this.lblNameEmployee.Size = new System.Drawing.Size(133, 21);
            this.lblNameEmployee.TabIndex = 13;
            this.lblNameEmployee.Text = "Họ tên nhân viên";
            // 
            // btnCreateEmployee
            // 
            this.btnCreateEmployee.BackColor = System.Drawing.Color.SeaGreen;
            this.btnCreateEmployee.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnCreateEmployee.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnCreateEmployee.Location = new System.Drawing.Point(319, 516);
            this.btnCreateEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateEmployee.Name = "btnCreateEmployee";
            this.btnCreateEmployee.Size = new System.Drawing.Size(200, 43);
            this.btnCreateEmployee.TabIndex = 12;
            this.btnCreateEmployee.Text = "Tạo tài khoản";
            this.btnCreateEmployee.UseVisualStyleBackColor = false;
            this.btnCreateEmployee.Click += new System.EventHandler(this.btnCreateEmployee_Click);
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.chkIsActive.ForeColor = System.Drawing.SystemColors.Highlight;
            this.chkIsActive.Location = new System.Drawing.Point(172, 476);
            this.chkIsActive.Margin = new System.Windows.Forms.Padding(4);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(217, 25);
            this.chkIsActive.TabIndex = 11;
            this.chkIsActive.Text = "Tài khoản đang hoạt động";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // cboRole
            // 
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(25, 411);
            this.cboRole.Margin = new System.Windows.Forms.Padding(4);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(265, 33);
            this.cboRole.TabIndex = 10;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRole.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblRole.Location = new System.Drawing.Point(20, 382);
            this.lblRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(57, 21);
            this.lblRole.TabIndex = 9;
            this.lblRole.Text = "Vai trò";
            // 
            // txtConfirmPasswordEmployee
            // 
            this.txtConfirmPasswordEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtConfirmPasswordEmployee.Location = new System.Drawing.Point(25, 326);
            this.txtConfirmPasswordEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPasswordEmployee.Name = "txtConfirmPasswordEmployee";
            this.txtConfirmPasswordEmployee.PasswordChar = '●';
            this.txtConfirmPasswordEmployee.Size = new System.Drawing.Size(435, 33);
            this.txtConfirmPasswordEmployee.TabIndex = 8;
            this.txtConfirmPasswordEmployee.UseSystemPasswordChar = true;
            // 
            // lblConfirmPasswordEmployee
            // 
            this.lblConfirmPasswordEmployee.AutoSize = true;
            this.lblConfirmPasswordEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblConfirmPasswordEmployee.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblConfirmPasswordEmployee.Location = new System.Drawing.Point(20, 297);
            this.lblConfirmPasswordEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmPasswordEmployee.Name = "lblConfirmPasswordEmployee";
            this.lblConfirmPasswordEmployee.Size = new System.Drawing.Size(145, 21);
            this.lblConfirmPasswordEmployee.TabIndex = 7;
            this.lblConfirmPasswordEmployee.Text = "Xác nhận mật khẩu";
            // 
            // txtPasswordEmployee
            // 
            this.txtPasswordEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtPasswordEmployee.Location = new System.Drawing.Point(25, 240);
            this.txtPasswordEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswordEmployee.Name = "txtPasswordEmployee";
            this.txtPasswordEmployee.PasswordChar = '●';
            this.txtPasswordEmployee.Size = new System.Drawing.Size(435, 33);
            this.txtPasswordEmployee.TabIndex = 6;
            this.txtPasswordEmployee.UseSystemPasswordChar = true;
            // 
            // lblPasswordEmployee
            // 
            this.lblPasswordEmployee.AutoSize = true;
            this.lblPasswordEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPasswordEmployee.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblPasswordEmployee.Location = new System.Drawing.Point(20, 210);
            this.lblPasswordEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPasswordEmployee.Name = "lblPasswordEmployee";
            this.lblPasswordEmployee.Size = new System.Drawing.Size(77, 21);
            this.lblPasswordEmployee.TabIndex = 5;
            this.lblPasswordEmployee.Text = "Mật khẩu";
            // 
            // txtEmailEmployee
            // 
            this.txtEmailEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtEmailEmployee.Location = new System.Drawing.Point(25, 155);
            this.txtEmailEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmailEmployee.Name = "txtEmailEmployee";
            this.txtEmailEmployee.Size = new System.Drawing.Size(435, 33);
            this.txtEmailEmployee.TabIndex = 4;
            // 
            // lblEmailEmployee
            // 
            this.lblEmailEmployee.AutoSize = true;
            this.lblEmailEmployee.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblEmailEmployee.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblEmailEmployee.Location = new System.Drawing.Point(20, 126);
            this.lblEmailEmployee.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmailEmployee.Name = "lblEmailEmployee";
            this.lblEmailEmployee.Size = new System.Drawing.Size(48, 21);
            this.lblEmailEmployee.TabIndex = 3;
            this.lblEmailEmployee.Text = "Email";
            // 
            // txtNameEmployee
            // 
            this.txtNameEmployee.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtNameEmployee.Location = new System.Drawing.Point(25, 65);
            this.txtNameEmployee.Margin = new System.Windows.Forms.Padding(4);
            this.txtNameEmployee.Name = "txtNameEmployee";
            this.txtNameEmployee.Size = new System.Drawing.Size(435, 33);
            this.txtNameEmployee.TabIndex = 2;
            // 
            // frmEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 645);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmployee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản nhân viên";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployees)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.gbNewEmployee.ResumeLayout(false);
            this.gbNewEmployee.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TextBox txtSearchEmployee;
        private System.Windows.Forms.Label lblSearchEmployee;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.Button btnReloadEmployee;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.DataGridView dgvEmployees;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRole;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreatedAt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameEmployee;
        private System.Windows.Forms.GroupBox gbNewEmployee;
        private System.Windows.Forms.Label lblEmailEmployee;
        private System.Windows.Forms.TextBox txtNameEmployee;
        private System.Windows.Forms.TextBox txtPasswordEmployee;
        private System.Windows.Forms.Label lblPasswordEmployee;
        private System.Windows.Forms.TextBox txtEmailEmployee;
        private System.Windows.Forms.TextBox txtConfirmPasswordEmployee;
        private System.Windows.Forms.Label lblConfirmPasswordEmployee;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Button btnCreateEmployee;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Label lblNameEmployee;
    }
}