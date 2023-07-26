use sample;
select * from emp;
select * from dept;

insert into dept values (10,'cse');
insert into dept values (20,'mech');
insert into dept values (30,'ece');
insert into dept values (40,'mech');
 
insert into emp values (101,'aaa',3456,10,'mgr');
insert into emp values (102,'bbb',3456,20,'mgr');
insert into emp values (103,'ccc',3456,10,'clerk');
insert into emp values (104,'ddd',3456,30,'mgr');



select ename
from emp 
inner join dept
on emp.deptno = dept.deptno and dept.dname ='cse';


select ename
from emp 
inner join dept
on dept.dname = 'cse';


select ename
from emp 
inner join dept
on emp.deptno = dept.deptno and dept.dname !='cse';

select ename
from emp e
inner join dept d
on e.deptno = d.deptno and d.dname !='cse';

select e.ename, d.dname
from emp e
inner join dept d
on e.deptno = d.deptno and d.dname !='cse';

select e.ename 'emp_name', d.dname 'dept_name', e.deptno 'dept_no'
from emp e
inner join dept d
on e.deptno = d.deptno and d.dname !='cse';

select e.ename 'emp_name', d.dname 'dept_name', e.deptno 'dept_no'
from emp e
inner join dept d
on e.deptno = d.deptno ;

select e.ename 'emp_name', d.dname 'dept_name', e.deptno 'dept_no'
from emp e
right outer join dept d
on e.deptno = d.deptno ;

select e.ename 'emp_name', d.dname 'dept_name', e.deptno 'dept_no'
from emp e
full outer join dept d
on e.deptno = d.deptno ;

select e.ename 'emp_name', d.dname 'dept_name', e.deptno 'dept_no'
from emp e
cross join dept d;

