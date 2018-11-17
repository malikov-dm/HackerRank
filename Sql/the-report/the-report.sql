/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/
SELECT
    CASE  
       WHEN g.Grade < 8 THEN NULL  
       ELSE [Name]  
    END
    , g.[Grade]
    , s.[Marks]
FROM
    Students s
        INNER JOIN Grades g on s.[Marks] >= g.[Min_Mark] and s.[Marks] <= g.[Max_Mark]
ORDER BY g.[Grade] DESC, s.[Name]