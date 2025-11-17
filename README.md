Dựa trên mã nguồn và cấu trúc dự án bạn đã tải lên (đặc biệt là các file .csproj, .sql, và danh sách các Form), tôi đã soạn thảo lại nội dung file README.md chuyên nghiệp và đầy đủ hơn, bám sát theo phong cách mẫu bạn yêu cầu.

Dự án của bạn là PosFastFoods (Quản lý cửa hàng thức ăn nhanh), sử dụng WinForms, LINQ to SQL, Guna UI2 và RDLC Report.

Dưới đây là nội dung file README.md mới:

🍔 PosFastFoods – Phần mềm Quản lý Cửa hàng Thức ăn nhanh
Quản lý POS FastFood – WinForms (.NET Framework 4.7.2)

📌 Đồ án kết thúc học phần – Lập Trình Trên Windows 📌 Khoa Công nghệ Thông tin 👥 Thực hiện: Nhom 3

📖 Giới thiệu dự án
Hệ thống PosFastFoods được xây dựng nhằm hỗ trợ quy trình vận hành của một cửa hàng thức ăn nhanh, từ khâu gọi món, thanh toán đến quản lý nhân sự và thống kê doanh thu. Giao diện ứng dụng được thiết kế hiện đại, thân thiện nhờ sử dụng bộ thư viện Guna UI2.

🛠 Công nghệ sử dụng
Ngôn ngữ: C#

Nền tảng: WinForms (.NET Framework 4.7.2)

Cơ sở dữ liệu: SQL Server

Truy vấn dữ liệu (ORM): LINQ to SQL

Giao diện (UI): Guna.UI2.WinForms (v2.0.4.6)

Báo cáo: Microsoft RDLC Report (Reporting Services)

🧩 Các chức năng chính
🔐 Hệ thống & Bảo mật
Đăng nhập: Phân quyền truy cập dựa trên vai trò (Quản lý / Nhân viên).

Đổi mật khẩu: Cho phép nhân viên tự cập nhật mật khẩu cá nhân.

Cài đặt: Tùy chỉnh cấu hình hệ thống cơ bản.

🛒 Chức năng Bán hàng (POS)
Gọi món (Order): Giao diện trực quan hình ảnh món ăn (Burger, Gà rán, Cơm, Nước uống...).

Xử lý đơn hàng: Thêm/bớt món, tính tổng tiền tự động.

Quản lý hóa đơn: Xem danh sách hóa đơn, chi tiết từng hóa đơn (frmInvoiceList, frmInvoiceDetail).

📦 Chức năng Quản lý (Admin)
Quản lý Sản phẩm:

Thêm mới, chỉnh sửa, cập nhật giá và hình ảnh món ăn (frmAddItem, frmEditItem).

Xem chi tiết thông tin sản phẩm (frmItemDetail).

Quản lý Nhân viên:

Quản lý danh sách nhân viên, thông tin cá nhân và chức vụ (frmEmployee).

Danh mục: Quản lý loại sản phẩm (TypeProduct).

📊 Thống kê & Báo cáo
Thống kê tổng quan: Xem các chỉ số kinh doanh nhanh (frmStatistics).

Báo cáo Doanh thu: Xuất báo cáo doanh thu theo ngày/tháng/năm (rptInvoiceByDate).

Sản phẩm bán chạy: Thống kê và xuất báo cáo Top sản phẩm tiêu thụ nhiều nhất (rptTopProducts).

Chi tiết hóa đơn: In phiếu thanh toán cho khách hàng (rptInvoiceDetail).

🗄 Thiết kế cơ sở dữ liệu (Database)
Cơ sở dữ liệu PosFastFoods bao gồm các bảng chính được chuẩn hóa:

RoleEmployee: Quản lý chức vụ/quyền hạn (Admin, Staff...).

Employee: Thông tin nhân viên, tài khoản đăng nhập (liên kết với Role).

TypeProduct: Các loại sản phẩm (Combo, Food, Drinks, Snack...).

Product: Thông tin món ăn, giá bán, hình ảnh, mô tả.

Orders: Thông tin đơn hàng tổng (Ngày tạo, Tổng tiền, Người lập).

OrderDetail: Chi tiết món ăn trong từng đơn hàng (Số lượng, Giá tại thời điểm bán).

⚙️ Cài đặt & Chạy thử
Yêu cầu môi trường
IDE: Visual Studio 2019 hoặc 2022.

Database: SQL Server (mọi phiên bản từ 2014 trở lên).

Framework: .NET Framework 4.7.2.

Hướng dẫn cài đặt
Clone project:

Bash

git clone https://github.com/PhuWuang/QLDoAn.git
Cấu hình Cơ sở dữ liệu:

Mở SQL Server Management Studio (SSMS).

Chạy file script PosFastFoods.sql (nằm trong thư mục gốc) để tạo Database và các bảng dữ liệu mẫu.

Cấu hình kết nối:

Mở file App.config trong project QLBanDoAnNhanh.DAL hoặc src/QLBanDoAnNhanh.

Sửa chuỗi kết nối (Connection String) PosFastFoodsConnectionString phù hợp với tên Server của bạn.

Chạy ứng dụng:

Mở solution QLBanDoAnNhanh.sln bằng Visual Studio.

Nhấn Start (F5) để build và chạy chương trình.

📸 Một số hình ảnh Demo
(Bạn có thể thêm ảnh chụp màn hình giao diện phần mềm vào đây để file Readme sinh động hơn)

Giao diện Đăng nhập

Giao diện Bán hàng

Giao diện Thống kê

🚀 Hướng phát triển
Tích hợp thanh toán qua mã QR/Ví điện tử.

Mở rộng chức năng quản lý kho nguyên liệu.

Phát triển phiên bản Web hoặc Mobile App cho người quản lý
