/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/
;with cte as (
    select top 1 
        min(LAT_N) over() a 
        , min(LONG_W) over() b
        , max(LAT_N) over() c
        , max(LONG_W) over() d

    from Station
)select round(cast(abs(a - c) + abs(b - d) as decimal(20,4)), 4) from cte