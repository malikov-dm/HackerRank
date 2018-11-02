;with cte
as
(
    select ROW_NUMBER() over(partition by (X + Y), abs(X - Y) order by x desc) as rn, X, Y
    from Functions
)
select distinct X, Y from cte
where X <= Y and rn > 1
order by X asc