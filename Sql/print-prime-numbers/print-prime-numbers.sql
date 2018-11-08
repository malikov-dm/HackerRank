declare @startnum int = 3;
declare @endnum int = 1000;

declare @res varchar(8000) = N'2';
WITH 
     t4 AS (
        SELECT 
            n 
        FROM (VALUES(0),(0),(0),(0)) t(n)
    )
    ,t256 AS (
        SELECT 
            0 AS n 
        FROM t4 AS a 
            CROSS JOIN t4 AS b 
            CROSS JOIN t4 AS c 
            CROSS JOIN t4 AS d
    )
    ,t16M AS (
        SELECT 
            ROW_NUMBER() OVER (ORDER BY (a.n)) AS num 
        FROM t256 AS a 
            CROSS JOIN t256 AS b 
            CROSS JOIN t256 AS c)
    , res as (
        SELECT num
        FROM t16M AS Dividend
        WHERE
            Dividend.num <= @endnum
            AND Dividend.num >= @startnum
            AND NOT EXISTS(
                SELECT 1
                FROM t16M AS Divisor
                WHERE
                    Divisor.num <= @endnum
                    AND Divisor.num BETWEEN 2 AND SQRT(Dividend.num)
                    AND Dividend.num % Divisor.num = 0
            )
    )

    select @res = concat(@res, '&', num) from res
    select @res;