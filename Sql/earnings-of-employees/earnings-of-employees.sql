declare @res int;

select @res  = max(e.[months] * e.[salary]) from [Employee] e

select
	concat(
		@res
		, N' '
		, count(distinct case when e.[months] * e.[salary] = @res then employee_id end)
	)
from [Employee] e