use northwind;
CREATE TABLE "Employees" (
	"EmployeeID" "int" IDENTITY (1, 1) NOT NULL ,
	"LastName" nvarchar (20) NOT NULL ,
	"FirstName" nvarchar (10) NOT NULL ,
	"Title" nvarchar (30) NULL ,
	"TitleOfCourtesy" nvarchar (25) NULL ,
	"BirthDate" "datetime" NULL ,
	"HireDate" "datetime" NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"HomePhone" nvarchar (24) NULL ,
	"Extension" nvarchar (4) NULL ,
	"Photo" "image" NULL ,
	"Notes" "ntext" NULL ,
	"ReportsTo" "int" NULL ,
	"PhotoPath" nvarchar (255) NULL ,
	CONSTRAINT "PK_Employees" PRIMARY KEY  CLUSTERED 
	(
		"EmployeeID"
	),
	CONSTRAINT "FK_Employees_Employees" FOREIGN KEY 
	(
		"ReportsTo"
	) REFERENCES "dbo"."Employees" (
		"EmployeeID"
	),
	CONSTRAINT "CK_Birthdate" CHECK (BirthDate < getdate())
)
select * from Employees;

CREATE TABLE "Categories" (
	"CategoryID" "int" IDENTITY (1, 1) NOT NULL ,
	"CategoryName" nvarchar (15) NOT NULL ,
	"Description" "ntext" NULL ,
	"Picture" "image" NULL ,
	CONSTRAINT "PK_Categories" PRIMARY KEY  CLUSTERED 
	(
		"CategoryID"
	)
)

select * from Categories;

CREATE TABLE "Customers" (
	"CustomerID" nchar (5) NOT NULL ,
	"CompanyName" nvarchar (40) NOT NULL ,
	"ContactName" nvarchar (30) NULL ,
	"ContactTitle" nvarchar (30) NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"Phone" nvarchar (24) NULL ,
	"Fax" nvarchar (24) NULL ,
	CONSTRAINT "PK_Customers" PRIMARY KEY  CLUSTERED 
	(
		"CustomerID"
	)
)

select * from Customers;

CREATE TABLE "Shippers" (
	"ShipperID" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyName" nvarchar (40) NOT NULL ,
	"Phone" nvarchar (24) NULL ,
	CONSTRAINT "PK_Shippers" PRIMARY KEY  CLUSTERED 
	(
		"ShipperID"
	)
)
 select * from Shippers;

 CREATE TABLE "Suppliers" (
	"SupplierID" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyName" nvarchar (40) NOT NULL ,
	"ContactName" nvarchar (30) NULL ,
	"ContactTitle" nvarchar (30) NULL ,
	"Address" nvarchar (60) NULL ,
	"City" nvarchar (15) NULL ,
	"Region" nvarchar (15) NULL ,
	"PostalCode" nvarchar (10) NULL ,
	"Country" nvarchar (15) NULL ,
	"Phone" nvarchar (24) NULL ,
	"Fax" nvarchar (24) NULL ,
	"HomePage" "ntext" NULL ,
	CONSTRAINT "PK_Suppliers" PRIMARY KEY  CLUSTERED 
	(
		"SupplierID"
	)
)

select * from Suppliers;

CREATE TABLE "Orders" (
	"OrderID" "int" IDENTITY (1, 1) NOT NULL ,
	"CustomerID" nchar (5) NULL ,
	"EmployeeID" "int" NULL ,
	"OrderDate" "datetime" NULL ,
	"RequiredDate" "datetime" NULL ,
	"ShippedDate" "datetime" NULL ,
	"ShipVia" "int" NULL ,
	"Freight" "money" NULL CONSTRAINT "DF_Orders_Freight" DEFAULT (0),
	"ShipName" nvarchar (40) NULL ,
	"ShipAddress" nvarchar (60) NULL ,
	"ShipCity" nvarchar (15) NULL ,
	"ShipRegion" nvarchar (15) NULL ,
	"ShipPostalCode" nvarchar (10) NULL ,
	"ShipCountry" nvarchar (15) NULL ,
	CONSTRAINT "PK_Orders" PRIMARY KEY  CLUSTERED 
	(
		"OrderID"
	),
	CONSTRAINT "FK_Orders_Customers" FOREIGN KEY 
	(
		"CustomerID"
	) REFERENCES "dbo"."Customers" (
		"CustomerID"
	),
	CONSTRAINT "FK_Orders_Employees" FOREIGN KEY 
	(
		"EmployeeID"
	) REFERENCES "dbo"."Employees" (
		"EmployeeID"
	),
	CONSTRAINT "FK_Orders_Shippers" FOREIGN KEY 
	(
		"ShipVia"
	) REFERENCES "dbo"."Shippers" (
		"ShipperID"
	)
)

select * from Orders;

CREATE TABLE "Products" (
	"ProductID" "int" IDENTITY (1, 1) NOT NULL ,
	"ProductName" nvarchar (40) NOT NULL ,
	"SupplierID" "int" NULL ,
	"CategoryID" "int" NULL ,
	"QuantityPerUnit" nvarchar (20) NULL ,
	"UnitPrice" "money" NULL CONSTRAINT "DF_Products_UnitPrice" DEFAULT (0),
	"UnitsInStock" "smallint" NULL CONSTRAINT "DF_Products_UnitsInStock" DEFAULT (0),
	"UnitsOnOrder" "smallint" NULL CONSTRAINT "DF_Products_UnitsOnOrder" DEFAULT (0),
	"ReorderLevel" "smallint" NULL CONSTRAINT "DF_Products_ReorderLevel" DEFAULT (0),
	"Discontinued" "bit" NOT NULL CONSTRAINT "DF_Products_Discontinued" DEFAULT (0),
	CONSTRAINT "PK_Products" PRIMARY KEY  CLUSTERED 
	(
		"ProductID"
	),
	CONSTRAINT "FK_Products_Categories" FOREIGN KEY 
	(
		"CategoryID"
	) REFERENCES "dbo"."Categories" (
		"CategoryID"
	),
	CONSTRAINT "FK_Products_Suppliers" FOREIGN KEY 
	(
		"SupplierID"
	) REFERENCES "dbo"."Suppliers" (
		"SupplierID"
	),
	CONSTRAINT "CK_Products_UnitPrice" CHECK (UnitPrice >= 0),
	CONSTRAINT "CK_ReorderLevel" CHECK (ReorderLevel >= 0),
	CONSTRAINT "CK_UnitsInStock" CHECK (UnitsInStock >= 0),
	CONSTRAINT "CK_UnitsOnOrder" CHECK (UnitsOnOrder >= 0)
)

select * from Products;

CREATE TABLE "Order Details" (
	"OrderID" "int" NOT NULL ,
	"ProductID" "int" NOT NULL ,
	"UnitPrice" "money" NOT NULL CONSTRAINT "DF_Order_Details_UnitPrice" DEFAULT (0),
	"Quantity" "smallint" NOT NULL CONSTRAINT "DF_Order_Details_Quantity" DEFAULT (1),
	"Discount" "real" NOT NULL CONSTRAINT "DF_Order_Details_Discount" DEFAULT (0),
	CONSTRAINT "PK_Order_Details" PRIMARY KEY  CLUSTERED 
	(
		"OrderID",
		"ProductID"
	),
	CONSTRAINT "FK_Order_Details_Orders" FOREIGN KEY 
	(
		"OrderID"
	) REFERENCES "dbo"."Orders" (
		"OrderID"
	),
	CONSTRAINT "FK_Order_Details_Products" FOREIGN KEY 
	(
		"ProductID"
	) REFERENCES "dbo"."Products" (
		"ProductID"
	),
	CONSTRAINT "CK_Discount" CHECK (Discount >= 0 and (Discount <= 1)),
	CONSTRAINT "CK_Quantity" CHECK (Quantity > 0),
	CONSTRAINT "CK_UnitPrice" CHECK (UnitPrice >= 0)
)

select * from [Order Details];

INSERT "Customers" VALUES('ALFKI','Alfreds Futterkiste','Maria Anders','Sales Representative','Obere Str. 57','Berlin',NULL,'12209','Germany','030-0074321','030-0076545')
INSERT "Customers" VALUES('ANATR','Ana Trujillo Emparedados y helados','Ana Trujillo','Owner','Avda. de la Constitución 2222','México D.F.',NULL,'05021','Mexico','(5) 555-4729','(5) 555-3745')
INSERT "Customers" VALUES('ANTON','Antonio Moreno Taquería','Antonio Moreno','Owner','Mataderos  2312','México D.F.',NULL,'05023','Mexico','(5) 555-3932',NULL)
INSERT "Customers" VALUES('AROUT','Around the Horn','Thomas Hardy','Sales Representative','120 Hanover Sq.','London',NULL,'WA1 1DP','UK','(171) 555-7788','(171) 555-6750')
INSERT "Customers" VALUES('BERGS','Berglunds snabbköp','Christina Berglund','Order Administrator','Berguvsvägen  8','Luleå',NULL,'S-958 22','Sweden','0921-12 34 65','0921-12 34 67')
INSERT "Customers" VALUES('BLAUS','Blauer See Delikatessen','Hanna Moos','Sales Representative','Forsterstr. 57','Mannheim',NULL,'68306','Germany','0621-08460','0621-08924')
INSERT "Customers" VALUES('BLONP','Blondesddsl père et fils','Frédérique Citeaux','Marketing Manager','24, place Kléber','Strasbourg',NULL,'67000','France','88.60.15.31','88.60.15.32')
INSERT "Customers" VALUES('BOLID','Bólido Comidas preparadas','Martín Sommer','Owner','C/ Araquil, 67','Madrid',NULL,'28023','Spain','(91) 555 22 82','(91) 555 91 99')
INSERT "Customers" VALUES('BONAP','Bon app''','Laurence Lebihan','Owner','12, rue des Bouchers','Marseille',NULL,'13008','France','91.24.45.40','91.24.45.41')
INSERT "Customers" VALUES('BOTTM','Bottom-Dollar Markets','Elizabeth Lincoln','Accounting Manager','23 Tsawassen Blvd.','Tsawassen','BC','T2F 8M4','Canada','(604) 555-4729','(604) 555-3745')
INSERT "Customers" VALUES('CACTU','Cactus Comidas para llevar','Patricio Simpson','Sales Agent','Cerrito 333','Buenos Aires',NULL,'1010','Argentina','(1) 135-5555','(1) 135-4892')
