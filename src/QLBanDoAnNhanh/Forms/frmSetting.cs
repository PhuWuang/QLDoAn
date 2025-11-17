using System;
using System.Windows.Forms;
using QLBanDoAnNhanh;           // để gọi frmChangePass (namespace gốc)
using QLBanDoAnNhanh.Forms;     // nếu cần gọi frmEmployee cùng namespace

namespace QLBanDoAnNhanh.Forms
{
    public partial class frmSetting : Form
    {
        private int _idEmployee;
        private string _roleName;

        public frmSetting(int idEmployee, string roleName)
        {
            InitializeComponent();
            _idEmployee = idEmployee;
            _roleName = roleName;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            // Nếu không phải Admin thì ẩn luôn nút quản lí nhân viên
            if (_roleName != "Admin")
            {
                btnManageEmployee.Visible = false;
            }
        }

        // Option 1: Đổi mật khẩu
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            using (var f = new frmChangePass(_idEmployee))
            {
                f.ShowDialog();
            }
        }

        // Option 2: Vào form quản lí tài khoản nhân viên
        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            if (_roleName != "Admin")
            {
                MessageBox.Show("Bạn không có quyền truy cập chức năng này.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (var f = new frmEmployee())   // frmEmployee bạn đã tạo
            {
                f.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
