USE [MagayaOrders]
GO

-- Payment
INSERT INTO [dbo].[Payment] ([Type]) VALUES ('Cash')
INSERT INTO [dbo].[Payment] ([Type]) VALUES ('Credit Card')
INSERT INTO [dbo].[Payment] ([Type]) VALUES ('Check')
INSERT INTO [dbo].[Payment] ([Type]) VALUES ('Other')

-- Address
INSERT INTO [dbo].[Address] ([Street],[Number],[City],[State],[ZipCode],[Country]) VALUES ('Boul Cartier Est','1995','Montreal','Quebec','H7G3F5','Canada')
INSERT INTO [dbo].[Address] ([Street],[Number],[City],[State],[ZipCode],[Country]) VALUES ('Lake Dr','8765','Miami','FL','33178','USA')
INSERT INTO [dbo].[Address] ([Street],[Number],[City],[State],[ZipCode],[Country]) VALUES ('Summit Place','151678','Naples','Florida','23125','USA')

-- Customer
INSERT INTO [dbo].[Customer] ([Name],[Phone],[Email],[AddressID]) VALUES ('Rodny Castro','5144318989','rodny@email.com',1)
INSERT INTO [dbo].[Customer] ([Name],[Phone],[Email],[AddressID]) VALUES ('Jose Arturo Garcia','7165461290','josearturo@hotmail.com',2)
INSERT INTO [dbo].[Customer] ([Name],[Phone],[Email],[AddressID]) VALUES ('Armando Benitez','8431245451','armandob@delaluna.com',3)

--Product
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Shoes AbX',130.99,0.6)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Shoes A',137.99,0.5)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Shoes Zx',189.99,0.4)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Shoes WX',100,1.1)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('AbX',130.99,0.6)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('A',137.99,0.5)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Zx',189.99,0.4)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('WX',100,1.1)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Hat AbX',130.99,0.6)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Hat A',137.99,0.5)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Hat Zx',189.99,0.4)
INSERT INTO [dbo].[Product] ([Description],[Price],[Weight]) VALUES ('Hat WX',100,1.1)

-- Order
INSERT INTO [dbo].[Order] ([Number],[Date],[CustomerID],[PaymentID]) VALUES ('10001','2022-01-29',1,2)
INSERT INTO [dbo].[Order] ([Number],[Date],[CustomerID],[PaymentID]) VALUES ('10002','2022-02-14',1,2)
INSERT INTO [dbo].[Order] ([Number],[Date],[CustomerID],[PaymentID]) VALUES ('10003','2022-03-05',1,2)
INSERT INTO [dbo].[Order] ([Number],[Date],[CustomerID],[PaymentID]) VALUES ('10004','2022-04-11',3,3)
INSERT INTO [dbo].[Order] ([Number],[Date],[CustomerID],[PaymentID]) VALUES ('10005','2022-02-14',3,3)

-- ProductOrder
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (1,1,2)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (2,1,25)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (3,1,50)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (2,2,25)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (2,3,200)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (4,4,1)
INSERT INTO [dbo].[ProductOrder] ([ProductID],[OrderID],[Quantity]) VALUES (1,5,46)

GO


