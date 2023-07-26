CREATE TABLE regions (rid int primary key, rname varchar(15));

INSERT INTO regions VALUES (1, 'India');

INSERT INTO regions VALUES (2, 'Nepal');

INSERT INTO regions VALUES (3, 'China');

INSERT INTO regions VALUES (4, 'Bhutan');

INSERT INTO regions VALUES (5, 'Russia');

SELECT * FROM regions;

CREATE TABLE customer_nodes (cid int primary key, rid int, node_id int, starting_date date , ending_date date
CONSTRAINT FK_cust_id foreign key (rid) references regions(rid));

INSERT INTO customer_nodes VALUES (101, 1, 5,'2023/01/23', '2023/02/20');

INSERT INTO customer_nodes VALUES (102, 2, 3,'2023/02/01', '2023/02/28');

INSERT INTO customer_nodes VALUES (103, 3, 2,'2023/03/01', '2023/03/20');

INSERT INTO customer_nodes VALUES (104, 4, 4,'2023/01/03', '2023/02/05');

INSERT INTO customer_nodes VALUES (105, 5, 1,'2023/01/12', '2023/02/09');

INSERT INTO customer_nodes VALUES (106, 1, 3,'2023/02/13', '2023/02/28');

INSERT INTO customer_nodes VALUES (107, 2, 5,'2023/03/12', '2023/03/19');

SELECT * FROM customer_nodes;

CREATE TABLE customer_transaction (cid int, tdate date, ttype varchar(20),tamount int,
CONSTRAINT FK_CUST_TRANS FOREIGN KEY (cid) REFERENCES customer_nodes(cid));

INSERT INTO customer_transaction VALUES (101, '2023/02/01','withdraw', 8000);

INSERT INTO customer_transaction VALUES (102, '2023/02/10','deposit', 5500);

INSERT INTO customer_transaction VALUES (103, '2023/03/13','withdraw', 4800);

INSERT INTO customer_transaction VALUES (104, '2023/02/01','withdraw', 6700);

INSERT INTO customer_transaction VALUES (105, '2023/01/29','deposit', 5550);

SELECT * FROM customer_transaction;

--1

select count(distinct node_id) unique_nodes from customer_nodes;

--2
select n.rid,r.rname,
	count(distinct n.node_id) unique_nodes,
	count(n.node_id) number_of_nodes
from customer_nodes n 
left join regions r on n.rid = r.rid
group by n.rid, r.rname
order by n.rid;

--3
select r.rname,
count(distinct n.cid) total_customers
from customer_nodes n 
left join regions r on n.rid = r.rid
group by n.rid, r.rname
order by n.rid;

--4

select AVG(DATEDIFF(D, starting_date, ending_date)) average
from customer_nodes
where ending_date != '2023/01/28';

--5

WITH customer_transaction AS (
  SELECT cid,rid,node_id,
    MIN(starting_date) AS first_date
  FROM customer_nodes
  GROUP BY cid, rid, node_id),
reallocation AS (
  SELECT
    cid,
    rid,
    node_id,
    starting_date,
    DATEDIFF(DAY, starting_date, 
             LEAD(starting_date) OVER(PARTITION BY cid 
                                   ORDER BY starting_date)) AS moving_days
  FROM customer_nodes)
SELECT 
  DISTINCT r.rid,
  rg.rname,
  PERCENTILE_CONT(0.5) WITHIN GROUP (ORDER BY r.ending_date) OVER(PARTITION BY r.rid) AS median,
  PERCENTILE_CONT(0.8) WITHIN GROUP (ORDER BY r.ending_date) OVER(PARTITION BY r.rid) AS percentile_80,
  PERCENTILE_CONT(0.95) WITHIN GROUP (ORDER BY r.ending_date) OVER(PARTITION BY r.rid) AS percentile_95
FROM customer_nodes r
JOIN regions rg ON r.rid = rg.rid
WHERE ending_date IS NOT NULL;

--6

select ttype,
count(ttype) unique_count,
sum(tamount) total_amount
from customer_transaction
group by ttype
order by ttype;

--7

WITH cte_deposit AS (
SELECT cid,
	COUNT(ttype) AS deposit_count,
	SUM(tamount) AS deposit_amount
	FROM customer_transaction
	WHERE ttype = 'deposit'
	GROUP BY cid)
SELECT 
	AVG(deposit_count) AS historical_avg_deposit_count,
	AVG(deposit_amount) AS historical_avg_deposit_amount
FROM cte_deposit;

--8

select n.cid,
	DATEPART(M, t.tdate) month_id,
	DATENAME(M, t.tdate) month_name,
	count(t.ttype) total
from customer_transaction t
left join customer_nodes n on t.cid = n.cid
left join regions r on n.rid = r.rid
group by n.cid, DATEPART(M, t.tdate), DATENAME(M, t.tdate);

--9
select m.cid,m.tamount
	SUM(tamount) OVER(PARTITION BY m.cid ORDER BY m.node_id 
						ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) closing_balance
from customer_transaction m
left join balance b on b.cid = m.cid and b.node_id = m.node_id
where m.node_id between min_month and max_month
ORDER BY m.cid, m.node_id;

--10
select ROUND(100 * CAST(COUNT(cid) as float) / 
			(select count(*) from customer_transaction), 2) percentage_of_customers
from customer_nodes
where node_id < 5;

