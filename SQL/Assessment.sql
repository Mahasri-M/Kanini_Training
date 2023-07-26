CREATE TABLE customer_table 
(CustomerId int,
Cust_Name varchar(20),
Address1 varchar(30),
Address2 varchar(30)
);

ALTER TABLE customer_table alter column Cust_Name varchar(30);

EXEC sp_RENAME 'customer_table.Cust_Name' , 'CustomerName', 'COLUMN'

ALTER TABLE customer_table add Gender varchar(1), Age tinyint, PhoneNo int;

INSERT INTO customer_table(CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo) VALUES (1000, 'Allen','#115Chicago','#115Chicago', 'M', 25, 7878776 );
INSERT INTO customer_table(CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo) VALUES (1001, 'George','#116France','#116France', 'M', 25, 434524 );
INSERT INTO customer_table(CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo) VALUES (1002, 'Becker','#114New York','#114New York', 'M', 25, 431525 );

ALTER TABLE customer_table ALTER COLUMN CustomerId int not null;

ALTER TABLE customer_table
ADD CONSTRAINT PK_CustomerId PRIMARY KEY (CustomerId);

select CustomerId as Custid_Prim, * from customer_table;

ALTER TABLE customer_table DROP CONSTRAINT PK_CustomerId;

INSERT INTO customer_table(CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo) VALUES (1002, 'Becker','#114New York','#114New York', 'M', 45, 431525);
INSERT INTO customer_table(CustomerId, CustomerName, Address1, Address2, Gender, Age, PhoneNo) VALUES (1003, 'Nanapatekar','#115India','#115India', 'M', 45, 434524);

