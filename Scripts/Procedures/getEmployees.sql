create or replace procedure getEmployees(curs out sys_refcursor)
is
begin
open curs for select LOGIN ,Surname, Employees.Name, SecondName, Post from Employees;
end;