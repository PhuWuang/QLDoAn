
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
using QLBanDoAnNhanh.BLL.DTOs;      // <-- THÊM
using QLBanDoAnNhanh.BLL;  // <-- THÊM
using System.Globalization;         // <-- THÊM (cho VNĐ)
using QLBanDoAnNhanh.Forms;

namespace QLBanDoAnNhanh
{
    public partial class frmMain : Form
    {
        private EmployeeService _employeeService;
        private ProductService _productService;     // <-- THÊM
        private TypeProductService _typeProductService; // <-- THÊM
        private int _idEmployee;
        private string _nameEmployee; // <-- THÊM MỚI
        private string _roleName;     // <-- THÊM MỚI
        private ItemOrder _itemOrder;
        private decimal _price = 0;
        private int _category = 1;

        private frmlogin _frmlogin = new frmlogin();
        public frmMain(EmployeeDto userDto, frmlogin frmlogin)
        {
            InitializeComponent();
            _frmlogin = frmlogin; // Giữ lại frmlogin

            // Khởi tạo các Service
            _employeeService = new EmployeeService();
            _productService = new ProductService();
            _typeProductService = new TypeProductService();

            // Lưu thông tin từ DTO (Giống code bạn đã làm)
            _idEmployee = userDto.IdEmployee;
            _nameEmployee = userDto.NameEmployee;
            _roleName = userDto.RoleName;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            flpOrder.Controls.Clear();
            switch (_category)
            {
                case 1:
                    btnFoods.PerformClick(); break;
                case 2:
                    btnDrink.PerformClick(); break;
                case 3:
                    btnSnack.PerformClick(); break;
                case 4:
                    btnDessert.PerformClick(); break;
                case 5:
                    btnCombo.PerformClick(); break;
            }
            // Chúng ta đã có tên từ DTO, không cần gọi GetById
            if (!string.IsNullOrEmpty(_nameEmployee))
            {
                lbUser.Text = _nameEmployee;
            }
            else
            {
                // Dự phòng nếu DTO không có tên (dù không nên xảy ra)
                var emp = _employeeService.GetEmployeeById(_idEmployee);
                lbUser.Text = emp?.NameEmployee ?? "User"; // Dùng "?." để tránh lỗi null
            }
        }

        private void btnFoods_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.FromArgb(179, 229, 252);
            btnFoods.FillColor2 = Color.FromArgb(187, 222, 251);
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            btnSetting.FillColor = Color.Transparent;
            btnSetting.FillColor2 = Color.Transparent;
            lbCategory.Text = "Foods";
            _category = 1;
            LoadProductsByType(1); // <-- CHỈ CẦN GỌI HÀM NÀY
        }

        private void btnDrink_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.FromArgb(179, 229, 252);
            btnDrink.FillColor2 = Color.FromArgb(187, 222, 251);
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            lbCategory.Text = "Drink";
            _category = 2;
            LoadProductsByType(2); // <-- CHỈ CẦN GỌI HÀM NÀY
        }

        private void btnSnack_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.FromArgb(179, 229, 252);
            btnSnack.FillColor2 = Color.FromArgb(187, 222, 251);
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            btnSetting.FillColor = Color.Transparent;
            btnSetting.FillColor2 = Color.Transparent;
            lbCategory.Text = "Snack";
            _category = 3;
            LoadProductsByType(3); // <-- CHỈ CẦN GỌI HÀM NÀY
        }

        private void btnDessert_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.FromArgb(179, 229, 252);
            btnDessert.FillColor2 = Color.FromArgb(187, 222, 251);
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            btnSetting.FillColor = Color.Transparent;
            btnSetting.FillColor2 = Color.Transparent;
            lbCategory.Text = "Dessert";
            _category = 4;
            LoadProductsByType(4); // <-- CHỈ CẦN GỌI HÀM NÀY
        }

        private void btnCombo_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.FromArgb(179, 229, 252);
            btnCombo.FillColor2 = Color.FromArgb(187, 222, 251);
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            btnSetting.FillColor = Color.Transparent;
            btnSetting.FillColor2 = Color.Transparent;
            lbCategory.Text = "Combo";
            _category = 5;
            LoadProductsByType(5); // <-- CHỈ CẦN GỌI HÀM NÀY
        }

        private void btnAdditem_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.FromArgb(179, 229, 252);
            btnAdditem.FillColor2 = Color.FromArgb(187, 222, 251);
            btnSetting.FillColor = Color.Transparent;
            btnSetting.FillColor2 = Color.Transparent;
            if (_roleName == "Admin")
            {
                Form form = new frmAddItem(_idEmployee);
                form.ShowDialog();
                switch (_category)
                {
                    case 1:
                        btnFoods.PerformClick(); break;
                    case 2:
                        btnDrink.PerformClick(); break;
                    case 3:
                        btnSnack.PerformClick(); break;
                    case 4:
                        btnDessert.PerformClick(); break;
                    case 5:
                        btnCombo.PerformClick(); break;
                }
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Please log in as a management account!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            Item itemControl = (Item)sender;
            var culture = new CultureInfo("vi-VN");

            // 1. Kiểm tra xem item này đã có trong giỏ hàng (flpOrder) chưa?
            ItemOrder existingOrder = null;
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder && (int)itemOrder.Tag == (int)itemControl.Tag)
                {
                    existingOrder = itemOrder; // Đã tìm thấy
                    break;
                }
            }

            // 2. Xử lý
            if (existingOrder == null)
            {
                // === THÊM MÓN MỚI VÀO GIỎ ===

                // Kiểm tra xem món có bị "Hết hàng" (IsActive=true) không
                // (Logic IsActive của bạn đang bị ngược, tôi sửa lại cho đúng)
                if (itemControl.IsActive == true)
                {
                    MessageBox.Show("Sản phẩm này đã hết hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                itemControl.IsValid = true; // Đánh dấu là đã chọn (để đổi màu)

                // Tạo một ItemOrder mới (dùng biến local, không dùng _itemOrder)
                var newItemOrder = new ItemOrder();
                newItemOrder.ID = itemControl.ID;
                newItemOrder._Name = itemControl._Name;
                newItemOrder.Price = itemControl.Price;
                newItemOrder._Date = DateTime.Now.ToString();
                newItemOrder.Quantity = 1;
                newItemOrder.Image = itemControl.BackgroundImage;

                // SỬA LỖI TIỀN TỆ: Dùng "N0" và "VNĐ"
                newItemOrder.LablePrice = itemControl.Price.ToString("N0", culture) + " VNĐ";

                newItemOrder.Tag = itemControl.ID;
                newItemOrder.upDown.ValueChanged += numQuantity_Valuechanged;

                flpOrder.Controls.Add(newItemOrder);
            }
            else
            {
                // === XÓA MÓN KHỎI GIỎ ===
                itemControl.IsValid = false; // Đánh dấu là đã bỏ chọn
                flpOrder.Controls.Remove(existingOrder);
                //        existingOrder.Dispose(); // (Tùy chọn: giải phóng bộ nhớ)
            }

            // 3. Cuối cùng, gọi hàm tính tổng 1 LẦN DUY NHẤT
            UpdateTotals();
        }
        private void numQuantity_Valuechanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = sender as NumericUpDown;

            // Tìm ItemOrder cha và cập nhật Quantity
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder)
                {
                    if ((int)itemOrder.Tag == (int)upDown.Parent.Tag)
                    {
                        itemOrder.Quantity = (int)upDown.Value;
                        break; // Tìm thấy, thoát vòng lặp
                    }
                }
            }

            // Gọi hàm tính toán tổng (đã làm ở Bước 1)
            UpdateTotals();
        }
        private void CheckItemInOrder()
        {
            foreach (Control controlItem in flpItems.Controls)
            {
                if (controlItem is Item item)
                {
                    foreach (Control controlItemOrder in flpOrder.Controls)
                    {
                        if (controlItemOrder is ItemOrder itemOrder)
                        {
                            if ((int)item.Tag == (int)itemOrder.Tag)
                            {
                                item.IsValid = true;
                            }
                        }
                    }
                }
            }
        }
        private void Item_RightClick(object sender, MouseEventArgs e)
        {
            Item itemProduct = (Item)sender;
            if (e.Button == MouseButtons.Right)
            {
                Form form = new frmItemDetail((int)itemProduct.ID, _idEmployee);
                form.ShowDialog();
                switch (_category)
                {
                    case 1:
                        btnFoods.PerformClick(); break;
                    case 2:
                        btnDrink.PerformClick(); break;
                    case 3:
                        btnSnack.PerformClick(); break;
                    case 4:
                        btnDessert.PerformClick(); break;
                    case 5:
                        btnCombo.PerformClick(); break;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // --- PHẦN CODE MỚI ---
                var productService = new ProductService();
                var productItem = productService.SearchByNameAndTypeId(txtSearch.Text.Trim(), _category);
                // ----------------------

                if (productItem.Count > 0)
                {
                    flpItems.Controls.Clear();
                    // Đoạn code vòng lặp foreach để hiển thị sản phẩm giữ nguyên như cũ
                    foreach (var item in productItem)
                    {
                        // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                        var itemProduct = new Item();

                        // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                        itemProduct.ID = item.IdProduct;
                        itemProduct._Name = item.NameProduct;
                        itemProduct.Price = (decimal)item.PriceProduct;
                        itemProduct.LablePrice = item.PriceProduct.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
                        if (item.IsActive == true)
                        {
                            itemProduct.IsActive = false;
                        }
                        else
                        {
                            itemProduct.IsActive = true;
                        }
                        using (MemoryStream ms = new MemoryStream(item.Images))
                        {
                            Image image = Image.FromStream(ms);
                            itemProduct.BackgroundImage = image;
                        }
                        itemProduct.Tag = item.IdProduct;
                        itemProduct.Click += new System.EventHandler(this.Item_Click);
                        itemProduct.MouseDown += Item_RightClick;
                        flpItems.Controls.Add(itemProduct);
                        CheckItemInOrder();
                    }
                }
                else
                {
                    switch (_category)
                    {
                        case 1:
                            btnFoods.PerformClick(); break;
                        case 2:
                            btnDrink.PerformClick(); break;
                        case 3:
                            btnSnack.PerformClick(); break;
                        case 4:
                            btnDessert.PerformClick(); break;
                        case 5:
                            btnCombo.PerformClick(); break;
                    }
                    DialogResult dialog = MessageBox.Show("Can't find this item!");
                }
            }
        }

        private void picSearch_Click(object sender, EventArgs e)
        {
            // --- PHẦN CODE MỚI ---
            var productService = new ProductService();
            var productItem = productService.SearchByNameAndTypeId(txtSearch.Text.Trim(), _category);
            // ----------------------

            if (productItem.Count > 0)
            {
                flpItems.Controls.Clear();
                // Đoạn code vòng lặp foreach để hiển thị sản phẩm giữ nguyên như cũ
                foreach (var item in productItem)
                {
                    // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                    var itemProduct = new Item();

                    // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                    itemProduct.ID = item.IdProduct;
                    itemProduct._Name = item.NameProduct;
                    itemProduct.Price = (decimal)item.PriceProduct;
                    itemProduct.LablePrice = item.PriceProduct.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";
                    if (item.IsActive == true)
                    {
                        itemProduct.IsActive = false;
                    }
                    else
                    {
                        itemProduct.IsActive = true;
                    }
                    using (MemoryStream ms = new MemoryStream(item.Images))
                    {
                        Image image = Image.FromStream(ms);
                        itemProduct.BackgroundImage = image;
                    }
                    itemProduct.Tag = item.IdProduct;
                    itemProduct.Click += new System.EventHandler(this.Item_Click);
                    itemProduct.MouseDown += Item_RightClick;
                    flpItems.Controls.Add(itemProduct);
                    CheckItemInOrder();
                }
            }
            else
            {
                switch (_category)
                {
                    case 1:
                        btnFoods.PerformClick(); break;
                    case 2:
                        btnDrink.PerformClick(); break;
                    case 3:
                        btnSnack.PerformClick(); break;
                    case 4:
                        btnDessert.PerformClick(); break;
                    case 5:
                        btnCombo.PerformClick(); break;
                }
                DialogResult dialog = MessageBox.Show("Can't find this item!");
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (flpOrder.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. Chuẩn bị dữ liệu (SỬA LỖI)
            // BLL cần Dictionary<int, (int qty, decimal price)>
            var items = new Dictionary<int, (int qty, decimal price)>();
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder)
                {
                    // Thêm (qty, price)
                    items.Add(itemOrder.ID, (itemOrder.Quantity, itemOrder.Price));
                }
            }

            // 2. Gọi BLL (hàm mới đã sẵn sàng)
            var orderService = new OrderService();
            try
            {
                OrderDto newOrder = orderService.CreateOrder(_idEmployee, items); // BLL trả về DTO

                // 3. Xử lý kết quả
                MessageBox.Show($"Thanh toán thành công! Mã hóa đơn: {newOrder.IdOrder}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                flpOrder.Controls.Clear();
                _price = 0;
                // Sửa $ -> VNĐ
                lbVAT.Text = "+0 VNĐ";
                lbTotal.Text = "0 VNĐ";
                lbLastPrice.Text = "0 VNĐ";
                frmMain_Load(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            _frmlogin.Show();
            this.Close();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            guna2ControlBox1.PerformClick();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            btnFoods.FillColor = Color.Transparent;
            btnFoods.FillColor2 = Color.Transparent;
            btnDrink.FillColor = Color.Transparent;
            btnDrink.FillColor2 = Color.Transparent;
            btnSnack.FillColor = Color.Transparent;
            btnSnack.FillColor2 = Color.Transparent;
            btnDessert.FillColor = Color.Transparent;
            btnDessert.FillColor2 = Color.Transparent;
            btnCombo.FillColor = Color.Transparent;
            btnCombo.FillColor2 = Color.Transparent;
            btnAdditem.FillColor = Color.Transparent;
            btnAdditem.FillColor2 = Color.Transparent;
            btnSetting.FillColor = Color.FromArgb(179, 229, 252);
            btnSetting.FillColor2 = Color.FromArgb(187, 222, 251);
            Form frmchangePass = new frmChangePass(_idEmployee);
            frmchangePass.ShowDialog();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            var items = new List<InvoiceLineVM>();
            foreach (Control c in flpOrder.Controls)
            {
                if (c is ItemOrder it)
                {
                    items.Add(new InvoiceLineVM
                    {
                        Item = it._Name,
                        Qty = it.Quantity,
                        Price = it.Price
                    });
                }
            }

            var header = new InvoiceHeaderVM
            {
                StoreName = "FOODS HORI",
                Phone = "+84396531897",
                Email = "foods-hori@gmail.com",
                Address = "449 Street, Tang Nhon Phu A Ward, Thu Đức City",
                Employee = _nameEmployee,       // biến bạn đã có
                PrintedAt = DateTime.Now,
                VATRate = 0.05m                 // 5%
            };

            using (var f = new frmReport_InvoiceDetail(items, header))
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // THÊM: Dùng văn hóa "vi-VN" để định dạng tiền
            var culture = new CultureInfo("vi-VN");

            // === PHẦN TIÊU ĐỀ (HEADER) ===
            e.Graphics.DrawString("FOODS HORI", new Font("Arial", 28, FontStyle.Bold), Brushes.Black, new Point(270, 10));
            e.Graphics.DrawString("Invoice", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(350, 50));
            e.Graphics.DrawString("Phone: +84396531897", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 80));
            e.Graphics.DrawString("Email: foods-hori@gmail.com", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 110));
            e.Graphics.DrawString("Address: 449 Street, Tang Nhon Phu A Ward, Thu Đuc City", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 140));
            e.Graphics.DrawString("______________________________________________________________________________________________________________________________________________________", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Point(0, 160));

            e.Graphics.DrawString("Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 190));

            // SỬA LỖI 3: In tên nhân viên (lấy từ biến đã lưu khi login)
            e.Graphics.DrawString("Employee: " + _nameEmployee, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 220));

            // === PHẦN CHI TIẾT HÓA ĐƠN (BODY) ===
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 250));
            e.Graphics.DrawString("Item", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, 280));
            e.Graphics.DrawString("Qty", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, 280));
            e.Graphics.DrawString("Price", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(450, 280));
            e.Graphics.DrawString("Amount", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, 280));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 310));

            int y = 310;
            decimal subTotal = 0; // SỬA LỖI 2: Dùng 1 biến local duy nhất

            foreach (Control controlOrder in flpOrder.Controls)
            {
                if (controlOrder is ItemOrder order)
                {
                    e.Graphics.DrawString(order._Name, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, y + 30));
                    e.Graphics.DrawString(order.Quantity.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, y + 30));

                    // SỬA LỖI 1: Dùng "N0" và "VNĐ"
                    e.Graphics.DrawString(order.Price.ToString("N0", culture) + " VNĐ", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(450, y + 30));
                    e.Graphics.DrawString((order.Quantity * order.Price).ToString("N0", culture) + " VNĐ", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 30));

                    y += 30;
                    subTotal += (order.Quantity * order.Price); // Luôn dùng biến local
                }
            }

            // === PHẦN TỔNG CỘNG (FOOTER) ===
            // SỬA LỖI 2: Tính toán dựa trên biến local
            decimal vatAmount = (decimal)0.05 * subTotal;
            decimal lastPrice = subTotal + vatAmount;

            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, y + 30));

            e.Graphics.DrawString("Bill total", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, y + 60));
            e.Graphics.DrawString(subTotal.ToString("N0", culture) + " VNĐ", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 60));

            e.Graphics.DrawString("VAT(5%)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, y + 90));
            e.Graphics.DrawString("+ " + vatAmount.ToString("N0", culture) + " VNĐ", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, y + 90));

            e.Graphics.DrawString("Last bill", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(60, y + 120));
            e.Graphics.DrawString(lastPrice.ToString("N0", culture) + " VNĐ", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 120));
        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {
            frmInvoiceList invoiceForm = new frmInvoiceList();
            invoiceForm.ShowDialog();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            frmStatistics statsForm = new frmStatistics();
            statsForm.ShowDialog();
        }
        // HÀM DÙNG CHUNG MỚI
        private void LoadProductsByType(int typeId)
        {
            flpItems.Controls.Clear();

            // 1. Gọi BLL (đã dùng DTO)
            var productItems = _productService.GetByTypeId(typeId);

            // 2. Vòng lặp để hiển thị (Sửa lỗi .Value và tiền tệ)
            foreach (var itemDto in productItems) // <-- Dùng DTO
            {
                var itemProduct = new Item();

                itemProduct.ID = itemDto.IdProduct;
                itemProduct._Name = itemDto.NameProduct;
                itemProduct.Price = (decimal)itemDto.PriceProduct;

                // SỬA LỖI .Value và "$":
                itemProduct.LablePrice = itemDto.PriceProduct.ToString("N0", new CultureInfo("vi-VN")) + " VNĐ";

                // SỬA LOGIC IsActive (Nếu IsActive = false là Hết hàng)
                itemProduct.IsActive = !itemDto.IsActive; // Nếu IsActive=false -> Hết hàng (IsActive=true)

                if (itemDto.Images != null && itemDto.Images.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(itemDto.Images))
                    {
                        Image image = Image.FromStream(ms);
                        itemProduct.BackgroundImage = image;
                    }
                }

                itemProduct.Tag = itemDto.IdProduct;
                itemProduct.Click += new System.EventHandler(this.Item_Click);
                itemProduct.MouseDown += Item_RightClick;
                flpItems.Controls.Add(itemProduct);
            }
            CheckItemInOrder();
        }
        // THÊM HÀM MỚI NÀY VÀO
        private void UpdateTotals()
        {
            // Dùng văn hóa Việt Nam để định dạng tiền
            var culture = new CultureInfo("vi-VN");
            decimal currentTotal = 0;

            // Lặp qua giỏ hàng
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder)
                {
                    // Tự cập nhật lại giá tiền của chính item trong giỏ
                    itemOrder.LablePrice = (itemOrder.Price * itemOrder.Quantity).ToString("N0", culture) + " VNĐ";

                    // Cộng dồn vào tổng tiền
                    currentTotal += (itemOrder.Price * itemOrder.Quantity);
                }
            }

            // Cập nhật biến _price (nếu bạn vẫn cần)
            _price = currentTotal;

            // Tính toán VAT và Tổng cuối
            decimal vat = (decimal)0.05 * _price;
            decimal lastPrice = _price + vat;

            // Cập nhật 3 Labeel tổng
            lbVAT.Text = "+ " + vat.ToString("N0", culture) + " VNĐ";
            lbTotal.Text = _price.ToString("N0", culture) + " VNĐ";
            lbLastPrice.Text = lastPrice.ToString("N0", culture) + " VNĐ";
        }

        private void guna2GradientTileButton2_Click(object sender, EventArgs e)
        {
            using (var f = new frmReport_TopProducts())
            {
                f.ShowDialog();   // mở dạng dialog, đóng lại thì quay về form chính
            }
        }
    }
}
