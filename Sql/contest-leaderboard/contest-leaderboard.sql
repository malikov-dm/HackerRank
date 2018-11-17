SELECT DISTINCT
    hacker_id
    , name
    , sum(d.m) OVER (PARTITION BY hacker_id order by hacker_id) s 
FROM
    (
        SELECT
            s.submission_id
            , s.hacker_id
            , h.name
            , s.challenge_id
            , MAX(s.score) OVER (PARTITION BY s.hacker_id, s.challenge_id order by s.hacker_id, s.challenge_id) as m
            , ROW_NUMBER() OVER (PARTITION BY s.hacker_id, s.challenge_id order by s.hacker_id, s.challenge_id) as rn
        FROM
            Hackers h 
                INNER JOIN Submissions s on h.hacker_id = s.hacker_id
        WHERE s.score > 0
    ) AS d
WHERE d.rn = 1
ORDER BY s desc