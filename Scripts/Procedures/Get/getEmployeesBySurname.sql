create or replace procedure getEmployeesBySurname(in_empsurname in EMPLOYEES.SURNAME%TYPE, curs out sys_refcursor)
is
begin
open curs for select EMPLOYEES.EMAIL from Employees
where EMPLOYEES.SURNAME=in_empsurname and EMPLOYEES.ROLE='employee';
end;