
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanDoAnNhanh.BLL;
using QLBanDoAnNhanh.BLL.DTOs;

namespace QLBanDoAnNhanh
{
    public partial class frmAddItem : Form
    {
        private ProductService _productService;
        private TypeProductService _typeProductService; // <-- THÊM DÒNG NÀY
        private int _idEmployee;
        public frmAddItem(int idEmployee)
        {
            InitializeComponent();
            _productService = new ProductService();
            _typeProductService = new TypeProductService();
            _idEmployee = idEmployee;
        }

        private void frmAddItem_Load(object sender, EventArgs e)
        {
            var typeProduct = _typeProductService.GetActiveTypesOrdered();
            cbType.DataSource = typeProduct;
            cbType.DisplayMember = "NameType";
            cbType.ValueMember = "IdTypeProduct";
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.jpg; *.png; *.bmp)|*.jpg; *.png; *.bmp|All Files (*.*)|*.*";

                // 1. Lấy đường dẫn thư mục đang chạy file .exe
                string appPath = Application.StartupPath;

                // 2. Kết hợp với thư mục con 'Images'
                string imageFolderPath = System.IO.Path.Combine(appPath, "Data");

                // 3. Kiểm tra và tạo thư mục nếu nó chưa tồn tại
                if (!System.IO.Directory.Exists(imageFolderPath))
                {
                    System.IO.Directory.CreateDirectory(imageFolderPath);
                }

                // 4. Đặt thư mục mặc định cho dialog
                openFileDialog.InitialDirectory = imageFolderPath;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string imagePath = openFileDialog.FileName;
                    picProduct.Image = System.Drawing.Image.FromFile(imagePath);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 1. Thu thập dữ liệu từ Form và kiểm tra (giữ nguyên)
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                errorCheck.SetError(tbName, "Tên không được để trống!");
                return;
            }
            if (string.IsNullOrWhiteSpace(tbPrice.Text) || !decimal.TryParse(tbPrice.Text, out decimal price))
            {
                errorCheck.SetError(tbPrice, "Giá không hợp lệ!");
                return;
            }
            if (price <= 0)
            {
                errorCheck.SetError(tbPrice, "Giá tiền không được phép âm!");
                return;
            }
            if (picProduct.Image == null)
            {
                MessageBox.Show("Vui lòng chọn hình ảnh cho sản phẩm.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo đối tượng ProductDto (Không phải Product cũ)
            var productDto = new ProductDto // <-- SỬA 1: Đổi tên class
            {
                NameProduct = tbName.Text.Trim(),
                PriceProduct = price,
                Descriptions = tbDecript.Text.Trim(),
                IdTypeProduct = (int)cbType.SelectedValue,
                CreatedBy = _idEmployee, // <-- SỬA 2: Đổi "IdEmployee" thành "CreatedBy"
                IsActive = true
            };

            // Chuyển đổi hình ảnh thành byte array
            using (var ms = new System.IO.MemoryStream())
            {
                picProduct.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                productDto.Images = ms.ToArray();
            }

            // 3. Gọi xuống BLL (BLL đã sẵn sàng nhận DTO)
            bool success = _productService.CreateProduct(productDto);

            // 4. Xử lý kết quả trả về
            if (success)
            {
                MessageBox.Show("Thêm sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Báo cho form chính biết để tải lại danh sách
                this.Close();
            }
            else
            {
                // Lỗi có thể do tên trùng lặp (UNIQUE constraint)
                MessageBox.Show("Thêm sản phẩm thất bại. Tên sản phẩm có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbName.Text))
            {
                errorCheck.SetError(tbName, "Cannot empty!");
            }
            else
            {
                errorCheck.SetError(tbName, "");
            }
        }

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPrice.Text))
            {
                errorCheck.SetError(tbPrice, "Cannot empty!");
            }
            else if (decimal.TryParse(tbPrice.Text, out _) == false)
            {
                errorCheck.SetError(tbPrice, "Only number!");
            }
            else
            {
                errorCheck.SetError(tbPrice, "");
            }
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                btnAdd.PerformClick();
            }
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                btnAdd.PerformClick();
            }
        }
    }
}
