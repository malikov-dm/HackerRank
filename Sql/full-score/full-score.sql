select concat(h.hacker_id, N'  ', h.name)
FROM
    Hackers h
        INNER JOIN Submissions s on h.hacker_id = s.hacker_id
        INNER JOIN Challenges c on c.challenge_id = s.challenge_id
        INNER JOIN Difficulty d on c.difficulty_level = d.difficulty_level
where s.score = d.score 
group by h.hacker_id, h.name
having count(h.hacker_id) > 1
order by count(h.hacker_id) desc, h.hacker_id asc;
