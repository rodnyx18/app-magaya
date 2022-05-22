USE [MagayaOrders]
GO

IF (OBJECT_ID('dbo.FK_Customer_AddressID', 'F') IS NOT NULL)
	ALTER TABLE [dbo].[Customer] DROP CONSTRAINT FK_Customer_AddressID
GO

IF (OBJECT_ID('dbo.FK_Order_CustomerID', 'F') IS NOT NULL)
	ALTER TABLE [dbo].[Order] DROP CONSTRAINT FK_Order_CustomerID
GO

IF (OBJECT_ID('dbo.FK_Order_PaymentID', 'F') IS NOT NULL)
	ALTER TABLE [dbo].[Order] DROP CONSTRAINT FK_Order_PaymentID
GO

IF (OBJECT_ID('dbo.FK_ProductOrder_ProductID', 'F') IS NOT NULL)
	ALTER TABLE [dbo].[ProductOrder] DROP CONSTRAINT FK_ProductOrder_ProductID
GO

IF (OBJECT_ID('dbo.FK_ProductOrder_OrderID', 'F') IS NOT NULL)
	ALTER TABLE [dbo].[ProductOrder] DROP CONSTRAINT FK_ProductOrder_OrderID
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductOrder]') AND type in (N'U'))
	DROP TABLE [dbo].[ProductOrder]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
	DROP TABLE [dbo].[Product]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
	DROP TABLE [dbo].[Order]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Address]') AND type in (N'U'))
	DROP TABLE [dbo].[Address]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
	DROP TABLE [dbo].[Customer]
GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Payment]') AND type in (N'U'))
	DROP TABLE [dbo].[Payment]
GO

CREATE TABLE [dbo].[Customer](
	[ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Name] [nvarchar](255) NOT NULL,
	[Phone] [nvarchar](50) UNIQUE NOT NULL,
	[Email] [nvarchar](255) UNIQUE NOT NULL,
	[AddressID] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Address](
	[ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Street] [nvarchar](255) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[City] [nvarchar](255) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[ZipCode] [nvarchar](20) NOT NULL,
	[Country] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Order](
	[ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Number] [nvarchar](255) UNIQUE NOT NULL,
	[Date] DATETIME NOT NULL,
	[CustomerID] [int] NOT NULL,
	[PaymentID] [int] NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Payment](
	[ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Type] [nvarchar](255) UNIQUE NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[Product](
	[ID] [int] NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Description] [nvarchar](MAX) NOT NULL,
	[Price] MONEY NOT NULL,
	[Weight] FLOAT NOT NULL
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[ProductOrder](
	[ProductID] [int] NOT NULL,
	[OrderID] [int] NOT NULL,
	[Quantity] int NOT NULL,
	CONSTRAINT PK_ProductOrder PRIMARY KEY (ProductID, OrderID)
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[ProductOrder]
ADD CONSTRAINT FK_ProductOrder_ProductID FOREIGN KEY (ProductID)
    REFERENCES [dbo].[Product](ID);
GO

ALTER TABLE [dbo].[ProductOrder]
ADD CONSTRAINT FK_ProductOrder_OrderID FOREIGN KEY (OrderID)
    REFERENCES [dbo].[Order](ID);
GO

ALTER TABLE [dbo].[Customer]
ADD CONSTRAINT FK_Customer_AddressID FOREIGN KEY (AddressID)
    REFERENCES [dbo].[Address](ID);
GO

ALTER TABLE [dbo].[Order]
ADD CONSTRAINT FK_Order_CustomerID FOREIGN KEY (CustomerID)
    REFERENCES [dbo].[Customer](ID);
GO

ALTER TABLE [dbo].[Order]
ADD CONSTRAINT FK_Order_PaymentID FOREIGN KEY (PaymentID)
    REFERENCES [dbo].[Payment](ID);
GO
