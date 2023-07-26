CREATE TABLE customer (cid int primary key, cname varchar(20), caddress varchar(50), ccity varchar(20));

INSERT INTO customer VALUES (120, 'smith', '11, nehru street' , 'tirupur');

INSERT INTO customer VALUES (121, 'leena', '09, indra street' , 'selam');

INSERT INTO customer VALUES (122, 'sitra', '23, gandhi street' , 'virudhunagar');

INSERT INTO customer VALUES (123, 'maha', '54, gopal street' , 'kovai');

INSERT INTO customer VALUES (124, 'sri', '37, mahatma street' , 'chennai');

SELECT * FROM customer;

CREATE TABLE account (ano int primary key, atype varchar(20), cid int , balance int,
CONSTRAINT FK_CUSID FOREIGN KEY(CID) REFERENCES customer(cid));

INSERT INTO account VALUES (012345, 'savings', 120, 15000);

INSERT INTO account VALUES (023456, 'check', 121, 30050);

INSERT INTO account VALUES (034567, 'savings', 122, 10678);

INSERT INTO account VALUES (045678, 'savings', 123, 80000);

INSERT INTO account VALUES (056789, 'check', 124, 39456);

SELECT * FROM account;

CREATE TABLE transactions (tid int primary key, ano int, ttype varchar(10), tdate date, tamount int
CONSTRAINT FK_ACCNO FOREIGN KEY(ANO) REFERENCES account(ano));

INSERT INTO transactions VALUES (001, 012345, 'withdraw', '2023/01/10', 1000);

INSERT INTO transactions VALUES (002, 023456, 'deposit', '2023/02/08', 4500);

INSERT INTO transactions VALUES (003, 034567, 'withdraw', '2023/01/30', 2450);

INSERT INTO transactions VALUES (004, 045678, 'deposit', '2023/03/19', 3999);


SELECT * FROM transactions;

--1

SELECT balance from account where cid=123;

--2

SELECT ano from account where atype='savings';

--3

SELECT cname, caddress, ccity
FROM customer
INNER JOIN account
ON customer.cid = account.cid;

SELECT a.*, b.ano,b.balance,b.atype FROM account AS b INNER JOIN customer as a ON (a.ccity='virudhunagar'and a.cid=b.cid);

--4

SELECT atype, cid, balance
FROM account 
inner JOIN transactions
ON account.ano=transactions.ano;

SELECT b.*, c.tid, c.ttype, c.tamount FROM transactions AS c INNER JOIN account as b ON (c.tdate='2023/03/19' and b.ano=c.ano);

--5

CREATE TRIGGER update_balance
ON transactions
AFTER INSERT
AS
BEGIN
    UPDATE ACCOUNT
    SET BALANCE = balance + t.tamount
    from account a inner join TRANSACTIONS t on t.ano=a.ano;
END;

insert into TRANSACTIONS values(005, 056789, 'Deposit', '2023/02/20', 544);

SELECT * FROM account;

--6

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mahasri
-- Create date: 
-- Description:	
-- =============================================
CREATE or alter FUNCTION udf_CityOfLeena(@cname nvarchar(20))
RETURNS TABLE  
AS
RETURN 
(
	select CCITY from CUSTOMER where cname=@cname
)
GO

select * from udf_CityOfLeena('Leena');
