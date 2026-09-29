USE TechZoneDb;
GO

IF OBJECT_ID('dbo.SaleDetails', 'U') IS NOT NULL DROP TABLE dbo.SaleDetails;
IF OBJECT_ID('dbo.Invoices', 'U') IS NOT NULL DROP TABLE dbo.Invoices;
IF OBJECT_ID('dbo.Sales', 'U') IS NOT NULL DROP TABLE dbo.Sales;
IF OBJECT_ID('dbo.Inventory', 'U') IS NOT NULL DROP TABLE dbo.Inventory;
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL DROP TABLE dbo.Products;
IF OBJECT_ID('dbo.Customers', 'U') IS NOT NULL DROP TABLE dbo.Customers;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
IF OBJECT_ID('dbo.Roles', 'U') IS NOT NULL DROP TABLE dbo.Roles;
IF OBJECT_ID('dbo.Categories', 'U') IS NOT NULL DROP TABLE dbo.Categories;
GO

IF EXISTS (
    SELECT 1
    FROM sys.sequences
    WHERE name = 'InvoiceNumberSequence'
)
    DROP SEQUENCE dbo.InvoiceNumberSequence;
GO

CREATE SEQUENCE dbo.InvoiceNumberSequence
    AS INT
    START WITH 1;
GO

CREATE TABLE dbo.Categories
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
        CONSTRAINT UQ_Categories_Name UNIQUE,
    Description NVARCHAR(255)
);
GO

CREATE TABLE dbo.Customers
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(30),
    Email NVARCHAR(100)
);
GO

CREATE TABLE dbo.Products
(
    Id INT IDENTITY PRIMARY KEY,
    SKU NVARCHAR(50) NOT NULL
        CONSTRAINT UQ_Products_SKU UNIQUE,
    Name NVARCHAR(150) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
        CONSTRAINT CK_Products_Price CHECK (Price >= 0),
    CategoryId INT NOT NULL
        CONSTRAINT FK_Products_Categories
            REFERENCES dbo.Categories(Id),
    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_Products_CreatedAt DEFAULT GETDATE(),
    ImagePath NVARCHAR(500)
);
GO

CREATE TABLE dbo.Inventory
(
    Id INT IDENTITY PRIMARY KEY,
    ProductId INT NOT NULL
        CONSTRAINT UQ_Inventory_ProductId UNIQUE
        CONSTRAINT FK_Inventory_Products
            REFERENCES dbo.Products(Id)
            ON DELETE CASCADE,

    Stock INT NOT NULL
        CONSTRAINT DF_Inventory_Stock DEFAULT 0
        CONSTRAINT CK_Inventory_Stock CHECK (Stock >= 0),

    LastUpdated DATETIME2 NOT NULL
        CONSTRAINT DF_Inventory_LastUpdated DEFAULT SYSDATETIME()
);
GO

CREATE TABLE dbo.Roles
(
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
        CONSTRAINT UQ_Roles_Name UNIQUE
);
GO

CREATE TABLE dbo.Users
(
    Id INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL
        CONSTRAINT UQ_Users_Username UNIQUE,

    PasswordHash NVARCHAR(255) NOT NULL,

    RoleId INT NOT NULL
        CONSTRAINT FK_Users_Roles
            REFERENCES dbo.Roles(Id),

    CreatedAt DATETIME2 NOT NULL
        CONSTRAINT DF_Users_CreatedAt DEFAULT SYSDATETIME(),

    IsActive BIT NOT NULL
        CONSTRAINT DF_Users_IsActive DEFAULT 1,

    DeletedAt DATETIME2,

    ProfileImagePath NVARCHAR(500),

    DisplayName NVARCHAR(100)
);
GO

CREATE TABLE dbo.Sales
(
    Id INT IDENTITY PRIMARY KEY,

    CustomerId INT
        CONSTRAINT FK_Sales_Customers
            REFERENCES dbo.Customers(Id)
            ON DELETE CASCADE,

    UserId INT NOT NULL
        CONSTRAINT FK_Sales_Users
            REFERENCES dbo.Users(Id),

    TotalAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT CK_Sales_TotalAmount CHECK (TotalAmount >= 0),

    SaleDate DATETIME2 NOT NULL
        CONSTRAINT DF_Sales_SaleDate DEFAULT SYSDATETIME(),

    Status VARCHAR(20) NOT NULL
        CONSTRAINT DF_Sales_Status DEFAULT 'Pending'
        CONSTRAINT CK_Sales_Status
            CHECK (Status IN ('Cancelled', 'Completed', 'Pending')),

    SubtotalAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT DF_Sales_SubtotalAmount DEFAULT 0
        CONSTRAINT CK_Sales_SubtotalAmount CHECK (SubtotalAmount >= 0),

    DiscountPercent DECIMAL(5, 2) NOT NULL
        CONSTRAINT DF_Sales_DiscountPercent DEFAULT 0
        CONSTRAINT CK_Sales_DiscountPercent
            CHECK (DiscountPercent >= 0 AND DiscountPercent <= 100),

    DiscountAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT DF_Sales_DiscountAmount DEFAULT 0
        CONSTRAINT CK_Sales_DiscountAmount CHECK (DiscountAmount >= 0),

    PickupDate DATE,

    OrderNumber INT
);
GO

CREATE TABLE dbo.Invoices
(
    Id INT IDENTITY PRIMARY KEY,

    InvoiceNumber INT NOT NULL
        CONSTRAINT UQ_Invoices_InvoiceNumber UNIQUE,

    SaleId INT NOT NULL
        CONSTRAINT UQ_Invoices_SaleId UNIQUE
        CONSTRAINT FK_Invoices_Sales
            REFERENCES dbo.Sales(Id)
            ON DELETE CASCADE,

    CustomerId INT
        CONSTRAINT FK_Invoices_Customers
            REFERENCES dbo.Customers(Id),

    InvoiceDate DATETIME2 NOT NULL
        CONSTRAINT DF_Invoices_InvoiceDate DEFAULT SYSDATETIME(),

    SaleType VARCHAR(20) NOT NULL
        CONSTRAINT CK_Invoices_SaleType
            CHECK (SaleType IN ('QuickSale', 'Order', 'Sale')),

    SubtotalAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT CK_Invoices_SubtotalAmount
            CHECK (SubtotalAmount >= 0),

    DiscountAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT DF_Invoices_DiscountAmount DEFAULT 0
        CONSTRAINT CK_Invoices_DiscountAmount
            CHECK (DiscountAmount >= 0),

    TotalAmount DECIMAL(10, 2) NOT NULL
        CONSTRAINT CK_Invoices_TotalAmount
            CHECK (TotalAmount >= 0)
);
GO

CREATE TABLE dbo.SaleDetails
(
    Id INT IDENTITY PRIMARY KEY,

    SaleId INT NOT NULL
        CONSTRAINT FK_SaleDetails_Sales
            REFERENCES dbo.Sales(Id)
            ON DELETE CASCADE,

    ProductId INT NOT NULL
        CONSTRAINT FK_SaleDetails_Products
            REFERENCES dbo.Products(Id),

    Quantity INT NOT NULL
        CONSTRAINT CK_SaleDetails_Quantity
            CHECK (Quantity > 0),

    UnitPrice DECIMAL(10, 2) NOT NULL
        CONSTRAINT CK_SaleDetails_UnitPrice
            CHECK (UnitPrice >= 0),

    Discount DECIMAL(10, 2) NOT NULL
        CONSTRAINT DF_SaleDetails_Discount DEFAULT 0
        CONSTRAINT CK_SaleDetails_Discount CHECK (Discount >= 0)
);
GO