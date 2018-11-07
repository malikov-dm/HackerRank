select 
ceiling(avg(cast(Salary as decimal)) - avg(cast(replace(cast(Salary as nvarchar(5)), '0', '') as decimal)))
from Employees
