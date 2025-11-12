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
    public partial class frmMain : Form
    {
        private EmployeeService _employeeService;
        private int _idEmployee;
        private ItemOrder _itemOrder;
        private decimal _price = 0;
        private int _category = 1;

        private frmlogin _frmlogin = new frmlogin();
        public frmMain(int idEmployee, frmlogin frmlogin)
        {
            InitializeComponent();
            _idEmployee = idEmployee;
            _frmlogin = frmlogin;
            _employeeService = new EmployeeService();
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
            var emp = _employeeService.GetEmployeeById(_idEmployee);
            lbUser.Text = emp.NameEmployee;
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
            flpItems.Controls.Clear();
            // 1. Khởi tạo ProductService từ tầng BLL
            var productService = new ProductService();

            // 2. Gọi hàm để lấy danh sách sản phẩm thuộc loại "Foods" (có ID là 1)
            var productItems = productService.GetByTypeId(1);

            // 3. Vòng lặp để hiển thị sản phẩm lên giao diện (phần này giữ nguyên như cũ)
            foreach (var item in productItems)
            {
                // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                var itemProduct = new Item();

                // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                itemProduct.ID = item.IdProduct;
                itemProduct._Name = item.NameProduct;
                itemProduct.Price = (decimal)item.PriceProduct;
                itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            flpItems.Controls.Clear();
            var productService = new ProductService();

            var productItems = productService.GetByTypeId(2);

            foreach (var item in productItems)
            {
                // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                var itemProduct = new Item();

                // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                itemProduct.ID = item.IdProduct;
                itemProduct._Name = item.NameProduct;
                itemProduct.Price = (decimal)item.PriceProduct;
                itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            flpItems.Controls.Clear();
            var productService = new ProductService();

            var productItems = productService.GetByTypeId(3);

            foreach (var item in productItems)
            {
                // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                var itemProduct = new Item();

                // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                itemProduct.ID = item.IdProduct;
                itemProduct._Name = item.NameProduct;
                itemProduct.Price = (decimal)item.PriceProduct;
                itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            flpItems.Controls.Clear();
            var productService = new ProductService();

            var productItems = productService.GetByTypeId(4);

            foreach (var item in productItems)
            {
                // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                var itemProduct = new Item();

                // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                itemProduct.ID = item.IdProduct;
                itemProduct._Name = item.NameProduct;
                itemProduct.Price = (decimal)item.PriceProduct;
                itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            flpItems.Controls.Clear();
            var productService = new ProductService();

            var productItems = productService.GetByTypeId(5);

            foreach (var item in productItems)
            {
                // Tạo một biến mới chỉ tồn tại trong vòng lặp này
                var itemProduct = new Item();

                // Sử dụng biến "itemProduct" thay cho "_itemProduct"
                itemProduct.ID = item.IdProduct;
                itemProduct._Name = item.NameProduct;
                itemProduct.Price = (decimal)item.PriceProduct;
                itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            var employee = _employeeService.GetEmployeeById(_idEmployee);
            if (employee.IdRole == 1 || string.Compare(employee.RoleEmployee.NameRole, "admin", false) == 0)
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
            if (itemControl.IsValid == false && itemControl.IsActive == false)
            {
                _price = 0;
                itemControl.IsValid = true;
                _itemOrder = new ItemOrder();
                _itemOrder.ID = itemControl.ID;
                _itemOrder._Name = itemControl._Name;
                _itemOrder.Price = itemControl.Price;
                _itemOrder._Date = DateTime.Now.ToString();
                _itemOrder.Quantity = 1;
                _itemOrder.Image = itemControl.BackgroundImage;
                _itemOrder.LablePrice = itemControl.Price.ToString("0.00") + "$";
                _itemOrder.Tag = itemControl.ID;
                _itemOrder.upDown.ValueChanged += numQuantity_Valuechanged;
                flpOrder.Controls.Add(_itemOrder);
                foreach (Control control in flpOrder.Controls)
                {
                    if (control is ItemOrder itemOrder)
                    {
                        _price += (itemOrder.Price * itemOrder.Quantity);
                    }
                }
            }
            else
            {
                itemControl.IsValid = false;
                foreach (Control control in flpOrder.Controls)
                {
                    if (control is ItemOrder itemOrder)
                    {
                        if ((int)itemOrder.Tag == (int)itemControl.Tag)
                        {
                            _price -= (itemOrder.Price * itemOrder.Quantity);
                            flpOrder.Controls.Remove(itemOrder);
                        }
                    }
                }
            }
            lbVAT.Text = "+" + ((decimal)0.05 * _price).ToString("0.00") + "$";
            lbTotal.Text = _price.ToString("0.00") + "$";
            lbLastPrice.Text = (_price + ((decimal)0.05 * _price)).ToString("0.00") + "$";
        }
        private void numQuantity_Valuechanged(object sender, EventArgs e)
        {
            NumericUpDown upDown = sender as NumericUpDown;
            _price = 0;
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder)
                {
                    if ((int)itemOrder.Tag == (int)upDown.Parent.Tag)
                    {
                        itemOrder.Quantity = (int)upDown.Value;
                    }
                    _price += (itemOrder.Price * itemOrder.Quantity);
                    itemOrder.LablePrice = (itemOrder.Price * itemOrder.Quantity).ToString("0.00") + "$";

                }
            }
            lbVAT.Text = "+" + ((decimal)0.05 * _price).ToString("0.00") + "$";
            lbTotal.Text = _price.ToString("0.00") + "$";
            lbLastPrice.Text = (_price + ((decimal)0.05 * _price)).ToString("0.00") + "$";
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
                        itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
                    itemProduct.LablePrice = item.PriceProduct.Value.ToString("0.00") + "$";
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
            // Kiểm tra xem có món nào trong giỏ hàng không
            if (flpOrder.Controls.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 1. Chuẩn bị dữ liệu để gửi cho BLL
            var items = new Dictionary<int, int>();
            foreach (Control control in flpOrder.Controls)
            {
                if (control is ItemOrder itemOrder)
                {
                    items.Add(itemOrder.ID, itemOrder.Quantity);
                }
            }

            // 2. Gọi xuống BLL để xử lý
            var orderService = new OrderService();
            bool success = orderService.CreateOrder(_idEmployee, items);

            // 3. Xử lý kết quả trả về từ BLL
            if (success)
            {
                MessageBox.Show("Thanh toán thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Xóa giỏ hàng và reset giao diện sau khi thanh toán
                flpOrder.Controls.Clear();
                _price = 0;
                lbVAT.Text = "+0.00$";
                lbTotal.Text = "0.00$";
                lbLastPrice.Text = "0.00$";
                // Tải lại danh sách sản phẩm để cập nhật trạng thái
                frmMain_Load(sender, e);
            }
            else
            {
                MessageBox.Show("Đã có lỗi xảy ra trong quá trình thanh toán.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            printPreview.Document = printDocument;
            printPreview.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("FOODS HORI", new Font("Arial", 28, FontStyle.Bold), Brushes.Black, new Point(270, 10));
            e.Graphics.DrawString("Invoice", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new Point(350, 50));
            e.Graphics.DrawString("Phone: +84396531897", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 80));
            e.Graphics.DrawString("Email: foods-hori@gmail.com", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 110));
            e.Graphics.DrawString("Address: 449 Street, Tang Nhon Phu A Ward, Thu Đuc City", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 140));
            e.Graphics.DrawString("______________________________________________________________________________________________________________________________________________________", new Font("Arial", 13, FontStyle.Bold), Brushes.Black, new Point(0, 160));
            e.Graphics.DrawString("Date: " + DateTime.Now.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 190));
            e.Graphics.DrawString("Employee: ", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 220));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 250));
            e.Graphics.DrawString("Item", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, 280));
            e.Graphics.DrawString("Qty", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, 280));
            e.Graphics.DrawString("Price", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(450, 280));
            e.Graphics.DrawString("Amount", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, 280));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, 310));
            int y = 310;
            decimal price = 0;
            foreach (Control controlOrder in flpOrder.Controls)
            {
                if (controlOrder is ItemOrder order)
                {
                    e.Graphics.DrawString(order._Name, new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, y + 30));
                    e.Graphics.DrawString(order.Quantity.ToString(), new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(250, y + 30));
                    e.Graphics.DrawString(order.Price.ToString("0.00") + "$", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(450, y + 30));
                    e.Graphics.DrawString((order.Quantity * order.Price).ToString("0.00") + "$", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 30));
                    y += 30;
                    price += (order.Quantity * order.Price);
                }
            }
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------------------------------", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(50, y + 30));
            e.Graphics.DrawString("Bill toal", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(60, y + 60));
            e.Graphics.DrawString(_price.ToString("0.00") + "$", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 60));
            e.Graphics.DrawString("VAT(5%)", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(60, y + 90));
            e.Graphics.DrawString("+ " + ((decimal)0.05 * price).ToString("0.00") + "$", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, new Point(660, y + 90));
            e.Graphics.DrawString("Last bill", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(60, y + 120));
            e.Graphics.DrawString((((decimal)0.05 * _price) + _price).ToString("0.00") + "$", new Font("Arial", 13, FontStyle.Regular), Brushes.Black, new Point(660, y + 120));
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
    }
}
