create table customers (custid int primary key,custname varchar(10) , age tinyint,phone varchar(10));
insert into customers values(100, 'smith',35,'9080134954')
insert into customers values(101, 'allen',36,'9080137894')
insert into customers values(102, 'ben',29,'9788234954')
insert into customers values(103, 'harry',45,'9873234954')
insert into customers values(104, 'peter',30,'9951144954')

create table loan (loanid int primary key,amount money ,custid int,Emi money);
insert into loan values(1000, 50000,100,50000)
insert into loan values(1001, 40000,101,90000)
insert into loan values(1002,25000,102,7000)
insert into loan values(1003, 14000,103,14000)
insert into loan values(1004,150000,104,60000)

--1
select loanid from loan where emi=50000

--2
select emi,count(loanid)'No Of Loan'  from loan group by amount,emi

--3
CREATE VIEW v1 AS
SELECT count(loanid)
FROM loan


--4
select emi from loan l join customers c on l.custid=c.custid where custname='smith'

--5
alter proc sample1(@loanID int)
as
begin
declare @amount varchar(20),
@custid varchar(20)
set  @amount=(select amount from loan where loanid=@loanID)
set @custid =(select custid from loan where loanid=@loanID)
print 'CustomerId '+(convert (varchar(20),@custid))
print 'Amount '+@amount
end

sample1 '1001'

--6
alter function samplefunc(@custid int)
returns money
begin
declare @amount money
set @amount=(select amount from loan where custid=@custid)
return @amount
end

select dbo.samplefunc(100)'Amount'