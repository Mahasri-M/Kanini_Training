create table dept (deptno int, dname nvarchar(20), 
CONSTRAINT "PK_DEPT" PRIMARY KEY("deptno"));

create table emp(eno int, ename nvarchar(25) not null, ph int not null, deptno int, desig nvarchar(20),
CONSTRAINT "PK_EMP" PRIMARY KEY("eno"),
CONSTRAINT "FK_EMP_DEPT" FOREIGN KEY("deptno")
REFERENCES "dbo"."DEPT"("deptno")
);

use northwind;