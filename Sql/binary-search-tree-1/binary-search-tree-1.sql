;with cte
as(
	select 
		N
		, P
		, 0 as lvl
	from BST
	where P is null
	union all
	select
		b.N
		, b.P
		, lvl + 1
	from bst b
		inner join cte c on b.P = c.N
)
, cte2
as
(
	select N, P, DENSE_RANK() over (ORDER BY lvl DESC) dr
	from cte
)
select
	N
	, case
		when dr = 1 then 'Leaf'
		when P is null then 'Root'
		else 'Inner' end
		as 'Type'
from cte2
order by N 