using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL;
using QLBanDoAnNhanh.DAL;

namespace QLBanDoAnNhanh.Forms
{
    public partial class frmEmployee : Form
    {
        private readonly EmployeeService _employeeService;

        public frmEmployee()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
        }

        // --------- FORM LOAD: load vai trò + danh sách NV ----------
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadRolesToCombo();
            LoadEmployees();
        }

        // Load dữ liệu vai trò vào combobox
        private void LoadRolesToCombo()
        {
            using (var db = DataContextFactory.Create())
            {
                var roles = db.Roles
                              .OrderBy(r => r.IdRole)
                              .Select(r => new { r.IdRole, r.NameRole })
                              .ToList();

                cboRole.DataSource = roles;
                cboRole.DisplayMember = "NameRole";
                cboRole.ValueMember = "IdRole";
            }
        }

        // Load danh sách nhân viên (có search nếu truyền keyword)
        private void LoadEmployees(string keyword = null)
        {
            var list = _employeeService.GetAllActiveEmployees();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLower();
                list = list
                    .Where(e =>
                        (e.NameEmployee ?? "").ToLower().Contains(keyword) ||
                        (e.Email ?? "").ToLower().Contains(keyword))
                    .ToList();
            }

            dgvEmployees.DataSource = list;

            // Ẩn ID, RoleId cho gọn
            if (dgvEmployees.Columns["IdEmployee"] != null)
                dgvEmployees.Columns["IdEmployee"].Visible = false;
            if (dgvEmployees.Columns["RoleId"] != null)
                dgvEmployees.Columns["RoleId"].Visible = false;

            // Đặt lại header text
            if (dgvEmployees.Columns["NameEmployee"] != null)
                dgvEmployees.Columns["NameEmployee"].HeaderText = "Họ tên";
            if (dgvEmployees.Columns["Email"] != null)
                dgvEmployees.Columns["Email"].HeaderText = "Email";
            if (dgvEmployees.Columns["RoleName"] != null)
                dgvEmployees.Columns["RoleName"].HeaderText = "Vai trò";
            if (dgvEmployees.Columns["IsActive"] != null)
                dgvEmployees.Columns["IsActive"].HeaderText = "Hoạt động";
        }

        // --------- NÚT ĐÓNG ----------
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // --------- SEARCH theo name/email ----------
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            LoadEmployees(txtSearchEmployee.Text);
        }

        // Nếu muốn vừa gõ vừa lọc thì bỏ comment dòng dưới
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            // LoadEmployees(txtSearchEmployee.Text);
        }

        // --------- RELOAD (xóa ô search, load tất cả) ----------
        private void btnReloadEmployee_Click(object sender, EventArgs e)
        {
            txtSearchEmployee.Clear();
            LoadEmployees();
        }

        // --------- VALIDATE dữ liệu tạo tài khoản ----------
        private bool ValidateNewEmployee()
        {
            string name = lblNameEmployee.Text.Trim();
            string email = txtEmailEmployee.Text.Trim();
            string password = txtPasswordEmployee.Text;
            string confirm = txtConfirmPasswordEmployee.Text;

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email không hợp lệ.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (password != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // --------- NÚT TẠO TÀI KHOẢN ----------
        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateNewEmployee())
                return;

            string name = lblNameEmployee.Text.Trim();
            string email = txtEmailEmployee.Text.Trim();
            string password = txtPasswordEmployee.Text;
            bool isActive = chkIsActive.Checked;
            int roleId = (int)cboRole.SelectedValue;

            string message = _employeeService.CreateEmployee(
                name, email, password, roleId, isActive);

            MessageBox.Show(message, "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nếu tạo thành công thì clear form + reload
            if (message.StartsWith("Tạo tài khoản"))
            {
                ClearNewEmployeeForm();
                LoadEmployees();
            }
        }

        private void ClearNewEmployeeForm()
        {
            txtNameEmployee.Clear();
            txtEmailEmployee.Clear();
            txtPasswordEmployee.Clear();
            txtConfirmPasswordEmployee.Clear();
            chkIsActive.Checked = true;

            if (cboRole.Items.Count > 0)
                cboRole.SelectedIndex = 0;
        }
    }
}
