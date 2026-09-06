/*
============================================================
Restaurant & Café POS System
SQL Server Database
Database: RestaurantPOSDB
============================================================

Main Workflow:
Table -> Create/Update Order -> Save Order -> Customer Eats
-> Reopen Existing Order -> Checkout -> Payment
-> Complete Order -> Release Table -> Update Stock

Core Tables:
1. tblUsers
2. tblTables
3. tblCategories
4. tblProducts
5. tblOrders
6. tblOrderDetails
7. tblPayments

Optional/Supporting:
- Views for active orders and sales
- Stored procedures for common CRUD/order/payment operations
- Indexes and constraints
============================================================
*/

-- ============================================================
-- 0. CREATE DATABASE
-- ============================================================
IF DB_ID('RestaurantPOSDB') IS NULL
BEGIN
    CREATE DATABASE RestaurantPOSDB;
END;
GO

USE RestaurantPOSDB;
GO

-- ============================================================
-- 1. DROP OBJECTS FOR RE-RUNNING SCRIPT
--    (Only if they already exist)
-- ============================================================
IF OBJECT_ID('dbo.vwActiveTableOrders', 'V') IS NOT NULL
    DROP VIEW dbo.vwActiveTableOrders;
GO

IF OBJECT_ID('dbo.vwSalesSummary', 'V') IS NOT NULL
    DROP VIEW dbo.vwSalesSummary;
GO

IF OBJECT_ID('dbo.sp_CreateOrder', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_CreateOrder;
GO

IF OBJECT_ID('dbo.sp_SaveOrderDetail', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_SaveOrderDetail;
GO

IF OBJECT_ID('dbo.sp_RemoveOrderDetail', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_RemoveOrderDetail;
GO

IF OBJECT_ID('dbo.sp_UpdateOrderDetailQuantity', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_UpdateOrderDetailQuantity;
GO

IF OBJECT_ID('dbo.sp_ApplyOrderDiscount', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ApplyOrderDiscount;
GO

IF OBJECT_ID('dbo.sp_CompleteOrder', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_CompleteOrder;
GO

IF OBJECT_ID('dbo.sp_ProductCRUD', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ProductCRUD;
GO

IF OBJECT_ID('dbo.tblPayments', 'U') IS NOT NULL
    DROP TABLE dbo.tblPayments;
GO

IF OBJECT_ID('dbo.tblOrderDetails', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrderDetails;
GO

IF OBJECT_ID('dbo.tblOrders', 'U') IS NOT NULL
    DROP TABLE dbo.tblOrders;
GO

IF OBJECT_ID('dbo.tblProducts', 'U') IS NOT NULL
    DROP TABLE dbo.tblProducts;
GO

IF OBJECT_ID('dbo.tblCategories', 'U') IS NOT NULL
    DROP TABLE dbo.tblCategories;
GO

IF OBJECT_ID('dbo.tblTables', 'U') IS NOT NULL
    DROP TABLE dbo.tblTables;
GO

IF OBJECT_ID('dbo.tblUsers', 'U') IS NOT NULL
    DROP TABLE dbo.tblUsers;
GO

-- ============================================================
-- 2. USERS
-- ============================================================
CREATE TABLE dbo.tblUsers
(
    UserID          INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblUsers PRIMARY KEY,
    Username        NVARCHAR(50) NOT NULL,
    PasswordHash    NVARCHAR(255) NOT NULL,
    FullName        NVARCHAR(100) NOT NULL,
    Role            NVARCHAR(20) NOT NULL,
    IsActive        BIT NOT NULL
        CONSTRAINT DF_tblUsers_IsActive DEFAULT (1),
    CreatedAt       DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblUsers_CreatedAt DEFAULT (SYSDATETIME()),

    CONSTRAINT UQ_tblUsers_Username UNIQUE (Username),
    CONSTRAINT CK_tblUsers_Role
        CHECK (Role IN ('Admin', 'Cashier'))
);
GO

-- ============================================================
-- 3. RESTAURANT TABLES
-- ============================================================
CREATE TABLE dbo.tblTables
(
    TableID         INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblTables PRIMARY KEY,
    TableName       NVARCHAR(50) NOT NULL,
    Capacity        INT NOT NULL
        CONSTRAINT DF_tblTables_Capacity DEFAULT (4),
    Status          NVARCHAR(20) NOT NULL
        CONSTRAINT DF_tblTables_Status DEFAULT ('Available'),
    IsActive        BIT NOT NULL
        CONSTRAINT DF_tblTables_IsActive DEFAULT (1),
    CreatedAt       DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblTables_CreatedAt DEFAULT (SYSDATETIME()),

    CONSTRAINT UQ_tblTables_TableName UNIQUE (TableName),
    CONSTRAINT CK_tblTables_Capacity CHECK (Capacity > 0),
    CONSTRAINT CK_tblTables_Status
        CHECK (Status IN ('Available', 'Occupied', 'Reserved'))
);
GO

-- ============================================================
-- 4. PRODUCT CATEGORIES
-- ============================================================
CREATE TABLE dbo.tblCategories
(
    CategoryID      INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblCategories PRIMARY KEY,
    CategoryName    NVARCHAR(50) NOT NULL,
    IsActive        BIT NOT NULL
        CONSTRAINT DF_tblCategories_IsActive DEFAULT (1),
    CreatedAt       DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblCategories_CreatedAt DEFAULT (SYSDATETIME()),

    CONSTRAINT UQ_tblCategories_CategoryName UNIQUE (CategoryName)
);
GO

-- ============================================================
-- 5. PRODUCTS / MENU ITEMS
-- ============================================================
CREATE TABLE dbo.tblProducts
(
    ProductID       INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblProducts PRIMARY KEY,
    CategoryID      INT NOT NULL,
    ProductName     NVARCHAR(100) NOT NULL,
    UnitPrice       DECIMAL(18,2) NOT NULL,
    StockQuantity   INT NOT NULL
        CONSTRAINT DF_tblProducts_StockQuantity DEFAULT (0),
    IsAvailable     BIT NOT NULL
        CONSTRAINT DF_tblProducts_IsAvailable DEFAULT (1),
    CreatedAt       DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblProducts_CreatedAt DEFAULT (SYSDATETIME()),
    UpdatedAt       DATETIME2(0) NULL,

    CONSTRAINT UQ_tblProducts_ProductName UNIQUE (ProductName),
    CONSTRAINT CK_tblProducts_UnitPrice CHECK (UnitPrice >= 0),
    CONSTRAINT CK_tblProducts_StockQuantity CHECK (StockQuantity >= 0),

    CONSTRAINT FK_tblProducts_tblCategories
        FOREIGN KEY (CategoryID)
        REFERENCES dbo.tblCategories(CategoryID)
);
GO

-- ============================================================
-- 6. ORDERS
--    Important:
--    An unpaid active order remains in the database.
--    Going "Back to Table" does NOT delete it.
-- ============================================================
CREATE TABLE dbo.tblOrders
(
    OrderID         INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblOrders PRIMARY KEY,
    TableID         INT NOT NULL,
    UserID          INT NOT NULL,

    OrderDate       DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblOrders_OrderDate DEFAULT (SYSDATETIME()),

    SubTotal        DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_tblOrders_SubTotal DEFAULT (0),
    TaxRate         DECIMAL(5,2) NOT NULL
        CONSTRAINT DF_tblOrders_TaxRate DEFAULT (10.00),
    TaxAmount       DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_tblOrders_TaxAmount DEFAULT (0),
    DiscountAmount  DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_tblOrders_DiscountAmount DEFAULT (0),
    GrandTotal      DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_tblOrders_GrandTotal DEFAULT (0),

    OrderStatus     NVARCHAR(20) NOT NULL
        CONSTRAINT DF_tblOrders_OrderStatus DEFAULT ('Open'),
    PaymentStatus   NVARCHAR(20) NOT NULL
        CONSTRAINT DF_tblOrders_PaymentStatus DEFAULT ('Unpaid'),

    Notes           NVARCHAR(500) NULL,
    CompletedAt     DATETIME2(0) NULL,

    CONSTRAINT CK_tblOrders_SubTotal CHECK (SubTotal >= 0),
    CONSTRAINT CK_tblOrders_TaxRate CHECK (TaxRate >= 0),
    CONSTRAINT CK_tblOrders_TaxAmount CHECK (TaxAmount >= 0),
    CONSTRAINT CK_tblOrders_DiscountAmount CHECK (DiscountAmount >= 0),
    CONSTRAINT CK_tblOrders_GrandTotal CHECK (GrandTotal >= 0),

    CONSTRAINT CK_tblOrders_OrderStatus
        CHECK (OrderStatus IN ('Open', 'Completed', 'Cancelled')),

    CONSTRAINT CK_tblOrders_PaymentStatus
        CHECK (PaymentStatus IN ('Unpaid', 'Paid', 'Refunded')),

    CONSTRAINT FK_tblOrders_tblTables
        FOREIGN KEY (TableID)
        REFERENCES dbo.tblTables(TableID),

    CONSTRAINT FK_tblOrders_tblUsers
        FOREIGN KEY (UserID)
        REFERENCES dbo.tblUsers(UserID)
);
GO

-- ============================================================
-- 7. ORDER DETAILS
-- ============================================================
CREATE TABLE dbo.tblOrderDetails
(
    DetailID        INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblOrderDetails PRIMARY KEY,
    OrderID         INT NOT NULL,
    ProductID       INT NOT NULL,
    UnitPrice       DECIMAL(18,2) NOT NULL,
    Quantity        INT NOT NULL,
    Notes           NVARCHAR(250) NULL,

    TotalPrice AS
        CONVERT(DECIMAL(18,2), UnitPrice * Quantity) PERSISTED,

    CONSTRAINT CK_tblOrderDetails_UnitPrice CHECK (UnitPrice >= 0),
    CONSTRAINT CK_tblOrderDetails_Quantity CHECK (Quantity > 0),

    CONSTRAINT FK_tblOrderDetails_tblOrders
        FOREIGN KEY (OrderID)
        REFERENCES dbo.tblOrders(OrderID)
        ON DELETE CASCADE,

    CONSTRAINT FK_tblOrderDetails_tblProducts
        FOREIGN KEY (ProductID)
        REFERENCES dbo.tblProducts(ProductID)
);
GO

-- ============================================================
-- 8. PAYMENTS
--    Payment is created only at checkout.
-- ============================================================
CREATE TABLE dbo.tblPayments
(
    PaymentID       INT IDENTITY(1,1) NOT NULL
        CONSTRAINT PK_tblPayments PRIMARY KEY,
    OrderID         INT NOT NULL,
    PaymentMethod   NVARCHAR(20) NOT NULL,
    AmountPaid      DECIMAL(18,2) NOT NULL,
    ChangeAmount    DECIMAL(18,2) NOT NULL
        CONSTRAINT DF_tblPayments_ChangeAmount DEFAULT (0),
    TransactionRef  NVARCHAR(100) NULL,
    PaidAt          DATETIME2(0) NOT NULL
        CONSTRAINT DF_tblPayments_PaidAt DEFAULT (SYSDATETIME()),
    PaymentStatus   NVARCHAR(20) NOT NULL
        CONSTRAINT DF_tblPayments_PaymentStatus DEFAULT ('Completed'),

    CONSTRAINT CK_tblPayments_Method
        CHECK (PaymentMethod IN ('Cash', 'KHQR', 'Card')),

    CONSTRAINT CK_tblPayments_AmountPaid CHECK (AmountPaid >= 0),
    CONSTRAINT CK_tblPayments_ChangeAmount CHECK (ChangeAmount >= 0),

    CONSTRAINT CK_tblPayments_Status
        CHECK (PaymentStatus IN ('Completed', 'Refunded')),

    CONSTRAINT UQ_tblPayments_OrderID UNIQUE (OrderID),

    CONSTRAINT FK_tblPayments_tblOrders
        FOREIGN KEY (OrderID)
        REFERENCES dbo.tblOrders(OrderID)
);
GO

-- ============================================================
-- 9. INDEXES
-- ============================================================
CREATE INDEX IX_tblProducts_CategoryID
    ON dbo.tblProducts(CategoryID);
GO

CREATE INDEX IX_tblProducts_ProductName
    ON dbo.tblProducts(ProductName);
GO

CREATE INDEX IX_tblOrders_TableID_OrderStatus
    ON dbo.tblOrders(TableID, OrderStatus);
GO

CREATE INDEX IX_tblOrders_OrderDate
    ON dbo.tblOrders(OrderDate);
GO

CREATE INDEX IX_tblOrders_UserID
    ON dbo.tblOrders(UserID);
GO

CREATE INDEX IX_tblOrderDetails_OrderID
    ON dbo.tblOrderDetails(OrderID);
GO

CREATE INDEX IX_tblOrderDetails_ProductID
    ON dbo.tblOrderDetails(ProductID);
GO

-- ============================================================
-- 10. INITIAL USERS
--    For classroom/demo use only.
--    PasswordHash values here are SHA-256 hashes of the plaintext
--    passwords below, matching AuthService's hashing algorithm:
--      admin   / admin123
--      cashier / cashier123
-- ============================================================
INSERT INTO dbo.tblUsers
    (Username, PasswordHash, FullName, Role)
VALUES
    ('admin',
     '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9',
     'System Administrator', 'Admin'),
    ('cashier',
     'B4C94003C562BB0D89535ECA77F07284FE560FD48A7CC1ED99F0A56263D616BA',
     'Main Cashier', 'Cashier');
GO

-- ============================================================
-- 11. INITIAL TABLES
-- ============================================================
INSERT INTO dbo.tblTables (TableName, Capacity, Status)
VALUES
    ('Table 01', 2, 'Available'),
    ('Table 02', 4, 'Available'),
    ('Table 03', 6, 'Available'),
    ('Table 04', 4, 'Available'),
    ('Table 05', 4, 'Available'),
    ('Table 06', 2, 'Available');
GO

-- ============================================================
-- 12. INITIAL CATEGORIES
-- ============================================================
INSERT INTO dbo.tblCategories (CategoryName)
VALUES
    ('Coffee'),
    ('Tea'),
    ('Bakery'),
    ('Main Dish'),
    ('Dessert'),
    ('Juice'),
    ('Soft Drink');
GO

-- ============================================================
-- 13. INITIAL PRODUCTS
-- ============================================================
INSERT INTO dbo.tblProducts
    (CategoryID, ProductName, UnitPrice, StockQuantity, IsAvailable)
VALUES
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Coffee'),
        'Iced Latte', 2.50, 100, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Coffee'),
        'Americano', 2.00, 100, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Coffee'),
        'Cappuccino', 3.00, 80, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Tea'),
        'Green Tea Latte', 2.75, 80, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Tea'),
        'Lemon Tea', 2.00, 80, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Bakery'),
        'Croissant', 1.75, 30, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Bakery'),
        'Chocolate Muffin', 2.25, 25, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Main Dish'),
        'Chicken Rice', 4.50, 50, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Main Dish'),
        'Beef Burger', 5.00, 40, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Dessert'),
        'Cheesecake', 3.00, 20, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Juice'),
        'Fresh Orange Juice', 2.50, 40, 1),
    ((SELECT CategoryID FROM dbo.tblCategories WHERE CategoryName = 'Soft Drink'),
        'Coca-Cola', 1.50, 60, 1);
GO

-- ============================================================
-- 14. VIEW: ACTIVE ORDERS BY TABLE
-- ============================================================
CREATE VIEW dbo.vwActiveTableOrders
AS
SELECT
    t.TableID,
    t.TableName,
    t.Capacity,
    t.Status AS TableStatus,
    o.OrderID,
    o.OrderDate,
    o.SubTotal,
    o.TaxAmount,
    o.DiscountAmount,
    o.GrandTotal,
    o.OrderStatus,
    o.PaymentStatus,
    u.FullName AS CashierName
FROM dbo.tblTables t
LEFT JOIN dbo.tblOrders o
    ON o.TableID = t.TableID
    AND o.OrderStatus = 'Open'
    AND o.PaymentStatus = 'Unpaid'
LEFT JOIN dbo.tblUsers u
    ON u.UserID = o.UserID
WHERE t.IsActive = 1;
GO

-- ============================================================
-- 15. VIEW: SALES SUMMARY
-- ============================================================
CREATE VIEW dbo.vwSalesSummary
AS
SELECT
    o.OrderID,
    o.OrderDate,
    t.TableName,
    u.FullName AS CashierName,
    o.SubTotal,
    o.TaxRate,
    o.TaxAmount,
    o.DiscountAmount,
    o.GrandTotal,
    p.PaymentMethod,
    p.AmountPaid,
    p.ChangeAmount,
    p.TransactionRef,
    p.PaidAt
FROM dbo.tblOrders o
INNER JOIN dbo.tblTables t
    ON t.TableID = o.TableID
INNER JOIN dbo.tblUsers u
    ON u.UserID = o.UserID
LEFT JOIN dbo.tblPayments p
    ON p.OrderID = o.OrderID
WHERE o.OrderStatus = 'Completed'
  AND o.PaymentStatus = 'Paid';
GO

-- ============================================================
-- 16. PROCEDURE: CREATE NEW ORDER
-- ============================================================
CREATE PROCEDURE dbo.sp_CreateOrder
    @TableID INT,
    @UserID INT,
    @OrderID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblOrders
        WHERE TableID = @TableID
          AND OrderStatus = 'Open'
          AND PaymentStatus = 'Unpaid'
    )
    BEGIN
        SELECT TOP 1
            @OrderID = OrderID
        FROM dbo.tblOrders
        WHERE TableID = @TableID
          AND OrderStatus = 'Open'
          AND PaymentStatus = 'Unpaid'
        ORDER BY OrderID DESC;

        COMMIT TRANSACTION;
        RETURN;
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblTables
        WHERE TableID = @TableID
          AND IsActive = 1
    )
        THROW 50001, 'Selected table does not exist or is inactive.', 1;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblUsers
        WHERE UserID = @UserID
          AND IsActive = 1
    )
        THROW 50002, 'Selected user does not exist or is inactive.', 1;

    INSERT INTO dbo.tblOrders
    (
        TableID, UserID, SubTotal, TaxRate, TaxAmount,
        DiscountAmount, GrandTotal, OrderStatus, PaymentStatus
    )
    VALUES
    (
        @TableID, @UserID, 0, 10, 0, 0, 0, 'Open', 'Unpaid'
    );

    SET @OrderID = SCOPE_IDENTITY();

    UPDATE dbo.tblTables
    SET Status = 'Occupied'
    WHERE TableID = @TableID;

    COMMIT TRANSACTION;
END;
GO

-- ============================================================
-- 17. PROCEDURE: SAVE / ADD ORDER DETAIL
-- ============================================================
CREATE PROCEDURE dbo.sp_SaveOrderDetail
    @OrderID INT,
    @ProductID INT,
    @Quantity INT,
    @Notes NVARCHAR(250) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @Quantity <= 0
        THROW 50003, 'Quantity must be greater than zero.', 1;

    DECLARE
        @UnitPrice DECIMAL(18,2),
        @Stock INT,
        @Available BIT,
        @TableID INT;

    SELECT
        @UnitPrice = p.UnitPrice,
        @Stock = p.StockQuantity,
        @Available = p.IsAvailable
    FROM dbo.tblProducts p
    WHERE p.ProductID = @ProductID;

    IF @UnitPrice IS NULL
        THROW 50004, 'Product not found.', 1;

    IF @Available = 0
        THROW 50005, 'Product is not available.', 1;

    IF NOT EXISTS
    (
        SELECT 1
        FROM dbo.tblOrders
        WHERE OrderID = @OrderID
          AND OrderStatus = 'Open'
          AND PaymentStatus = 'Unpaid'
    )
        THROW 50006, 'Order is not open or has already been paid.', 1;

    IF @Stock < @Quantity
        THROW 50007, 'Insufficient stock.', 1;

    SELECT @TableID = TableID
    FROM dbo.tblOrders
    WHERE OrderID = @OrderID;

    IF EXISTS
    (
        SELECT 1
        FROM dbo.tblOrderDetails
        WHERE OrderID = @OrderID
          AND ProductID = @ProductID
    )
    BEGIN
        UPDATE dbo.tblOrderDetails
        SET Quantity = Quantity + @Quantity,
            Notes = ISNULL(@Notes, Notes)
        WHERE OrderID = @OrderID
          AND ProductID = @ProductID;
    END
    ELSE
    BEGIN
        INSERT INTO dbo.tblOrderDetails
        (OrderID, ProductID, UnitPrice, Quantity, Notes)
        VALUES
        (@OrderID, @ProductID, @UnitPrice, @Quantity, @Notes);
    END;

    DECLARE
        @SubTotal DECIMAL(18,2),
        @TaxRate DECIMAL(5,2),
        @TaxAmount DECIMAL(18,2),
        @DiscountAmount DECIMAL(18,2);

    SELECT @SubTotal = ISNULL(SUM(TotalPrice), 0)
    FROM dbo.tblOrderDetails
    WHERE OrderID = @OrderID;

    SELECT @TaxRate = TaxRate, @DiscountAmount = DiscountAmount
    FROM dbo.tblOrders
    WHERE OrderID = @OrderID;

    SET @TaxAmount = ROUND((@SubTotal - @DiscountAmount) * (@TaxRate / 100.0), 2);
    IF @TaxAmount < 0 SET @TaxAmount = 0;

    UPDATE dbo.tblOrders
    SET SubTotal = @SubTotal,
        TaxAmount = @TaxAmount,
        GrandTotal = @SubTotal - @DiscountAmount + @TaxAmount
    WHERE OrderID = @OrderID;

    UPDATE dbo.tblTables
    SET Status = 'Occupied'
    WHERE TableID = @TableID;
END;
GO

-- ============================================================
-- 17b. PROCEDURE: UPDATE ORDER DETAIL QUANTITY (absolute set)
-- ============================================================
CREATE PROCEDURE dbo.sp_UpdateOrderDetailQuantity
    @DetailID INT,
    @Quantity INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @OrderID INT, @ProductID INT, @Stock INT;

    IF @Quantity <= 0
        THROW 50013, 'Quantity must be greater than zero. Use remove instead.', 1;

    SELECT @OrderID = OrderID, @ProductID = ProductID
    FROM dbo.tblOrderDetails
    WHERE DetailID = @DetailID;

    IF @OrderID IS NULL
        THROW 50014, 'Order line not found.', 1;

    SELECT @Stock = StockQuantity FROM dbo.tblProducts WHERE ProductID = @ProductID;

    UPDATE dbo.tblOrderDetails
    SET Quantity = @Quantity
    WHERE DetailID = @DetailID;

    DECLARE @SubTotal DECIMAL(18,2), @TaxRate DECIMAL(5,2),
            @TaxAmount DECIMAL(18,2), @DiscountAmount DECIMAL(18,2);

    SELECT @SubTotal = ISNULL(SUM(TotalPrice), 0)
    FROM dbo.tblOrderDetails WHERE OrderID = @OrderID;

    SELECT @TaxRate = TaxRate, @DiscountAmount = DiscountAmount
    FROM dbo.tblOrders WHERE OrderID = @OrderID;

    SET @TaxAmount = ROUND((@SubTotal - @DiscountAmount) * (@TaxRate / 100.0), 2);
    IF @TaxAmount < 0 SET @TaxAmount = 0;

    UPDATE dbo.tblOrders
    SET SubTotal = @SubTotal,
        TaxAmount = @TaxAmount,
        GrandTotal = @SubTotal - @DiscountAmount + @TaxAmount
    WHERE OrderID = @OrderID;
END;
GO

-- ============================================================
-- 17c. PROCEDURE: REMOVE ORDER DETAIL LINE
-- ============================================================
CREATE PROCEDURE dbo.sp_RemoveOrderDetail
    @DetailID INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @OrderID INT;
    SELECT @OrderID = OrderID FROM dbo.tblOrderDetails WHERE DetailID = @DetailID;

    IF @OrderID IS NULL
        THROW 50015, 'Order line not found.', 1;

    DELETE FROM dbo.tblOrderDetails WHERE DetailID = @DetailID;

    DECLARE @SubTotal DECIMAL(18,2), @TaxRate DECIMAL(5,2),
            @TaxAmount DECIMAL(18,2), @DiscountAmount DECIMAL(18,2);

    SELECT @SubTotal = ISNULL(SUM(TotalPrice), 0)
    FROM dbo.tblOrderDetails WHERE OrderID = @OrderID;

    SELECT @TaxRate = TaxRate, @DiscountAmount = DiscountAmount
    FROM dbo.tblOrders WHERE OrderID = @OrderID;

    SET @TaxAmount = ROUND((@SubTotal - @DiscountAmount) * (@TaxRate / 100.0), 2);
    IF @TaxAmount < 0 SET @TaxAmount = 0;

    UPDATE dbo.tblOrders
    SET SubTotal = @SubTotal,
        TaxAmount = @TaxAmount,
        GrandTotal = @SubTotal - @DiscountAmount + @TaxAmount
    WHERE OrderID = @OrderID;
END;
GO

-- ============================================================
-- 17d. PROCEDURE: APPLY DISCOUNT TO AN OPEN ORDER
-- ============================================================
CREATE PROCEDURE dbo.sp_ApplyOrderDiscount
    @OrderID INT,
    @DiscountAmount DECIMAL(18,2)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF @DiscountAmount < 0
        THROW 50016, 'Discount cannot be negative.', 1;

    DECLARE @SubTotal DECIMAL(18,2), @TaxRate DECIMAL(5,2), @TaxAmount DECIMAL(18,2);

    SELECT @SubTotal = SubTotal, @TaxRate = TaxRate
    FROM dbo.tblOrders WHERE OrderID = @OrderID;

    IF @SubTotal IS NULL
        THROW 50017, 'Order not found.', 1;

    IF @DiscountAmount > @SubTotal
        THROW 50018, 'Discount cannot exceed subtotal.', 1;

    SET @TaxAmount = ROUND((@SubTotal - @DiscountAmount) * (@TaxRate / 100.0), 2);

    UPDATE dbo.tblOrders
    SET DiscountAmount = @DiscountAmount,
        TaxAmount = @TaxAmount,
        GrandTotal = @SubTotal - @DiscountAmount + @TaxAmount
    WHERE OrderID = @OrderID;
END;
GO

-- ============================================================
-- 18. PROCEDURE: COMPLETE ORDER / PAYMENT
-- ============================================================
CREATE PROCEDURE dbo.sp_CompleteOrder
    @OrderID INT,
    @PaymentMethod NVARCHAR(20),
    @AmountPaid DECIMAL(18,2),
    @TransactionRef NVARCHAR(100) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DECLARE
        @GrandTotal DECIMAL(18,2),
        @TableID INT,
        @OrderStatus NVARCHAR(20),
        @PaymentStatus NVARCHAR(20),
        @ChangeAmount DECIMAL(18,2);

    SELECT
        @GrandTotal = GrandTotal,
        @TableID = TableID,
        @OrderStatus = OrderStatus,
        @PaymentStatus = PaymentStatus
    FROM dbo.tblOrders
    WHERE OrderID = @OrderID;

    IF @GrandTotal IS NULL
        THROW 50008, 'Order not found.', 1;

    IF @OrderStatus <> 'Open'
        THROW 50009, 'Order is not open.', 1;

    IF @PaymentStatus <> 'Unpaid'
        THROW 50010, 'Order has already been paid.', 1;

    IF @PaymentMethod NOT IN ('Cash', 'KHQR', 'Card')
        THROW 50011, 'Invalid payment method.', 1;

    IF @AmountPaid < @GrandTotal
        THROW 50012, 'Amount paid is less than the grand total.', 1;

    SET @ChangeAmount = @AmountPaid - @GrandTotal;

    UPDATE dbo.tblOrders
    SET OrderStatus = 'Completed',
        PaymentStatus = 'Paid',
        CompletedAt = SYSDATETIME()
    WHERE OrderID = @OrderID;

    INSERT INTO dbo.tblPayments
    (OrderID, PaymentMethod, AmountPaid, ChangeAmount, TransactionRef, PaymentStatus)
    VALUES
    (@OrderID, @PaymentMethod, @AmountPaid, @ChangeAmount, @TransactionRef, 'Completed');

    UPDATE p
    SET p.StockQuantity = p.StockQuantity - od.Quantity,
        p.UpdatedAt = SYSDATETIME()
    FROM dbo.tblProducts p
    INNER JOIN dbo.tblOrderDetails od
        ON od.ProductID = p.ProductID
    WHERE od.OrderID = @OrderID;

    UPDATE dbo.tblTables
    SET Status = 'Available'
    WHERE TableID = @TableID;

    COMMIT TRANSACTION;

    SELECT
        o.OrderID, o.TableID, o.SubTotal, o.TaxAmount, o.DiscountAmount, o.GrandTotal,
        p.PaymentMethod, p.AmountPaid, p.ChangeAmount, p.PaidAt
    FROM dbo.tblOrders o
    INNER JOIN dbo.tblPayments p ON p.OrderID = o.OrderID
    WHERE o.OrderID = @OrderID;
END;
GO

-- ============================================================
-- 19. PROCEDURE: PRODUCT CRUD
-- ============================================================
CREATE PROCEDURE dbo.sp_ProductCRUD
    @Action NVARCHAR(20),
    @ProductID INT = NULL,
    @CategoryID INT = NULL,
    @ProductName NVARCHAR(100) = NULL,
    @UnitPrice DECIMAL(18,2) = NULL,
    @StockQuantity INT = NULL,
    @IsAvailable BIT = 1
AS
BEGIN
    SET NOCOUNT ON;

    IF @Action = 'INSERT'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.tblProducts WHERE ProductName = @ProductName)
            THROW 50020, 'Product name already exists.', 1;

        INSERT INTO dbo.tblProducts
            (CategoryID, ProductName, UnitPrice, StockQuantity, IsAvailable)
        VALUES
            (@CategoryID, @ProductName, @UnitPrice, @StockQuantity, @IsAvailable);

        SELECT SCOPE_IDENTITY() AS ProductID;
        RETURN;
    END;

    IF @Action = 'UPDATE'
    BEGIN
        IF EXISTS (SELECT 1 FROM dbo.tblProducts WHERE ProductName = @ProductName AND ProductID <> @ProductID)
            THROW 50022, 'Another product already uses this name.', 1;

        UPDATE dbo.tblProducts
        SET CategoryID = @CategoryID,
            ProductName = @ProductName,
            UnitPrice = @UnitPrice,
            StockQuantity = @StockQuantity,
            IsAvailable = @IsAvailable,
            UpdatedAt = SYSDATETIME()
        WHERE ProductID = @ProductID;
        RETURN;
    END;

    IF @Action = 'DELETE'
    BEGIN
        UPDATE dbo.tblProducts
        SET IsAvailable = 0, UpdatedAt = SYSDATETIME()
        WHERE ProductID = @ProductID;
        RETURN;
    END;

    IF @Action = 'SEARCH'
    BEGIN
        SELECT
            p.ProductID, p.CategoryID, c.CategoryName, p.ProductName,
            p.UnitPrice, p.StockQuantity, p.IsAvailable
        FROM dbo.tblProducts p
        INNER JOIN dbo.tblCategories c ON c.CategoryID = p.CategoryID
        WHERE (@ProductName IS NULL OR p.ProductName LIKE '%' + @ProductName + '%')
        ORDER BY p.ProductName;
        RETURN;
    END;

    THROW 50021, 'Invalid CRUD action.', 1;
END;
GO

-- ============================================================
-- END OF DATABASE SCRIPT
-- ============================================================
