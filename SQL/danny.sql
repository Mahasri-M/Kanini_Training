use adoass;
create table menu (p_id varchar(1),p_name varchar(10),price smallint,
CONSTRAINT PK_PID PRIMARY KEY("p_id"));

insert into menu values('A','sushi',100);
insert into menu values('B','curry',300);
insert into menu values('C','ramen',500);

select * from menu;

create table sales (cus_id int, p_id varchar(1), purchase_date date,amt int,
CONSTRAINT FK_CUS_ID FOREIGN KEY("cus_id")
REFERENCES "dbo"."members" ("cus_id"),
CONSTRAINT FK_PID FOREIGN KEY("p_id")
REFERENCES "dbo"."menu"("p_id"),
);

insert into sales values(1,'A','2023/03/26',100);
insert into sales values(2,'B','2023/02/10',300);
insert into sales values(3,'C','2023/01/12',500);
insert into sales values(4,'B','2023/01/10',300);
insert into sales values(1,'A','2023/03/03',100);
insert into sales values(3,'C','2023/02/11',500);
insert into sales values(4,'A','2023/04/13',100);

select * from sales;

create table members(cus_id int primary key, c_name varchar(5),date_of_join date, points_earned tinyint);

insert into members values(1,'tom','2023/01/01',0);
insert into members values(2,'jerry','2023/01/05',0);
insert into members values(3,'ben','2023/01/10',0);
insert into members values(4,'sam','2023/03/26',0);

select * from members;
