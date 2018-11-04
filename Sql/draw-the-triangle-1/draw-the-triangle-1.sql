;with cte
as(
	select
		1 as rn
		, cast(N'* ' as varchar(max)) as res
	union all
	select 
		rn + 1
		, cast(concat(res, N'* ') as varchar(max)) 
	from cte
	where (rn + 1) <= 20
)
select res from cte
order by rn desc