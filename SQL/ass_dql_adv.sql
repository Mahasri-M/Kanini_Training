select sum(UnitPrice*Quantity) "Total revenues in 1997" from [Order Details] od 
inner join Orders o on od.OrderID = o.OrderID where YEAR(o.OrderDate)=1997;

select c.CustomerID, sum(od.Quantity*od.UnitPrice) 'AMOUNT PAID' from Customers c 
inner join Orders o on c.CustomerID = o.CustomerID 
inner join [Order Details] od on o.OrderID=od.OrderID group by c.CustomerID;


select TOP 10 p.ProductID, sum(od.Quantity) 'TotalQuantity' from Products p 
inner join [Order Details] od on p.ProductID=od.ProductID group by p.ProductID order by TotalQuantity desc;

select c.CustomerID, sum(od.Quantity*od.UnitPrice) 'TOTAL REVENUES PER CUSTOMER' from Customers c 
inner join Orders o on c.CustomerID = o.CustomerID 
inner join [Order Details] od on o.OrderID=od.OrderID group by c.CustomerID;

select c.CustomerID from Customers c 
inner join Orders o on c.CustomerID=o.CustomerID 
inner join [Order Details] od on o.OrderID=od.OrderID where c.Country='UK' and (od.UnitPrice*od.Quantity)>1000;

select OrderID, count(*) 'NumberofOrders' from [Order Details] group by OrderID order by NumberofOrders Desc;

select s.SupplierID, p.ProductName, s.CompanyName from Suppliers s 
inner join Products p on s.SupplierID = p.SupplierID where s.CompanyName 
in ('Exotic Liquids', 'Specialty Biscuits, Ltd.', 'Escargots Nouveaux') order by s.SupplierID;

select ShipPostalCode, OrderID, OrderDate, RequiredDate, ShippedDate, ShipAddress From Orders where ShipPostalCode LIKE '98124%';

select ContactName, ContactTitle, CompanyName from Customers where ContactTitle not like '%sales%';

select LastName, FirstName, City from Employees where City <> 'Seattle';

select CompanyName, ContactTitle, city, Country from Customers where city <> 'Madrid' or city in ('Mexico', 'Spain');

select ContactName from Customers where ContactName not like '_a%';

select top 1 round(UnitPrice, 0) 'AveragePrice', UnitPrice*UnitsInStock 'TotalStock', UnitsOnOrder 'MaxOrder' 
from Products order by MaxOrder;

select s.SupplierID, s.CompanyName, c.CategoryName, p.ProductName, p.UnitPrice from Suppliers s 
inner join Products p on s.SupplierID = p.SupplierID 
inner join Categories c on c.CategoryID = p.CategoryID;

select CustomerID, sum(Freight) 'Sum of Freight' from Orders group by CustomerID HAVING sum(Freight)>200;

select o.OrderID, c.ContactName, od.UnitPrice, od.Quantity, od.Discount from Customers c 
inner join Orders o on c.CustomerID = o.CustomerID 
inner join [Order Details] od on o.OrderID=od.OrderID where od.Discount <> 0;

select E1.EmployeeID, concat(E1.LastName, E1.FirstName) 'Employee', concat(E2.LastName, E2.FirstName) 'Manager' from  Employees E1 
join Employees E2 on E2.EmployeeID=E1.ReportsTo order by e1.EmployeeID;

select avg(UnitPrice)'AveragePrice', min(UnitPrice)'MinimumPrice', max(UnitPrice)'MaximumPrice' from Products;

select SUBSTRING(CategoryName, 1, 5) 'ShortInfo' from Categories;

SELECT c.CompanyName, COUNT(o.OrderID) AS "Number of orders since Dec 31, 1994"
FROM Customers c
INNER JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE o.OrderDate >= '1994-12-31'
GROUP BY c.CompanyName
HAVING COUNT(o.OrderID) > 10
ORDER BY COUNT(o.OrderID) DESC;
