namespace QLBanDoAnNhanh.Forms
{
    partial class frmCredits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCredits));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblCopyright = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.tblMembers = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMemberHa = new System.Windows.Forms.Panel();
            this.lblRoleHa = new System.Windows.Forms.Label();
            this.lblMemberHa = new System.Windows.Forms.Label();
            this.pnlMemberNhi = new System.Windows.Forms.Panel();
            this.lblRoleNhi = new System.Windows.Forms.Label();
            this.lblMemberNhi = new System.Windows.Forms.Label();
            this.pnlMemberVinh = new System.Windows.Forms.Panel();
            this.lblVinhRole = new System.Windows.Forms.Label();
            this.lblVinhName = new System.Windows.Forms.Label();
            this.pnlMemberHuy = new System.Windows.Forms.Panel();
            this.lblHuyRole = new System.Windows.Forms.Label();
            this.lblHuyName = new System.Windows.Forms.Label();
            this.pnlMemberLeader = new System.Windows.Forms.Panel();
            this.lblLeaderRole = new System.Windows.Forms.Label();
            this.lblLeaderName = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.picCredits = new System.Windows.Forms.PictureBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.tblMembers.SuspendLayout();
            this.pnlMemberHa.SuspendLayout();
            this.pnlMemberNhi.SuspendLayout();
            this.pnlMemberVinh.SuspendLayout();
            this.pnlMemberHuy.SuspendLayout();
            this.pnlMemberLeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCredits)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblCopyright);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlMain.Size = new System.Drawing.Size(619, 363);
            this.pnlMain.TabIndex = 0;
            // 
            // lblCopyright
            // 
            this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCopyright.AutoSize = true;
            this.lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblCopyright.Location = new System.Drawing.Point(80, 341);
            this.lblCopyright.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCopyright.Name = "lblCopyright";
            this.lblCopyright.Size = new System.Drawing.Size(472, 19);
            this.lblCopyright.TabIndex = 1;
            this.lblCopyright.Text = "© 2025 HAPI TEAM (Nhom 3) – Food Hori POS System. All rights reserved.";
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.tblMembers);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(231, 67);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(375, 284);
            this.pnlRight.TabIndex = 2;
            // 
            // tblMembers
            // 
            this.tblMembers.AutoSize = true;
            this.tblMembers.ColumnCount = 1;
            this.tblMembers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMembers.Controls.Add(this.pnlMemberHa, 0, 4);
            this.tblMembers.Controls.Add(this.pnlMemberNhi, 0, 3);
            this.tblMembers.Controls.Add(this.pnlMemberVinh, 0, 2);
            this.tblMembers.Controls.Add(this.pnlMemberHuy, 0, 1);
            this.tblMembers.Controls.Add(this.pnlMemberLeader, 0, 0);
            this.tblMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMembers.Location = new System.Drawing.Point(0, 0);
            this.tblMembers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tblMembers.Name = "tblMembers";
            this.tblMembers.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.tblMembers.RowCount = 5;
            this.tblMembers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMembers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMembers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMembers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMembers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tblMembers.Size = new System.Drawing.Size(375, 284);
            this.tblMembers.TabIndex = 0;
            this.tblMembers.Paint += new System.Windows.Forms.PaintEventHandler(this.tblMembers_Paint);
            // 
            // pnlMemberHa
            // 
            this.pnlMemberHa.Controls.Add(this.lblRoleHa);
            this.pnlMemberHa.Controls.Add(this.lblMemberHa);
            this.pnlMemberHa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberHa.Location = new System.Drawing.Point(11, 218);
            this.pnlMemberHa.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMemberHa.Name = "pnlMemberHa";
            this.pnlMemberHa.Size = new System.Drawing.Size(353, 56);
            this.pnlMemberHa.TabIndex = 4;
            // 
            // lblRoleHa
            // 
            this.lblRoleHa.AutoSize = true;
            this.lblRoleHa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRoleHa.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoleHa.Location = new System.Drawing.Point(0, 25);
            this.lblRoleHa.Name = "lblRoleHa";
            this.lblRoleHa.Size = new System.Drawing.Size(93, 20);
            this.lblRoleHa.TabIndex = 1;
            this.lblRoleHa.Text = "Viết báo cáo";
            // 
            // lblMemberHa
            // 
            this.lblMemberHa.AutoSize = true;
            this.lblMemberHa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMemberHa.Location = new System.Drawing.Point(0, 0);
            this.lblMemberHa.Name = "lblMemberHa";
            this.lblMemberHa.Size = new System.Drawing.Size(173, 23);
            this.lblMemberHa.TabIndex = 0;
            this.lblMemberHa.Text = "Nguyễn Thị Nhật Hạ";
            // 
            // pnlMemberNhi
            // 
            this.pnlMemberNhi.Controls.Add(this.lblRoleNhi);
            this.pnlMemberNhi.Controls.Add(this.lblMemberNhi);
            this.pnlMemberNhi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberNhi.Location = new System.Drawing.Point(11, 166);
            this.pnlMemberNhi.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMemberNhi.Name = "pnlMemberNhi";
            this.pnlMemberNhi.Size = new System.Drawing.Size(353, 52);
            this.pnlMemberNhi.TabIndex = 3;
            // 
            // lblRoleNhi
            // 
            this.lblRoleNhi.AutoSize = true;
            this.lblRoleNhi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblRoleNhi.ForeColor = System.Drawing.Color.DimGray;
            this.lblRoleNhi.Location = new System.Drawing.Point(0, 25);
            this.lblRoleNhi.Name = "lblRoleNhi";
            this.lblRoleNhi.Size = new System.Drawing.Size(48, 20);
            this.lblRoleNhi.TabIndex = 1;
            this.lblRoleNhi.Text = "Tester";
            // 
            // lblMemberNhi
            // 
            this.lblMemberNhi.AutoSize = true;
            this.lblMemberNhi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMemberNhi.Location = new System.Drawing.Point(0, 0);
            this.lblMemberNhi.Name = "lblMemberNhi";
            this.lblMemberNhi.Size = new System.Drawing.Size(125, 23);
            this.lblMemberNhi.TabIndex = 0;
            this.lblMemberNhi.Text = "Trần Ngọc Nhi";
            // 
            // pnlMemberVinh
            // 
            this.pnlMemberVinh.Controls.Add(this.lblVinhRole);
            this.pnlMemberVinh.Controls.Add(this.lblVinhName);
            this.pnlMemberVinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberVinh.Location = new System.Drawing.Point(11, 114);
            this.pnlMemberVinh.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMemberVinh.Name = "pnlMemberVinh";
            this.pnlMemberVinh.Size = new System.Drawing.Size(353, 52);
            this.pnlMemberVinh.TabIndex = 2;
            // 
            // lblVinhRole
            // 
            this.lblVinhRole.AutoSize = true;
            this.lblVinhRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblVinhRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblVinhRole.Location = new System.Drawing.Point(0, 25);
            this.lblVinhRole.Name = "lblVinhRole";
            this.lblVinhRole.Size = new System.Drawing.Size(48, 20);
            this.lblVinhRole.TabIndex = 1;
            this.lblVinhRole.Text = "UI/UX";
            // 
            // lblVinhName
            // 
            this.lblVinhName.AutoSize = true;
            this.lblVinhName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblVinhName.Location = new System.Drawing.Point(0, 0);
            this.lblVinhName.Name = "lblVinhName";
            this.lblVinhName.Size = new System.Drawing.Size(161, 23);
            this.lblVinhName.TabIndex = 0;
            this.lblVinhName.Text = "Lương Quang Vinh";
            // 
            // pnlMemberHuy
            // 
            this.pnlMemberHuy.Controls.Add(this.lblHuyRole);
            this.pnlMemberHuy.Controls.Add(this.lblHuyName);
            this.pnlMemberHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberHuy.Location = new System.Drawing.Point(11, 62);
            this.pnlMemberHuy.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMemberHuy.Name = "pnlMemberHuy";
            this.pnlMemberHuy.Size = new System.Drawing.Size(353, 52);
            this.pnlMemberHuy.TabIndex = 1;
            // 
            // lblHuyRole
            // 
            this.lblHuyRole.AutoSize = true;
            this.lblHuyRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHuyRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblHuyRole.Location = new System.Drawing.Point(0, 25);
            this.lblHuyRole.Name = "lblHuyRole";
            this.lblHuyRole.Size = new System.Drawing.Size(192, 20);
            this.lblHuyRole.TabIndex = 1;
            this.lblHuyRole.Text = "Code phụ (code chức năng)";
            // 
            // lblHuyName
            // 
            this.lblHuyName.AutoSize = true;
            this.lblHuyName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblHuyName.Location = new System.Drawing.Point(0, 0);
            this.lblHuyName.Name = "lblHuyName";
            this.lblHuyName.Size = new System.Drawing.Size(156, 23);
            this.lblHuyName.TabIndex = 0;
            this.lblHuyName.Text = "Lê Kim Thanh Huy";
            // 
            // pnlMemberLeader
            // 
            this.pnlMemberLeader.Controls.Add(this.lblLeaderRole);
            this.pnlMemberLeader.Controls.Add(this.lblLeaderName);
            this.pnlMemberLeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMemberLeader.Location = new System.Drawing.Point(11, 10);
            this.pnlMemberLeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMemberLeader.Name = "pnlMemberLeader";
            this.pnlMemberLeader.Size = new System.Drawing.Size(353, 52);
            this.pnlMemberLeader.TabIndex = 0;
            // 
            // lblLeaderRole
            // 
            this.lblLeaderRole.AutoSize = true;
            this.lblLeaderRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLeaderRole.ForeColor = System.Drawing.Color.DimGray;
            this.lblLeaderRole.Location = new System.Drawing.Point(0, 25);
            this.lblLeaderRole.Name = "lblLeaderRole";
            this.lblLeaderRole.Size = new System.Drawing.Size(141, 20);
            this.lblLeaderRole.TabIndex = 1;
            this.lblLeaderRole.Text = "Code chính fullstack";
            // 
            // lblLeaderName
            // 
            this.lblLeaderName.AutoSize = true;
            this.lblLeaderName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblLeaderName.Location = new System.Drawing.Point(0, 0);
            this.lblLeaderName.Name = "lblLeaderName";
            this.lblLeaderName.Size = new System.Drawing.Size(320, 23);
            this.lblLeaderName.TabIndex = 0;
            this.lblLeaderName.Text = "Phạm Phan Phú Quang (Nhóm trưởng)";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.picCredits);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(11, 67);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(220, 284);
            this.pnlLeft.TabIndex = 1;
            // 
            // picCredits
            // 
            this.picCredits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCredits.Image = ((System.Drawing.Image)(resources.GetObject("picCredits.Image")));
            this.picCredits.Location = new System.Drawing.Point(0, 0);
            this.picCredits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCredits.Name = "picCredits";
            this.picCredits.Size = new System.Drawing.Size(220, 284);
            this.picCredits.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCredits.TabIndex = 0;
            this.picCredits.TabStop = false;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Control;
            this.pnlHeader.Controls.Add(this.btnClose);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.ForeColor = System.Drawing.Color.White;
            this.pnlHeader.Location = new System.Drawing.Point(11, 10);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(595, 57);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(68)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(564, 2);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(29, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(235, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(105, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CREDITS";
            // 
            // frmCredits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(619, 363);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmCredits";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credits";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.tblMembers.ResumeLayout(false);
            this.pnlMemberHa.ResumeLayout(false);
            this.pnlMemberHa.PerformLayout();
            this.pnlMemberNhi.ResumeLayout(false);
            this.pnlMemberNhi.PerformLayout();
            this.pnlMemberVinh.ResumeLayout(false);
            this.pnlMemberVinh.PerformLayout();
            this.pnlMemberHuy.ResumeLayout(false);
            this.pnlMemberHuy.PerformLayout();
            this.pnlMemberLeader.ResumeLayout(false);
            this.pnlMemberLeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCredits)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.PictureBox picCredits;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.TableLayoutPanel tblMembers;
        private System.Windows.Forms.Panel pnlMemberLeader;
        private System.Windows.Forms.Label lblLeaderName;
        private System.Windows.Forms.Label lblLeaderRole;
        private System.Windows.Forms.Panel pnlMemberHuy;
        private System.Windows.Forms.Label lblHuyRole;
        private System.Windows.Forms.Label lblHuyName;
        private System.Windows.Forms.Panel pnlMemberVinh;
        private System.Windows.Forms.Label lblVinhRole;
        private System.Windows.Forms.Label lblVinhName;
        private System.Windows.Forms.Panel pnlMemberHa;
        private System.Windows.Forms.Label lblRoleHa;
        private System.Windows.Forms.Label lblMemberHa;
        private System.Windows.Forms.Panel pnlMemberNhi;
        private System.Windows.Forms.Label lblRoleNhi;
        private System.Windows.Forms.Label lblMemberNhi;
        private System.Windows.Forms.Label lblCopyright;
    }
}