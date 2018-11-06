--use HackerRank;
;with cte 
as
(
	select
		ROW_NUMBER() over(ORDER BY [Name])  trn
		, DENSE_RANK() over(ORDER BY [Occupation]) dr
		, ROW_NUMBER() over(partition by [Occupation] ORDER BY [Name]) rn
		, [Name]
		, [Occupation]
	from Occupations
)
select
	d.[Name] as N'Doctor'
	, p.[Name] as N'Professor'
	, s.[Name] as N'Singer'
	, a.[Name] as N'Actor'
from 
	cte t 
		left join cte d on t.trn = d.rn and d.Occupation = N'Doctor'
		left join cte p on t.trn = p.rn and p.Occupation = N'Professor'
		left join cte s on t.trn = s.rn and s.Occupation = N'Singer'
		left join cte a on t.trn = a.rn and a.Occupation = N'Actor'
where
	d.[Name] is not null
	or p.[Name] is not null
	or s.[Name] is not null
	or a.[Name] is not null
	