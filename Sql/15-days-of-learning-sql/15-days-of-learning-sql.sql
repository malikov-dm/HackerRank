declare @bd date = '2016-03-01';
;with cte(submission_date, hacker_id)
as
(
	select
		distinct submission_date
		, hacker_id
	from Submissions where submission_date=@bd
	union all
	select 
		s.submission_date
		, s.hacker_id
	from Submissions s 
		inner join cte c on c.submission_date = dateadd(d, -1, s.submission_date) and c.hacker_id = s.hacker_id
),
cte1
as
(
	select 
		distinct submission_date, hacker_id
	from cte 
),
cte2(submission_date, hacker_count)
as
(
	select 
		distinct submission_date
		, count(submission_date)
	from cte1
	group by submission_date
)
, 
cte3(submission_date, hacker_id, submission_count)
as
(
	select 
		distinct submission_date
		, hacker_id
		, count(hacker_id)
	from Submissions
	group by submission_date, hacker_id
)
, cte4
as
(
	select 
		ROW_NUMBER() OVER(partition by cte3.submission_date order by cte3.submission_count desc, cte3.hacker_id asc) as rn
		, cte3.submission_date
		, cte3.hacker_id
		, h.name as hacker_name
		, cte3.submission_count
		, cte2.hacker_count
	from cte3 
		inner join cte2 on cte3.submission_date = cte2.submission_date
		inner join Hackers h on h.hacker_id = cte3.hacker_id
)
select 
	submission_date
	, hacker_count
	, hacker_id
	, hacker_name
from cte4
where rn = 1
order by submission_date;