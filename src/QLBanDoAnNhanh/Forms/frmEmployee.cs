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

            // Khởi tạo service
            _employeeService = new EmployeeService();

            // Load dữ liệu ban đầu
            LoadRoles();
            LoadEmployees();
        }

        // =====================================================================
        // 1. LOAD ROLE LÊN COMBOBOX
        // =====================================================================
        private void LoadRoles()
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

        // =====================================================================
        // 2. LOAD DANH SÁCH NHÂN VIÊN
        // =====================================================================
        private void LoadEmployees(string keyword = null)
        {
            // Lấy danh sách nhân viên đang hoạt động từ BLL
            var list = _employeeService.GetAllActiveEmployees();

            // Lọc theo keyword nếu có
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim().ToLower();

                list = list
                    .Where(e =>
                        (e.NameEmployee ?? string.Empty).ToLower().Contains(keyword) ||
                        (e.Email ?? string.Empty).ToLower().Contains(keyword) ||
                        (e.RoleName ?? string.Empty).ToLower().Contains(keyword))
                    .ToList();
            }

            dgvEmployees.DataSource = list;

            // Ẩn ID, RoleId cho gọn
            if (dgvEmployees.Columns["IdEmployee"] != null)
                dgvEmployees.Columns["IdEmployee"].Visible = false;

            if (dgvEmployees.Columns["RoleId"] != null)
                dgvEmployees.Columns["RoleId"].Visible = false;

            // Đặt lại header text (nếu cần)
            if (dgvEmployees.Columns["NameEmployee"] != null)
                dgvEmployees.Columns["NameEmployee"].HeaderText = "Họ tên";

            if (dgvEmployees.Columns["Email"] != null)
                dgvEmployees.Columns["Email"].HeaderText = "Email";

            if (dgvEmployees.Columns["RoleName"] != null)
                dgvEmployees.Columns["RoleName"].HeaderText = "Chức vụ";

            if (dgvEmployees.Columns["IsActive"] != null)
                dgvEmployees.Columns["IsActive"].HeaderText = "Đang hoạt động";
        }

        // =====================================================================
        // 3. TÌM KIẾM NHÂN VIÊN
        // =====================================================================
        // Nút Search (nếu bạn có dùng)
        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            LoadEmployees(txtSearchEmployee.Text);
        }

        // Tìm kiếm real-time theo TextChanged
        private void txtSearchEmployee_TextChanged(object sender, EventArgs e)
        {
            LoadEmployees(txtSearchEmployee.Text);
        }

        // =====================================================================
        // 4. RELOAD & CLOSE
        // =====================================================================
        private void btnReloadEmployee_Click(object sender, EventArgs e)
        {
            txtSearchEmployee.Clear();
            LoadEmployees();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // =====================================================================
        // 5. VALIDATE DỮ LIỆU TẠO TÀI KHOẢN
        // =====================================================================
        private bool ValidateNewEmployee()
        {
            // ⚠️ Sửa bug: dùng TextBox, không dùng lblNameEmployee
            string name = txtNameEmployee.Text.Trim();
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

            if (cboRole.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chức vụ (role).",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // =====================================================================
        // 6. NÚT TẠO TÀI KHOẢN NHÂN VIÊN
        // =====================================================================
        private void btnCreateEmployee_Click(object sender, EventArgs e)
        {
            if (!ValidateNewEmployee())
                return;

            string name = txtNameEmployee.Text.Trim();
            string email = txtEmailEmployee.Text.Trim();
            string password = txtPasswordEmployee.Text;
            bool isActive = chkIsActive.Checked;
            int roleId = (int)cboRole.SelectedValue;

            // Gọi BLL để tạo nhân viên (đã hash mật khẩu bằng PBKDF2)
            string message = _employeeService.CreateEmployee(
                name, email, password, roleId, isActive);

            MessageBox.Show(message,
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

            // Nếu tạo thành công thì clear form + reload danh sách
            if (message.StartsWith("Tạo tài khoản nhân viên thành công"))
            {
                ClearNewEmployeeForm();
                LoadEmployees();
            }
        }

        // =====================================================================
        // 7. CLEAR FORM
        // =====================================================================
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
