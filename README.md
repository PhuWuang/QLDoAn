# QLBanDoAnNhanh (POS WinForms + SQL Server)

Phần mềm **quản lý bán đồ ăn nhanh** viết bằng **C# WinForms**, lưu trữ dữ liệu trên **Microsoft SQL Server**.

---

## 1. Công nghệ
- C#: WinForms (Visual Studio 2022)
- CSDL: Microsoft SQL Server (Express/Developer)
- Data access: Entity Framework / ADO.NET (tùy dự án hiện có)
- Quản lý mã nguồn: Git & GitHub

---

## 2. Yêu cầu hệ thống
- Windows + Visual Studio 2022 (đã chọn workload **.NET desktop development**)
- SQL Server + SSMS
- Git for Windows

---

## 3. Cài đặt nhanh (clone là chạy)
### Bước 1) Clone project
```bash
git clone https://github.com/PhuWuang/POSquanlythucan.git
cd POSquanlythucan
```

### Bước 2) Tạo Database
- Mở **SSMS** → Connect tới SQL Server
- Tạo DB mới, ví dụ: **PosFastFoods**
- (Nếu có file script) mở `database/PosFastFoods.sql` → **Execute** để tạo bảng/dữ liệu mẫu

### Bước 3) Cấu hình connection string
Mở file **`App.config`** của project WinForms và chỉnh phần sau cho đúng tên server và database của bạn:
```xml
<connectionStrings>
  <add name="PosFastFood"
       connectionString="Data Source=localhost\\SQLEXPRESS;
                         Initial Catalog=PosFastFoods;
                         Integrated Security=True;
                         MultipleActiveResultSets=True;
                         TrustServerCertificate=True;
                         App=EntityFramework"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```
- Đổi `localhost\\SQLEXPRESS` → **Server name** thật của bạn (xem trong SSMS).
- Nếu dùng SQL Authentication:
  ```
  Data Source=localhost;Initial Catalog=PosFastFoods;
  User Id=sa;Password=<mat-khau>;TrustServerCertificate=True;
  ```

### Bước 4) Build & chạy
- **Build Solution:** `Ctrl + Shift + B`
- **Run:** `F5` (màn hình đăng nhập → giao diện chính)

---

## 4. Cấu trúc thư mục
```text
<repo-root>/
├─ QLBanDoAnNhanh.sln
├─ QLBanDoAnNhanh/          # Project WinForms
│  ├─ App.config            # Connection string
│  ├─ Models/               # (Item, Order, ...)
│  ├─ frmMain.cs
│  ├─ frmLogin.cs
│  ├─ frmAddItem.cs
│  └─ ...
├─ database/
│  └─ PosFastFoods.sql      # (tuỳ chọn) script tạo DB
└─ README.md
```

---

## 5. Lỗi thường gặp (và cách xử lý)
- **Không kết nối được SQL Server**
  - Sai *Server name* hoặc chưa tạo DB → kiểm tra trong SSMS
  - Dịch vụ SQL chưa chạy → mở **Services** và bật **SQL Server (MSSQLSERVER/SQLEXPRESS)**
- **Thiếu bảng/dữ liệu**: chưa chạy script `PosFastFoods.sql`
- **Build thất bại**: chưa cài workload **.NET desktop development** trong Visual Studio Installer
