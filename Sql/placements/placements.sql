select s1.Name
from Friends f
    inner join Students s1 on f.ID = s1.ID
    inner join Students s2 on f.Friend_ID = s2.ID
    inner join Packages p1 on s1.ID = p1.ID
    inner join Packages p2 on s2.ID = p2.ID
WHERE p1.Salary < p2.Salary
ORDER by p2.Salary