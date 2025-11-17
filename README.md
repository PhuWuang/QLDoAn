# 🍔 PosFastFoods - Hệ thống Quản lý Cửa hàng Thức ăn nhanh

![Status](https://img.shields.io/badge/Status-Completed-success)
![Platform](https://img.shields.io/badge/Platform-Windows-blue)
![Framework](https://img.shields.io/badge/.NET-4.7.2-purple)

**PosFastFoods** là phần mềm quản lý bán hàng (POS) dành cho các cửa hàng thức ăn nhanh, được xây dựng bằng **C# WinForms**. Dự án tập trung vào giao diện hiện đại, trải nghiệm người dùng mượt mà và khả năng báo cáo chi tiết.

---

## 📖 Giới thiệu

Dự án được phát triển như một đồ án kết thúc học phần **Lập Trình Trên Windows**, Khoa CNTT, Trường Đại học Sư phạm TP.HCM.

### 🌟 Điểm nổi bật
* **Giao diện hiện đại:** Sử dụng thư viện **Guna UI2** để thiết kế giao diện phẳng, đẹp mắt.
* **Dữ liệu thời gian thực:** Sử dụng **LINQ to SQL** để tương tác dữ liệu nhanh chóng.
* **Báo cáo chuyên nghiệp:** Tích hợp **Microsoft RDLC Report** để xuất hóa đơn và báo cáo doanh thu.

---

## 🛠 Công nghệ sử dụng

| Thành phần | Công nghệ / Thư viện |
| :--- | :--- |
| **Ngôn ngữ** | C# |
| **Nền tảng** | .NET Framework 4.7.2 (WinForms) |
| **Cơ sở dữ liệu** | SQL Server 2014+ |
| **Truy vấn (ORM)** | LINQ to SQL |
| **Giao diện (UI)** | [Guna.UI2.WinForms](https://guna.ui/) (v2.0.4.6) |
| **Báo cáo** | Microsoft RDLC Report |

---

## 🧩 Chức năng chính

### 🔐 Hệ thống
- [x] **Đăng nhập/Đăng xuất:** Phân quyền theo vai trò (Admin/Nhân viên).
- [x] **Đổi mật khẩu:** Nhân viên tự cập nhật thông tin bảo mật.
- [x] **Màn hình chính (Dashboard):** Tổng quan các lối tắt chức năng.

### 🛒 Bán hàng (POS)
- [x] **Gọi món (Order):** Chọn món trực quan qua hình ảnh (Burger, Combo, Đồ uống...).
- [x] **Xử lý đơn hàng:**
    - Thêm/bớt số lượng món.
    - Tính tổng tiền tự động.
    - In hóa đơn thanh toán (`rptInvoiceDetail`).
- [x] **Lịch sử hóa đơn:** Xem lại danh sách các hóa đơn đã lập.

### 🧑‍💼 Quản lý (Admin)
- [x] **Quản lý Nhân viên:** Thêm, xóa, sửa thông tin nhân viên và phân quyền.
- [x] **Quản lý Sản phẩm:**
    - Cập nhật thực đơn, giá bán.
    - Phân loại sản phẩm (TypeProduct).
    - Quản lý hình ảnh món ăn.
- [x] **Thống kê & Báo cáo:**
    - Biểu đồ thống kê doanh thu (`frmStatistics`).
    - Báo cáo doanh thu theo khoảng thời gian (`rptInvoiceByDate`).
    - Báo cáo Top sản phẩm bán chạy (`rptTopProducts`).

---

## 🗄 Thiết kế Cơ sở dữ liệu

Database **PosFastFoods** bao gồm các bảng chính:

1.  **`RoleEmployee`**: Quản lý quyền hạn (Admin/Staff).
2.  **`Employee`**: Thông tin nhân viên & tài khoản.
3.  **`TypeProduct`**: Danh mục loại sản phẩm (Food, Drink, Combo...).
4.  **`Product`**: Thông tin chi tiết món ăn (Tên, Giá, Ảnh, Mô tả).
5.  **`Orders`**: Thông tin hóa đơn bán hàng.
6.  **`OrderDetail`**: Chi tiết các món trong từng hóa đơn.

---

## ⚙️ Hướng dẫn Cài đặt

Để chạy được dự án trên máy cá nhân, vui lòng làm theo các bước sau:

### Yêu cầu
* Visual Studio 2019 hoặc 2022.
* SQL Server (mọi phiên bản).
* .NET Framework 4.7.2.

### Các bước thực hiện

1.  **Clone dự án:**
    ```bash
    git clone [https://github.com/PhuWuang/QLDoAn.git](https://github.com/PhuWuang/QLDoAn.git)
    ```

2.  **Cài đặt Database:**
    * Mở SQL Server Management Studio (SSMS).
    * Mở file `PosFastFoods.sql` (trong thư mục gốc).
    * Nhấn **Execute** (F5) để tạo database và bảng.

3.  **Cấu hình kết nối:**
    * Mở file `App.config` trong project `QLBanDoAnNhanh.DAL` (hoặc `src/QLBanDoAnNhanh`).
    * Tìm dòng `connectionString` và sửa lại `Data Source` thành tên Server của bạn:
    ```xml
    <add name="PosFastFoodsConnectionString"
         connectionString="Data Source=TEN_MAY_CUA_BAN;Initial Catalog=PosFastFoods;Integrated Security=True"
         providerName="System.Data.SqlClient" />
    ```

4.  **Chạy chương trình:**
    * Mở file `QLBanDoAnNhanh.sln` bằng Visual Studio.
    * Nhấn **Start** để chạy.
    * *Tài khoản mặc định (nếu có trong script SQL): `admin` / `admin` (hoặc kiểm tra bảng Employee).*

---

## 📸 Hình ảnh Demo

*(Dán các hình ảnh chụp màn hình phần mềm của bạn vào đây)*

| Màn hình Đăng nhập | Màn hình Bán hàng |
| :---: | :---: |
| ![Login](link_anh_1) | ![POS](link_anh_2) |

| Quản lý Sản phẩm | Báo cáo Thống kê |
| :---: | :---: |
| ![Product](link_anh_3) | ![Report](link_anh_4) |

---

## 👥 Tác giả

* **Nhom 3** - *LTW*

---

**PosFastFoods** © 2025 - Được xây dựng với ❤️ và ☕.
