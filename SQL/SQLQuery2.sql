insert into stud_details values(1, 'aaa', 9, '2023/03/01', 638462, 'aaa@gmail.com');

select * from stud_details;

insert into stud_details (rno, phno, sname) values(2, 8, 'bbb');

insert into stud_details (rno, phno, sname) values(3, 8, 'bbb');

update stud_details set dob = '2023/02/22', pincode = 678902 where rno=2;

update stud_details set sname='ccc' , phno=7 where rno=3;

update stud_details set dob = '2023/02/22', pincode = 678902, rno=10 where rno=2;

delete from stud_details where rno=10;

commit;

begin transaction;

insert into stud_details (rno, phno, sname) values(4, 7, 'dd');

rollback;

select rno as Roll_No, sname as Student_Name 
from stud_details
where rno<=3 and sname='ccc';

select rno as Roll_No, sname as Student_Name 
from stud_details
where dob between '2020/01/01' and '2024/02/23';

select rno as Roll_No, sname as Student_Name 
from stud_details
where rno in (1,4);

select rno as Roll_No, sname as Student_Name 
from stud_details
where sname not in ('bbb', 'ddd');

select rno as Roll_No, sname as Student_Name 
from stud_details
where sname like 'c%';

select rno as Roll_No, sname as Student_Name 
from stud_details
where sname like 'd_';

select rno as Roll_No, sname as Student_Name 
from stud_details
where sname like '___';

select rno as Roll_No, sname as Student_Name , dob as dob
from stud_details
where sname in ('dd','aaa','ccc')
order by dob desc;
