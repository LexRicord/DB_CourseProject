create or replace procedure getWorkers(curs out sys_refcursor)
is
begin
open curs for select Surname, EMPLOYEES.NAME, SecondName, Role
              from Employees  where Role='employee';
end;