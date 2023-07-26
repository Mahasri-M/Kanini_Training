CREATE TABLE project (projid varchar(10) not null, 
proj_name varchar(25), starting_date date, end_date date);

INSERT INTO project (projid, proj_name, starting_date, end_date) values 
(100, 'iot','2023/01/23','2023/05/23');

INSERT INTO project (projid, proj_name, starting_date, end_date) values 
(101, 'aiml','2023/02/12','2023/06/12');

INSERT INTO project (projid, proj_name, starting_date, end_date) values 
(102, 'cloud','2023/01/20','2023/05/20');

INSERT INTO project (projid, proj_name, starting_date, end_date) values 
(103, 'web','2023/03/09','2023/07/09');

select * from project;