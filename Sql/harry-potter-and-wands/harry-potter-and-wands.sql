SELECT id, age, coins_needed, power
FROM 
(
    SELECT 
        w.id
        , wp.age
        , W.coins_needed
        , W.power
        , ROW_NUMBER() OVER (PARTITION BY w.code, w.power ORDER BY w.coins_needed, w.power DESC) AS rn
    FROM 
        Wands w 
            INNER JOIN Wands_Property wp ON w.code = wp.code
    WHERE 
        wp.is_evil = 0
)
AS wd
WHERE rn = 1
ORDER BY power DESC, age DESC