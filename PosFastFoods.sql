/* ============================================================
   PosFastFoods - Portable, Idempotent DDL Script
   - Không hard-code đường dẫn MDF/LDF
   - Có thể chạy nhiều lần (DROP IF EXISTS)
   - Thứ tự tạo bảng đúng quan hệ
   - Unicode-friendly, decimal thay cho money
   ============================================================ */

SET NOCOUNT ON;
SET XACT_ABORT ON;

-------------------------------------------------------------------------------
-- 1) Tạo database nếu chưa có, dùng file mặc định của SQL Server trên máy đích
-------------------------------------------------------------------------------
IF DB_ID(N'PosFastFoods') IS NULL
BEGIN
    PRINT N'Creating database PosFastFoods...';
    CREATE DATABASE PosFastFoods;
END
ELSE
BEGIN
    PRINT N'Database PosFastFoods already exists.';
END
GO

USE PosFastFoods;
GO

-------------------------------------------------------------------------------
-- 2) (Tuỳ chọn) Thiết lập option ở mức database thân thiện/chuẩn
-------------------------------------------------------------------------------
ALTER DATABASE PosFastFoods SET RECOVERY SIMPLE;
ALTER DATABASE PosFastFoods SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE PosFastFoods SET AUTO_CLOSE OFF;
ALTER DATABASE PosFastFoods SET AUTO_SHRINK OFF;
-- Không set CompatibilityLevel, Query Store, file path... để portable

-------------------------------------------------------------------------------
-- 3) Xoá bảng cũ theo thứ tự con -> cha để có thể chạy lại nhiều lần
-------------------------------------------------------------------------------
IF OBJECT_ID(N'dbo.OrderDetail', N'U') IS NOT NULL DROP TABLE dbo.OrderDetail;
IF OBJECT_ID(N'dbo.Orders',      N'U') IS NOT NULL DROP TABLE dbo.Orders;
IF OBJECT_ID(N'dbo.Product',     N'U') IS NOT NULL DROP TABLE dbo.Product;
IF OBJECT_ID(N'dbo.TypeProduct', N'U') IS NOT NULL DROP TABLE dbo.TypeProduct;
IF OBJECT_ID(N'dbo.Employee',    N'U') IS NOT NULL DROP TABLE dbo.Employee;
IF OBJECT_ID(N'dbo.RoleEmployee',N'U') IS NOT NULL DROP TABLE dbo.RoleEmployee;
GO

-------------------------------------------------------------------------------
-- 4) Tạo bảng theo thứ tự cha -> con
-------------------------------------------------------------------------------

-- 4.1 RoleEmployee
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO
CREATE TABLE dbo.RoleEmployee
(
    IdRole   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_RoleEmployee PRIMARY KEY,
    NameRole NVARCHAR(100)     NOT NULL
);
GO

-- 4.2 Employee
CREATE TABLE dbo.Employee
(
    IdEmployee   INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Employee PRIMARY KEY,
    NameEmployee NVARCHAR(250)     NOT NULL,
    BirthDay     DATETIME2(7)      NULL,
    Gender       BIT               NULL,
    [Address]    NVARCHAR(250)     NULL,
    Email        NVARCHAR(200)     NULL,
    [Password]   VARCHAR(100)      NULL,  -- lưu hash/băm ở tầng ứng dụng
    IdRole       INT               NOT NULL,
    CONSTRAINT FK_Employee_Role
        FOREIGN KEY (IdRole) REFERENCES dbo.RoleEmployee(IdRole)
);
GO

-- 4.3 TypeProduct (người tạo/sửa có thể để NULL)
CREATE TABLE dbo.TypeProduct
(
    IdTypeProduct INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TypeProduct PRIMARY KEY,
    NameType      NVARCHAR(50)      NOT NULL,
    IdEmployee    INT               NULL,
    CONSTRAINT FK_TypeProduct_Employee
        FOREIGN KEY (IdEmployee) REFERENCES dbo.Employee(IdEmployee)
);
GO

-- 4.4 Product
CREATE TABLE dbo.Product
(
    IdProduct     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Product PRIMARY KEY,
    NameProduct   NVARCHAR(100)     NOT NULL,
    PriceProduct  DECIMAL(19,4)     NOT NULL,        -- thay MONEY để portable/chính xác
    Descriptions  NVARCHAR(MAX)     NULL,
    Images        VARBINARY(MAX)    NULL,
    IsActive      BIT               NOT NULL CONSTRAINT DF_Product_IsActive DEFAULT(1),
    IdTypeProduct INT               NOT NULL,
    IdEmployee    INT               NULL,            -- người tạo/sửa
    CONSTRAINT FK_Product_Type
        FOREIGN KEY (IdTypeProduct) REFERENCES dbo.TypeProduct(IdTypeProduct),
    CONSTRAINT FK_Product_Employee
        FOREIGN KEY (IdEmployee)    REFERENCES dbo.Employee(IdEmployee)
);
GO

-- 4.5 Orders
CREATE TABLE dbo.Orders
(
    IdOrder     INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Orders PRIMARY KEY,
    Total       DECIMAL(19,4)     NOT NULL CONSTRAINT DF_Orders_Total DEFAULT(0),
    CreateDate  DATETIME2(7)      NOT NULL CONSTRAINT DF_Orders_CreateDate DEFAULT (SYSUTCDATETIME()),
    IdEmployee  INT               NOT NULL,  -- người lập hoá đơn
    CONSTRAINT FK_Orders_Employee
        FOREIGN KEY (IdEmployee) REFERENCES dbo.Employee(IdEmployee)
);
GO

-- 4.6 OrderDetail (chi tiết hoá đơn) - composite PK; cascade khi xoá Order
CREATE TABLE dbo.OrderDetail
(
    IdOrder    INT           NOT NULL,
    IdProduct  INT           NOT NULL,
    Quantity   INT           NOT NULL CONSTRAINT DF_OrderDetail_Quantity DEFAULT(1),
    Price      DECIMAL(19,4) NOT NULL,  -- giá tại thời điểm bán
    CONSTRAINT PK_OrderDetail PRIMARY KEY (IdOrder, IdProduct),
    CONSTRAINT FK_OrderDetail_Order
        FOREIGN KEY (IdOrder)   REFERENCES dbo.Orders(IdOrder)  ON DELETE CASCADE,
    CONSTRAINT FK_OrderDetail_Product
        FOREIGN KEY (IdProduct) REFERENCES dbo.Product(IdProduct)
);
GO

-------------------------------------------------------------------------------
-- 5) (Tuỳ chọn) Chỉ mục gợi ý cho hiệu năng
-------------------------------------------------------------------------------
-- CREATE INDEX IX_Product_Type ON dbo.Product(IdTypeProduct);
-- CREATE INDEX IX_Orders_CreateDate ON dbo.Orders(CreateDate);
-- CREATE INDEX IX_OrderDetail_Product ON dbo.OrderDetail(IdProduct);

PRINT N'PosFastFoods schema created/updated successfully.';
