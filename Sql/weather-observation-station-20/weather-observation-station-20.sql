/*
Enter your query here.
Please append a semicolon ";" at the end of the query and enter your query in a single line to avoid error.
*/
SELECT
   ROUND(cast(AVG(LAT_N) as decimal(20,4)), 4)
FROM
(
   SELECT
      LAT_N,
      ROW_NUMBER() OVER (ORDER BY LAT_N ASC) AS LatNAsc,
      ROW_NUMBER() OVER (ORDER BY LAT_N DESC) AS LatNDesc
   FROM Station
) x
WHERE
   LatNDesc IN (LatNAsc, LatNAsc - 1, LatNAsc + 1)