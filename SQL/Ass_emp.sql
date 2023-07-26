CREATE TABLE employee_table (empno int not null,
ename varchar(10), job varchar(50), mgr int, hiredate date, 
sal int, comm int, deptno int);

INSERT INTO employee_table (empno, ename, sal, deptno) VALUES
(7369, 'smith', 800, 20);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7499, 'allen', 1600, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7521, 'ward', 1250, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7566, 'jones', 2975, 20);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7654, 'martin', 1250, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7698, 'blake', 2850, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7782, 'clark', 2450, 10);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7788, 'scott', 3000, 20);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7839, 'king', 5000, 10);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7844, 'turner', 1500, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7876, 'adams', 1100, 20);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7900, 'james', 950, 30);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7902, 'ford', 3000, 20);

INSERT INTO employee_table(empno, ename, sal, deptno) VALUES
(7934, 'miller', 1300, 10);

select * from employee_table;

UPDATE employee_table set deptno=(select deptno from employee_table where empno=7788) where empno=7698;

UPDATE employee_table set deptno=(select deptno from employee_table where empno=7698) where empno=7788;

INSERT INTO employee_table(empno, ename,job,mgr,hiredate, sal,comm, deptno) VALUES
(1000, 'allen','clerk',1001, '2001/01/12', 3000,2, 10);

INSERT INTO employee_table(empno, ename,job,mgr,hiredate, sal,comm, deptno) VALUES
(1001, 'george','analyst',null, '1992/09/08', 5000,0, 10);

INSERT INTO employee_table(empno, ename,job,mgr,hiredate, sal,comm, deptno) VALUES
(1002, 'becker','manager',1000, '1992/11/04', 2800,4, 20);

INSERT INTO employee_table(empno, ename,job,mgr,hiredate, sal,comm, deptno) VALUES
(1003, 'bill','clerk',1002, '1992/11/04', 3000,0, 20);
