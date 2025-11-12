
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL;

namespace QLBanDoAnNhanh
{
    public partial class frmChangePass : Form
    {
        private int _idEmployee;
        public frmChangePass(int idEmployee)
        {
            InitializeComponent();
            _idEmployee = idEmployee;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfr_Click(object sender, EventArgs e)
        {
            // 1. Input validation (Giữ nguyên)
            if (string.IsNullOrWhiteSpace(tbOldpass.Text) || string.IsNullOrWhiteSpace(tbNewpass.Text))
            {
                MessageBox.Show("Mật khẩu cũ và mới không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Gọi BLL
            var employeeService = new EmployeeService();

            // SỬA 1: BLL trả về string (thông báo), không phải bool
            string resultMessage = employeeService.ChangePassword(_idEmployee, tbOldpass.Text, tbNewpass.Text);

            // 3. Xử lý kết quả (string)
            if (resultMessage == "Đổi mật khẩu thành công.")
            {
                MessageBox.Show(resultMessage, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                // Hiển thị thông báo lỗi cụ thể từ BLL (ví dụ: "Mật khẩu cũ không đúng.")
                MessageBox.Show(resultMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void picShowHide2_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu đang bị che hay không
            if (tbOldpass.PasswordChar == '*')
            {
                // Nếu đang bị che, thì hiện nó ra
                tbOldpass.PasswordChar = '\0'; // Ký tự null sẽ hiển thị text bình thường

                // Đổi ảnh của PictureBox thành con mắt bị gạch chéo
                picShowHide2.Image = Properties.Resources.eye_slash; // <-- THAY BẰNG TÊN ẢNH CON MẮT GẠCH CHÉO
            }
            else
            {
                // Nếu đang hiện, thì che nó đi
                tbOldpass.PasswordChar = '*';

                // Đổi ảnh của PictureBox về con mắt mở
                picShowHide2.Image = Properties.Resources.eye_open; // <-- THAY BẰNG TÊN ẢNH CON MẮT MỞ
            }
        }

        private void picShowHide1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem mật khẩu đang bị che hay không
            if (tbNewpass.PasswordChar == '*')
            {
                // Nếu đang bị che, thì hiện nó ra
                tbNewpass.PasswordChar = '\0'; // Ký tự null sẽ hiển thị text bình thường

                // Đổi ảnh của PictureBox thành con mắt bị gạch chéo
                picShowHide1.Image = Properties.Resources.eye_slash; // <-- THAY BẰNG TÊN ẢNH CON MẮT GẠCH CHÉO
            }
            else
            {
                // Nếu đang hiện, thì che nó đi
                tbNewpass.PasswordChar = '*';

                // Đổi ảnh của PictureBox về con mắt mở
                picShowHide1.Image = Properties.Resources.eye_open; // <-- THAY BẰNG TÊN ẢNH CON MẮT MỞ
            }
        }
    }
}
