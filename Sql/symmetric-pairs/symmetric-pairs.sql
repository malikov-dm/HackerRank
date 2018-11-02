--HackerRank "Symmetric Pairs"
--How to detect unique pair of values a and b?
--Make two arithmetic operations: + and * and partitionin by results
;with cte
as
(
    select ROW_NUMBER() over(partition by (X + Y), (X * Y) order by x desc) as rn, X, Y
    from Functions
)
select distinct X, Y from cte
where X <= Y and rn > 1
order by X asc