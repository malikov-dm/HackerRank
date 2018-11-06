;with cte
as
(
	select distinct
		c.company_code
		, c.founder
		, lm.lead_manager_code
		, sm.senior_manager_code
		, m.manager_code
		, e.employee_code
	from Company c
		left join Lead_Manager lm on lm.company_code = c.company_code
		left join Senior_Manager sm on sm.lead_manager_code = lm.lead_manager_code 
		left join Manager m on m.senior_manager_code = sm.senior_manager_code
		left join Employee e on e.manager_code = m.manager_code
	--order by 
	--c.company_code
	--, lm.lead_manager_code
	--, sm.senior_manager_code
	--, m.manager_code
	--, e.employee_code
)
, cte2
as
(
	select 
	company_code
	, count(distinct lead_manager_code) over(partition by lead_manager_code) lead_manager_code
	, count(distinct senior_manager_code) over(partition by lead_manager_code) senior_manager_code
	, count(distinct manager_code) over(partition by lead_manager_code) manager_code
	, count(distinct employee_code) over(partition by lead_manager_code) employee_code
	from cte
	group by company_code
)
select * from cte2




--;with counts
--as
--(
--	select distinct
--	company_code
--	, count(lead_manager_code) over(partition by lead_manager_code) lead_manager_code
--	, count(senior_manager_code) over(partition by lead_manager_code) senior_manager_code
--	, count(manager_code) over(partition by lead_manager_code) manager_code
--	, count(employee_code) over(partition by lead_manager_code) employee_code
--	from Employee e 
--)
--, summs
--as
--(
--	select distinct
--	company_code
--	, lead_manager_code
--	, sum(senior_manager_code) over(partition by lead_manager_code) senior_manager_code
--	, sum(manager_code) over(partition by senior_manager_code) manager_code
--	, sum(employee_code) over(partition by manager_code) employee_code
--	from counts
--)
--select * from summs
--select distinct
--company_code
--, lead_manager_code
--, senior_manager_code
--, manager_code
--, employee_code
--from Employee e 