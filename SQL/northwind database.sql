
-- Northwind Data
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
	"Notes" "ntext" NULL ,
	"ReportsTo" "int" NULL ,
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

CREATE TABLE "Categories" (
	"CategoryID" "int" IDENTITY (1, 1) NOT NULL ,
	"CategoryName" nvarchar (15) NOT NULL ,
	"Description" "ntext" NULL ,
	CONSTRAINT "PK_Categories" PRIMARY KEY  CLUSTERED 
	(
		"CategoryID"
	)
)

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

CREATE TABLE "Shippers" (
	"ShipperID" "int" IDENTITY (1, 1) NOT NULL ,
	"CompanyName" nvarchar (40) NOT NULL ,
	"Phone" nvarchar (24) NULL ,
	CONSTRAINT "PK_Shippers" PRIMARY KEY  CLUSTERED 
	(
		"ShipperID"
	)
)

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

-- Customer Insertion

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

-- Categories Insertion

INSERT "Categories"("CategoryName","Description") VALUES('Beverages','Soft drinks, coffees, teas, beers, and ales');
INSERT "Categories"("CategoryName","Description") VALUES('Condiments','Sweet and savory sauces, relishes, spreads, and seasonings');
INSERT "Categories"("CategoryName","Description") VALUES('Confections','Desserts, candies, and sweet breads');
INSERT "Categories"("CategoryName","Description") VALUES('Dairy Products','Cheeses');
INSERT "Categories"("CategoryName","Description") VALUES('Grains/Cereals','Breads, crackers, pasta, and cereal');
INSERT "Categories"("CategoryName","Description") VALUES('Meat/Poultry','Prepared meats');
INSERT "Categories"("CategoryName","Description") VALUES('Produce','Dried fruit and bean curd');
INSERT "Categories"("CategoryName","Description") VALUES('Seafood','Seaweed and fish');

-- Employees Insertion

INSERT "Employees"("LastName","FirstName","Title","TitleOfCourtesy","BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo") 
VALUES('Fuller','Andrew','Vice President, Sales','Dr.','02/19/1952','08/14/1992','908 W. Capital Way','Tacoma','WA','98401','USA','(206) 555-9482','3457',
'Andrew received his BTS commercial in 1974 and a Ph.D. in international marketing from the University of Dallas in 1981.  He is fluent in French and Italian and reads German.  He joined the company as a sales representative, was promoted to sales manager in January 1992 and to vice president of sales in March 1993.  Andrew is a member of the Sales Management Roundtable, the Seattle Chamber of Commerce, and the Pacific Rim Importers Association.',NULL);

INSERT "Employees"("LastName","FirstName","Title","TitleOfCourtesy","BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo") 
VALUES('Davolio','Nancy','Sales Representative','Ms.','12/08/1948','05/01/1992','507 - 20th Ave. E.
Apt. 2A','Seattle','WA','98122','USA','(206) 555-9857','5467','Education includes a BA in psychology from Colorado State University in 1970.  She also completed "The Art of the Cold Call."Nancy is a member of Toastmasters International.',1);

INSERT "Employees"("LastName","FirstName","Title","TitleOfCourtesy","BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo") 
VALUES('Leverling','Janet','Sales Representative','Ms.','08/30/1963','04/01/1992','722 Moss Bay Blvd.','Kirkland','WA','98033','USA','(206) 555-3412','3355',
'Janet has a BS degree in chemistry from Boston College (1984).  She has also completed a certificate program in food retailing management.  Janet was hired as a sales associate in 1991 and promoted to sales representative in February 1992.',2);

INSERT "Employees"("LastName","FirstName","Title","TitleOfCourtesy","BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo") 
 VALUES('Peacock','Margaret','Sales Representative','Mrs.','09/19/1937','05/03/1993','4110 Old Redmond Rd.','Redmond','WA','98052','USA','(206) 555-8122','5176',
 'Margaret holds a BA in English literature from Concordia College (1958) and an MA from the American Institute of Culinary Arts (1966).  She was assigned to the London office temporarily from July through November 1992.',2);

 INSERT "Employees"("LastName","FirstName","Title","TitleOfCourtesy","BirthDate","HireDate","Address","City","Region","PostalCode","Country","HomePhone","Extension","Notes","ReportsTo") 
VALUES('Buchanan','Steven','Sales Manager','Mr.','03/04/1955','10/17/1993','14 Garrett Hill','London',NULL,'SW1 8JR','UK','(71) 555-4848','3453',
'Steven Buchanan graduated from St. Andrews University, Scotland, with a BSC degree in 1976.  Upon joining the company as a sales representative in 1992, he spent 6 months in an orientation program at the Seattle office and then returned to his permanent post in London.  He was promoted to sales manager in March 1993.  Mr. Buchanan has completed the courses "Successful Telemarketing" and "International Sales Management."  He is fluent in French.',3);

-- Shippers Insertion
INSERT "Shippers"("CompanyName","Phone") VALUES('Speedy Express','(503) 555-9831')
INSERT "Shippers"("CompanyName","Phone") VALUES('United Package','(503) 555-3199')
INSERT "Shippers"("CompanyName","Phone") VALUES('Federal Shipping','(503) 555-9931')

-- Suppliers Insertion

INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Exotic Liquids','Charlotte Cooper','Purchasing Manager','49 Gilbert St.','London',NULL,'EC1 4SD','UK','(171) 555-2222',NULL,NULL)
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('New Orleans Cajun Delights','Shelley Burke','Order Administrator','P.O. Box 78934','New Orleans','LA','70117','USA','(100) 555-4822',NULL,'#CAJUN.HTM#')
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Grandma Kelly''s Homestead','Regina Murphy','Sales Representative','707 Oxford Rd.','Ann Arbor','MI','48104','USA','(313) 555-5735','(313) 555-3349',NULL)
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Tokyo Traders','Yoshi Nagase','Marketing Manager','9-8 Sekimai Musashino-shi','Tokyo',NULL,'100','Japan','(03) 3555-5011',NULL,NULL)
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Cooperativa de Quesos ''Las Cabras''','Antonio del Valle Saavedra','Export Administrator','Calle del Rosal 4','Oviedo','Asturias','33007','Spain','(98) 598 76 54',NULL,NULL)
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Mayumi''s','Mayumi Ohno','Marketing Representative','92 Setsuko Chuo-ku','Osaka',NULL,'545','Japan','(06) 431-7877',NULL,'Mayumi''s (on the World Wide Web)#http://www.microsoft.com/accessdev/sampleapps/mayumi.htm#')
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Pavlova, Ltd.','Ian Devling','Marketing Manager','74 Rose St. Moonie Ponds','Melbourne','Victoria','3058','Australia','(03) 444-2343','(03) 444-6588',NULL)
INSERT "Suppliers"("CompanyName","ContactName","ContactTitle","Address","City","Region","PostalCode","Country","Phone","Fax","HomePage") VALUES('Specialty Biscuits, Ltd.','Peter Wilson','Sales Representative','29 King''s Way','Manchester',NULL,'M14 GSD','UK','(161) 555-4448',NULL,NULL)

-- Orders Insertion

INSERT INTO "Orders"
("CustomerID","EmployeeID","OrderDate","RequiredDate",
	"ShippedDate","ShipVia","Freight","ShipName","ShipAddress",
	"ShipCity","ShipRegion","ShipPostalCode","ShipCountry")
VALUES (N'BOLID',3,'7/8/1996','8/5/1996','7/15/1996',1,41.34,
	N'Victuailles en stock',N'2, rue du Commerce',N'Lyon',
	NULL,N'69004',N'France');

INSERT INTO "Orders"
("CustomerID","EmployeeID","OrderDate","RequiredDate",
	"ShippedDate","ShipVia","Freight","ShipName","ShipAddress",
	"ShipCity","ShipRegion","ShipPostalCode","ShipCountry")
VALUES (N'ANTON',5,'7/4/1996','8/1/1996','7/16/1996',3,32.38,
	N'Vins et alcools Chevalier',N'59 rue de l''Abbaye',N'Reims',
	NULL,N'51100',N'France')
INSERT INTO "Orders"
("CustomerID","EmployeeID","OrderDate","RequiredDate",
	"ShippedDate","ShipVia","Freight","ShipName","ShipAddress",
	"ShipCity","ShipRegion","ShipPostalCode","ShipCountry")
VALUES (N'BERGS',6,'7/5/1996','8/16/1996','7/10/1996',1,11.61,
	N'Toms Spezialitäten',N'Luisenstr. 48',N'Münster',
	NULL,N'44087',N'Germany')
INSERT INTO "Orders"
("CustomerID","EmployeeID","OrderDate","RequiredDate",
	"ShippedDate","ShipVia","Freight","ShipName","ShipAddress",
	"ShipCity","ShipRegion","ShipPostalCode","ShipCountry")
VALUES (N'AROUT',4,'7/8/1996','8/5/1996','7/12/1996',2,65.83,
	N'Hanari Carnes',N'Rua do Paço, 67',N'Rio de Janeiro',
	N'RJ',N'05454-876',N'Brazil')

-- Products Insertion

INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Manjimup Dried Apples',1,7,'50 - 300 g pkgs.',53,20,0,10,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Filo Mix',2,5,'16 - 2 kg boxes',7,38,0,25,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Perth Pasties',3,6,'48 pieces',32.8,0,0,0,1)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Tourtière',4,6,'16 pies',7.45,21,0,10,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Pâté chinois',5,6,'24 boxes x 2 pies',24,115,0,20,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Gnocchi di nonna Alice',6,5,'24 - 250 g pkgs.',38,21,10,30,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Ravioli Angelo',7,5,'24 - 250 g pkgs.',19.5,36,0,20,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Escargots de Bourgogne',8,8,'24 pieces',13.25,62,0,20,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Raclette Courdavault',1,4,'5 kg pkg.',55,79,0,0,0)
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Camembert Pierrot',2,4,'15 - 300 g rounds',34,19,0,0,0)


-- Order Details Insertion

INSERT "Order Details" VALUES(1,2,14,12,0)
INSERT "Order Details" VALUES(2,3,9.8,10,0)
INSERT "Order Details" VALUES(4,3,34.8,5,0)
INSERT "Order Details" VALUES(1,4,18.6,9,0)
INSERT "Order Details" VALUES(2,5,42.4,40,0)
INSERT "Order Details" VALUES(4,1,7.7,10,0)
INSERT "Order Details" VALUES(1,5,42.4,35,0.15)
INSERT "Order Details" VALUES(2,6,16.8,15,0.15)
INSERT "Order Details" VALUES(4,4,16.8,6,0.05)
INSERT "Order Details" VALUES(9,5,15.6,15,0.05)

select * from Categories;
select * from Customers;
select * from Employees;
select * from Orders;
select * from Suppliers;
select * from Products;
select * from [Order Details];

-- SQL server aggregate functions
-- AVG, COUNT, MAX, MIN, STDEV, VAR

select min(UnitPrice) Unit_price from [Order Details];

select max(UnitPrice) Unit_price from [Order Details];

select round(avg(UnitPrice), 0) Unit_price from [Order Details];

select ceiling(avg(UnitPrice)) Unit_price from [Order Details];

select floor(avg(UnitPrice)) Unit_price from [Order Details];

select lower(CategoryName) cname from Categories where CategoryName LIKE 'B%';

select * from Categories;

select GETDATE();

select name from sys.tables;

select count(*) from products where UnitPrice>10;

select sum(Unitprice) Cost from Products; 

select CURRENT_TIMESTAMP today;

select CURRENT_USER;

select DATEADD(MM, 1, getdate());
select DATEADD(YY, 5, getdate());

select DATEADD(YY, 5, Employees.BirthDate) from Employees;

select DATEdiff(yy, BirthDate, GETDATE())age from Employees;

select abs(DATEdiff(yy, GETDATE(), BirthDate))age from Employees;

select ISDATE('2020-10-22') chk;

select sqrt(25);

select ltrim ('   Hi  ');

select len('Raghul');

select SUBSTRING('ABCDEF', 2, 3);   -- Index starts with 1

select charindex('H', 'hehllo');

use northwind;

select ProductName from Products where ProductName LIKE 'P%' order by CategoryID, SupplierID desc;

select sum(UnitPrice), CategoryID from Products where CategoryID=4 group by CategoryID;

select sum(UnitPrice), CategoryID from Products group by CategoryID HAVING sum(UnitPrice)>60;

INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Dried Aples',3,1,'50 - 300 g pkgs.',54,23,0,10,1);
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Apple cake',4,2,'50 - 30 g pkgs.',50,20,0,20,0);
INSERT "Products"("ProductName","SupplierID","CategoryID","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsOnOrder","ReorderLevel","Discontinued") VALUES('Dried Aples',5,3,'50 - 200 g pkgs.',51,24,0,25,1);

select sum(SupplierID), CategoryID from Products group by SupplierID, CategoryID;

select * from Products;

select * from Orders;

select ShipCountry, ShipCity, ShipVia, sum(Freight) from Orders group by ShipCountry, ShipCity, ShipVia;

