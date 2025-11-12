using QLBanDoAnNhanh.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using QLBanDoAnNhanh.BLL; // Để sử dụng EmployeeService

namespace QLBanDoAnNhanh
{
    public partial class frmlogin : Form
    {
        public bool Valid { get; set; } = false;
        public frmlogin()
        {
            InitializeComponent();
        }

        private void frmlogin_Load(object sender, EventArgs e)
        {
            tbPass.PasswordChar = '*';
            
        }

        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {

            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.\w{2,3})+)$";
            Regex regex = new Regex(pattern);
            if (string.IsNullOrEmpty(tbEmail.Text))
            {
                errorCheck.SetError(tbEmail, "Cannot empty!");
            }
            else if (regex.IsMatch(tbEmail.Text) == false)
            {
                errorCheck.SetError(tbEmail, "Not formating email!");
            }
            else
            {
                errorCheck.SetError(tbEmail, "");
            }
        }

        private void tbPass_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPass.Text))
            {
                errorCheck.SetError(tbPass, "Cannot empty!");
            }
            else
            {
                errorCheck.SetError(tbPass, "");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = tbEmail.Text.Trim();
            string password = tbPass.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập email và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Gọi EmployeeService (đã sửa ở Bước 4)
            var empService = new EmployeeService();
            var loginResult = empService.ValidateLogin(email, password);

            // 2. Kiểm tra kết quả trả về từ BLL
            if (loginResult.Success)
            {
                // 3. ĐĂNG NHẬP THÀNH CÔNG
                // Lấy EmployeeDto từ kết quả
                EmployeeDto userDto = loginResult.Employee;

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4. Mở frmMain và truyền EmployeeDto (không phải Employee cũ)
                frmMain f = new frmMain(userDto, this); // Dòng này sẽ báo lỗi, ta sẽ sửa frmMain ở bước sau
                f.Show();
                this.Hide();
            }
            else
            {
                // 5. ĐĂNG NHẬP THẤT BẠI
                MessageBox.Show(loginResult.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void tbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void picShowHide_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu đang bị che hay không
            if (tbPass.PasswordChar == '*')
            {
                // Nếu đang bị che, thì hiện nó ra
                tbPass.PasswordChar = '\0'; // Ký tự null sẽ hiển thị text bình thường

                // Đổi ảnh của PictureBox thành con mắt bị gạch chéo
                picShowHide.Image = Properties.Resources.eye_slash; // <-- THAY BẰNG TÊN ẢNH CON MẮT GẠCH CHÉO
            }
            else
            {
                // Nếu đang hiện, thì che nó đi
                tbPass.PasswordChar = '*';

                // Đổi ảnh của PictureBox về con mắt mở
                picShowHide.Image = Properties.Resources.eye_open; // <-- THAY BẰNG TÊN ẢNH CON MẮT MỞ
            }
        }
    }
}

