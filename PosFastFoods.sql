/* ============================================================
   SCRIPT TẠO DATABASE: PosFastFoodsV2 (Clean & Portable)
   - Không chứa đường dẫn file cứng (chạy được mọi máy)
   - Chỉ tạo cấu trúc bảng, KHÔNG có dữ liệu
   - Đã tối ưu thứ tự tạo bảng để tránh lỗi Foreign Key
   ============================================================ */

USE [master]
GO

-- 1. Tạo Database (Nếu chưa tồn tại)
-- SQL Server sẽ tự động lưu file .mdf và .ldf vào thư mục cài đặt mặc định của máy đích
IF DB_ID('PosFastFoodsV2') IS NULL
BEGIN
    CREATE DATABASE [PosFastFoodsV2]
    -- Không set đường dẫn cứng để đảm bảo tính di động
END
GO

USE [PosFastFoodsV2]
GO

-- 2. Xóa bảng cũ nếu tồn tại (để chạy lại script không bị lỗi)
-- Xóa theo thứ tự: Bảng con (có FK) xóa trước -> Bảng cha xóa sau
IF OBJECT_ID('dbo.OrderDetail', 'U') IS NOT NULL DROP TABLE dbo.OrderDetail;
IF OBJECT_ID('dbo.Order', 'U') IS NOT NULL DROP TABLE dbo.[Order]; -- Lưu ý: Order là từ khóa, nên để trong ngoặc []
IF OBJECT_ID('dbo.Product', 'U') IS NOT NULL DROP TABLE dbo.Product;
IF OBJECT_ID('dbo.TypeProduct', 'U') IS NOT NULL DROP TABLE dbo.TypeProduct;
IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL DROP TABLE dbo.Employee;
IF OBJECT_ID('dbo.RoleEmployee', 'U') IS NOT NULL DROP TABLE dbo.RoleEmployee; -- Nếu bạn có bảng này
GO

-- 3. Tạo các bảng (Tables)
-- Thiết lập ANSI_NULLS và QUOTED_IDENTIFIER chuẩn
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- 3.1 Bảng Employee (Nhân viên) - Cần tạo trước để Product tham chiếu
CREATE TABLE [dbo].[Employee](
    [IdEmployee] [int] IDENTITY(1,1) NOT NULL,
    [NameEmployee] [nvarchar](250) NOT NULL,
    [BirthDay] [datetime] NULL,
    [Gender] [bit] NULL,
    [Address] [nvarchar](250) NULL,
    [Email] [nvarchar](200) NULL,
    [Password] [varchar](100) NULL,
    [IdRole] [int] NOT NULL, -- Giả sử bạn có role
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([IdEmployee] ASC)
)
GO

-- 3.2 Bảng TypeProduct (Loại sản phẩm)
CREATE TABLE [dbo].[TypeProduct](
    [IdTypeProduct] [int] IDENTITY(1,1) NOT NULL,
    [NameType] [nvarchar](100) NOT NULL,
    CONSTRAINT [PK_TypeProduct] PRIMARY KEY CLUSTERED ([IdTypeProduct] ASC)
)
GO

-- 3.3 Bảng Product (Sản phẩm)
CREATE TABLE [dbo].[Product](
    [IdProduct] [int] IDENTITY(1,1) NOT NULL,
    [NameProduct] [nvarchar](100) NOT NULL,
    [PriceProduct] [decimal](18, 0) NOT NULL,
    [Images] [image] NULL, -- Hoặc varbinary(max)
    [Descriptions] [nvarchar](max) NULL,
    [IdTypeProduct] [int] NOT NULL,
    [CreatedBy] [int] NULL, -- Đổi tên theo file script gốc của bạn
    [IsActive] [bit] DEFAULT(1),
    CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([IdProduct] ASC)
)
GO

-- 3.4 Bảng Order (Hóa đơn)
-- Lưu ý: Tên bảng Order dễ trùng từ khóa hệ thống, nên dùng [Order]
CREATE TABLE [dbo].[Order](
    [IdOrder] [int] IDENTITY(1,1) NOT NULL,
    [CreatedDate] [datetime] DEFAULT(GETDATE()),
    [Total] [decimal](18, 0) DEFAULT(0),
    [IdEmployee] [int] NOT NULL, -- Người lập đơn
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([IdOrder] ASC)
)
GO

-- 3.5 Bảng OrderDetail (Chi tiết hóa đơn)
CREATE TABLE [dbo].[OrderDetail](
    [IdOrder] [int] NOT NULL,
    [IdProduct] [int] NOT NULL,
    [Quantity] [int] NOT NULL,
    [UnitPrice] [decimal](18, 0) NOT NULL,
    CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
    (
        [IdOrder] ASC,
        [IdProduct] ASC
    )
)
GO

-- 4. Tạo các Ràng buộc Khóa ngoại (Foreign Keys)
-- Phần này tách riêng để dễ quản lý như file gốc của bạn

-- FK: Product -> TypeProduct
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Type] FOREIGN KEY([IdTypeProduct])
REFERENCES [dbo].[TypeProduct] ([IdTypeProduct])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Type]
GO

-- FK: Product -> Employee (CreatedBy)
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Employee] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Employee]
GO

-- FK: Order -> Employee (Người lập)
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Employee] FOREIGN KEY([IdEmployee])
REFERENCES [dbo].[Employee] ([IdEmployee])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Employee]
GO

-- FK: OrderDetail -> Order (Có ON DELETE CASCADE như yêu cầu)
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OD_Order] FOREIGN KEY([IdOrder])
REFERENCES [dbo].[Order] ([IdOrder])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OD_Order]
GO

-- FK: OrderDetail -> Product
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OD_Product] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([IdProduct])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OD_Product]
GO

-- 5. Các ràng buộc kiểm tra dữ liệu (Check Constraints)

-- Check: Quantity > 0
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [CK_OrderDetail_Qty] CHECK  (([Quantity]>(0)))
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_OrderDetail_Qty]
GO

-- Check: UnitPrice >= 0
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [CK_OrderDetail_UnitPrice] CHECK  (([UnitPrice]>=(0)))
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_OrderDetail_UnitPrice]
GO

PRINT '--- TẠO DATABASE POSFASTFOODSV2 THÀNH CÔNG (EMPTY) ---'
