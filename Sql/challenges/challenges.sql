;with cte1
as(
    select
        h.hacker_id hid
        , h.name hn
        , count(h.hacker_id) cnt
    from Hackers h
        inner join Challenges c on h.hacker_id = c.hacker_id
    group by h.hacker_id, h.name
)
, cte2
as
(
    select
        hid
        , hn
        , cnt
        , count(cnt) over(partition by cnt order by cnt desc) c
    from cte1
)
select
    hid
    , hn
    , cnt
from cte2
where cte2.c = 1
    or cte2.cnt = (select max(cnt) from cte2)
order by cnt desc, hid asc