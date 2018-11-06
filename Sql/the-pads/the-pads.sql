select
	concat(o.Name, N'(', left(o.Occupation, 1), N')') 
from OCCUPATIONS o
order by o.Name

select 
	concat(N'There are a total of ', count(o.Occupation), N' ', lower(o.Occupation), 's.')
from OCCUPATIONS o
group by o.Occupation
order by count(o.Occupation), o.Occupation