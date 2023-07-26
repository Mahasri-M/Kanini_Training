use northwind;
SELECT CategoryName, Description FROM categories ORDER BY CategoryName;

SELECT ContactName, CompanyName, ContactTitle, Phone
	FROM Customers Order By ContactTitle DESC;

SELECT UPPER(FIRSTNAME) AS FirstName, UPPER(LastName) As LastName, HireDate
	FROM Employees ORDER BY HireDate DESC;

SELECT TOP 10 OrderID, OrderDate, ShippedDate, CustomerID, Freight
	FROM orders ORDER BY Freight Desc;

SELECT CompanyName, Fax, Phone,Country, HomePage
	FROM suppliers ORDER BY Country DESC, CompanyName;

SELECT ProductName, UnitPrice, QuantityPerUnit
	FROM products WHERE UnitsInStock = 0;

SELECT OrderDate, ShippedDate, CustomerID, Freight
	FROM Orders WHERE OrderDate = '1997-05-19';

SELECT FirstName,LastName,Country
	FROM employees WHERE Country <> 'USA';

SELECT EmployeeID,OrderID,CustomerID,RequiredDate,ShippedDate
	FROM Orders WHERE ShippedDate > RequiredDate;

SELECT City, CompanyName, ContactName
    FROM Customers WHERE City LIKE 'A%' OR City LIKE 'B%';

SELECT * FROM  Orders WHERE Freight > 500;
	
SELECT ProductName, UnitsInStock,UnitsOnOrder,ReorderLevel
	FROM Products WHERE UnitsInStock < ReorderLevel;

SELECT CompanyName,ContactName,Fax
	FROM Customers WHERE Fax IS NULL;

SELECT FirstName, LastName
	FROM Employees WHERE ReportsTo IS NULL;
	
SELECT CompanyName,ContactName,Fax
	FROM Customers
	WHERE Fax IS NOT NULL
	ORDER BY CompanyName;

SELECT City, CompanyName, ContactName
	FROM Customers
	WHERE City like 'b%'
	ORDER BY ContactName desc;

SELECT City, CompanyName, ContactName
	FROM Customers
	WHERE City like 'a%' 
	ORDER BY ContactName desc;

SELECT FirstName, LastName, BirthDate
	FROM Employees
	WHERE BirthDate BETWEEN '1950-01-01' AND '1959-12-31'

SELECT s.SupplierID, p.ProductName, S.CompanyName
	FROM Suppliers s
	JOIN Products p
	ON s.SupplierID = p.SupplierID
	WHERE s.CompanyName IN ('Exotic Liquids','Grandma
Kelly&#39;s Homestead,','Tokyo Traders')
	ORDER BY s.SupplierID;

SELECT * from Orders;

SELECT ShipPostalCode, OrderID, OrderDate
    FROM Orders WHERE ShipPostalCode like '%02389';	

SELECT ContactName, ContactTitle, CompanyName
	FROM Customers WHERE ContactTitle NOT LIKE '%sales%';

SELECT LastName, FirstName, City
	FROM Employees WHERE CITY NOT IN ('Seattle');

SELECT CompanyName, ContactTitle, City, Country
	FROM Customers
	WHERE Country IN ('Mexico', 'Spain')
	AND City <> 'Madrid';