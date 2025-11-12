using QLBanDoAnNhanh.Models;
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

namespace QLBanDoAnNhanh
{
    public partial class frmEditItem : Form
    {
        private ProductService _productService;
        private int _idProduct;
        private bool _isImageChanged = false;
        public frmEditItem(int idProduct)
        {
            InitializeComponent();
            _idProduct = idProduct;
            _productService = new ProductService();
        }

        private void frmEditItem_Load(object sender, EventArgs e)
        {
            var typeProduct = _productService.GetAllTypes();
            cbType.DataSource = typeProduct;
            cbType.DisplayMember = "NameType";
            cbType.ValueMember = "IdTypeProduct";
            var productFood = _productService.GetById(_idProduct);
            if (productFood != null)
            {
                cbType.SelectedValue = productFood.IdTypeProduct;
                tbName.Text = productFood.NameProduct;
                tbPrice.Text = productFood.PriceProduct.Value.ToString("0.0");
                if (string.IsNullOrEmpty(productFood.Descriptions) == true)
                {
                    tbDecript.Text = "N/A";
                }
                else
                {
                    tbDecript.Text = productFood.Descriptions;
                }
                using (MemoryStream ms = new MemoryStream(productFood.Images))
                {
                    Image image = Image.FromStream(ms);
                    picProduct.Image = image;
                }
            }
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

                    // Báo cho Form biết rằng ảnh đã bị thay đổi
                    _isImageChanged = true;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // === BỔ SUNG ĐOẠN KIỂM TRA DỮ LIỆU ===
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbName.Focus(); // Đưa con trỏ chuột về ô nhập tên
                return; // Dừng lại, không thực hiện tiếp
            }
            if (string.IsNullOrWhiteSpace(tbPrice.Text) || !decimal.TryParse(tbPrice.Text, out _))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPrice.Focus(); // Đưa con trỏ chuột về ô nhập giá
                return; // Dừng lại
            }
            if (decimal.TryParse(tbPrice.Text, out decimal price) && price <= 0)
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbPrice.Focus();
                return;
            }
            // =======================================
            // 1. Khởi tạo BLL

            // 2. Lấy đối tượng Product hiện tại từ CSDL
            var productToUpdate = _productService.GetById(_idProduct);
            if (productToUpdate == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Cập nhật các thuộc tính của đối tượng với dữ liệu mới từ Form
            productToUpdate.NameProduct = tbName.Text.Trim();
            productToUpdate.PriceProduct = decimal.Parse(tbPrice.Text);
            productToUpdate.Descriptions = tbDecript.Text.Trim();
            productToUpdate.IdTypeProduct = (int)cbType.SelectedValue;

            // Chỉ cập nhật hình ảnh NẾU người dùng đã tải lên ảnh mới
            if (_isImageChanged)
            {
                using (var ms = new System.IO.MemoryStream())
                {
                    picProduct.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    productToUpdate.Images = ms.ToArray();
                }
            }

            // 4. Gọi xuống BLL để thực hiện cập nhật
            bool success = _productService.UpdateProduct(productToUpdate);

            // 5. Xử lý kết quả
            if (success)
            {
                MessageBox.Show("Cập nhật sản phẩm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại. Tên sản phẩm có thể đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                btnUpdate.PerformClick();
            }
        }

        private void tbPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter))
            {
                btnUpdate.PerformClick();
            }
        }
    }
}
