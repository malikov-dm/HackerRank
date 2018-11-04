;with cte1
as
(
	select
		row_number() over(order by p1.[Start_Date]) as pid
		, p1.[Task_ID]
		, p1.[Start_Date]
		, p1.[End_Date]
	from Projects p1
	where not exists (select 1 from Projects p2 where p2.[End_Date] = p1.[Start_Date])
	union all
	select
		cte1.pid
		, p2.[Task_ID]
		, p2.[Start_Date]
		, p2.[End_Date]
	from Projects p2
		inner join cte1 on cte1.[End_Date] = p2.[Start_Date]
),
cte2
as
(
	select
		pid 
		, [Start_Date]
		, [End_Date]
		, count(pid) over (partition by pid order by pid) as cnt
	from
		cte1
),
cte3
as
(
	select distinct
		min([Start_Date]) over (partition by pid order by cnt) as [Start_Date]
		, max([End_Date]) over (partition by pid order by cnt) as [End_Date]
		, cnt
	from cte2
)
select
[Start_Date]
, [End_Date]
from cte3
order by cnt, [Start_Date]