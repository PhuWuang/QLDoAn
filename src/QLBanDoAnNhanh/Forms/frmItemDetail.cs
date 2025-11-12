using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL;
using QLBanDoAnNhanh.BLL.DTOs; // Đảm bảo đã có
using System.Globalization;     // Đảm bảo đã có

namespace QLBanDoAnNhanh
{
    public partial class frmItemDetail : Form
    {
        private int _idProduct;
        private int _idEmployee;
        private ProductService _productService;
        private EmployeeService _employeeService;

        // THÊM: Lưu DTO lại để dùng chung
        private ProductDto _currentProduct;
        private CultureInfo _culture = new CultureInfo("vi-VN"); // Dùng chung

        public frmItemDetail(int idProduct, int idEmployee)
        {
            InitializeComponent();
            _idProduct = idProduct;
            _idEmployee = idEmployee;
            _productService = new ProductService();
            _employeeService = new EmployeeService();
        }

        private void frmItemDetail_Load(object sender, EventArgs e)
        {
            // 1. Lấy DTO từ BLL
            _currentProduct = _productService.GetById(_idProduct);

            if (_currentProduct != null)
            {
                // 2. Hiển thị hình ảnh (nếu có)
                if (_currentProduct.Images != null && _currentProduct.Images.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(_currentProduct.Images))
                    {
                        picItem.Image = Image.FromStream(ms);
                    }
                }

                // 3. Hiển thị thông tin
                lbName.Text = _currentProduct.NameProduct;

                // SỬA LỖI 1: Bỏ ".Value" và đổi sang "VNĐ"
                lbPrice.Text = _currentProduct.PriceProduct.ToString("N0", _culture) + " VNĐ";

                lbDecript.Text = string.IsNullOrEmpty(_currentProduct.Descriptions)
                                    ? "N/A"
                                    : _currentProduct.Descriptions;

                // Cập nhật trạng thái nút
                btnSoldOut.Text = _currentProduct.IsActive ? "Sold Out" : "UnSold";
            }
        }

        private void btnSoldOut_Click(object sender, EventArgs e)
        {
            // SỬA LỖI 2: Gọi đúng hàm nghiệp vụ của BLL

            // 1. Gọi BLL
            bool success = _productService.ToggleActive(_idProduct);

            // 2. Xử lý kết quả
            if (success && _currentProduct != null)
            {
                // 3. Cập nhật trạng thái (local) mà không cần gọi DB
                _currentProduct.IsActive = !_currentProduct.IsActive;
                btnSoldOut.Text = _currentProduct.IsActive ? "Sold Out" : "UnSold";
                MessageBox.Show("Cập nhật trạng thái thành công.", "Thông báo");
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại.", "Lỗi");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Form frmedit = new frmEditItem(_idProduct);
            frmedit.ShowDialog();

            // Tải lại dữ liệu sau khi Form Edit đóng
            frmItemDetail_Load(sender, e);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra quyền admin
            var employee = _employeeService.GetEmployeeById(_idEmployee);

            // SỬA LỖI 3: Kiểm tra bằng RoleName (từ DTO)
            if (employee == null || employee.RoleName != "Admin")
            {
                MessageBox.Show("Chỉ có tài khoản quản lý (Admin) mới có thể xóa sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Hiển thị hộp thoại xác nhận (Giữ nguyên)
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?",
                                                 "Xác nhận xóa",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // 3. Gọi xuống BLL (Giữ nguyên - code này đã đúng)
                var productService = new ProductService();
                string result = productService.DeleteProduct(_idProduct);

                // 4. Xử lý kết quả trả về (Giữ nguyên - code này đã đúng)
                switch (result)
                {
                    case "Deleted":
                        MessageBox.Show("Đã xóa vĩnh viễn sản phẩm.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Báo cho frmMain biết để tải lại
                        this.Close();
                        break;
                    case "Deactivated":
                        MessageBox.Show("Sản phẩm này đã tồn tại trong hóa đơn nên đã được ẩn đi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK; // Báo cho frmMain biết để tải lại
                        this.Close();
                        break;
                    case "NotFound":
                        MessageBox.Show("Không tìm thấy sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default: // "Error"
                        MessageBox.Show("Đã có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
            }
        }
    }
}