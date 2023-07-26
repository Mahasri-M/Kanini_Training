use sample;
--dml trigger
CREATE TABLE EmpLog (
	LogID int IDENTITY(1,1) NOT NULL,
	EmpID int NOT NULL,
	Operation nvarchar(10) NOT NULL,
	UpdatedDate Datetime NOT NULL	
)

create or alter trigger dbo.trgEmployeeInsert
ON dbo.emp
FOR INSERT 
AS
INSERT INTO dbo.EmpLog (EmpId, Operation, UpdatedDate)
SELECT eno, 'INSERT', GETDATE() FROM INSERTED;

select * from emp;
select * from dbo.EmpLog;

INSERT INTO emp VALUES (105, 'Sri', 994070, 30, 'SUP');

create trigger dbo.trgEmployeeUpdate
ON dbo.emp
AFTER UPDATE 
AS
INSERT INTO dbo.EmpLog (EmpId, Operation, UpdatedDate)
SELECT eno, 'UPDATE', GETDATE() FROM DELETED;

UPDATE emp set desig='manager' where eno='101';

create trigger dbo.trgEmployeeDelete
ON dbo.emp
INSTEAD OF DELETE 
AS
INSERT INTO dbo.EmpLog (EmpId, Operation, UpdatedDate)
SELECT eno, 'DELETE', GETDATE() FROM DELETED;

DELETE FROM emp where eno=104;

--ddl trigger

create table dbo.TableLog(
LogId int IDENTITY(1,1) PRIMARY KEY,
EventVal xml not null,
EventDate datetime not null,
ChangedBy sysname not null
);

create trigger trgTableChanges
on database
for 
create_table, alter_table,drop_table
as
begin
insert into TableLog (EventVal, EventDate, ChangedBy)
Values (EVENTDATA(), GETDATE(), USER);
end;

create table dummy(testId int identity(1,1) primary key,
testname sysname not null);

select * from TableLog;

DROP TABLE dummy;

--login

create or alter trigger trgLoginConnection 
on all server  
for logon
as
begin
if (original_login()=N'sa' and
(select count(*) from sys.dm_exec_sessions 
where is_user_process=1 and
original_login_name=N'sa')>2)
rollback;
end;