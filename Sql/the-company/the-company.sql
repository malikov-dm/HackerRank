/*Query for generated tables from init-database.sql*/
/*
select distinct
        c.company_code
        , c.founder
        , count(distinct lm.lead_manager_code) q1
        , count(distinct sm.senior_manager_code) q2
        , count(distinct m.manager_code) q3
        , count(distinct e.employee_code) q4
    from TC_Company c
        left join TC_Lead_Manager lm on lm.company_code = c.company_code
        left join TC_Senior_Manager sm on sm.lead_manager_code = lm.lead_manager_code 
        left join TC_Manager m on m.senior_manager_code = sm.senior_manager_code
        left join TC_Employee e on e.manager_code = m.manager_code
    group by c.company_code, c.founder
    order by c.company_code
*/

select distinct
    c.company_code
    , c.founder
    , count(distinct lm.lead_manager_code) q1
    , count(distinct sm.senior_manager_code) q2
    , count(distinct m.manager_code) q3
    , count(distinct e.employee_code) q4
from Company c
    left join Lead_Manager lm on lm.company_code = c.company_code
    left join Senior_Manager sm on sm.lead_manager_code = lm.lead_manager_code 
    left join Manager m on m.senior_manager_code = sm.senior_manager_code
    left join Employee e on e.manager_code = m.manager_code
group by c.company_code, c.founder
order by c.company_code