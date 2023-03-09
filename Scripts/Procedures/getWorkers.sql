create procedure getWorkers(curs out sys_refcursor)
is
begin
open curs for select Surname, EMPLOYEES.NAME, SecondName, Post
              from Employees  where POST='Работник';
end;