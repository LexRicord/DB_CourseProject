create procedure getEmployeesByLogin(in_emplogin in EMPLOYEES.EMAIL%TYPE, curs out sys_refcursor)
is
begin
open curs for select EMPLOYEES.NAME, EMPLOYEES.SECONDNAME from Employees
where EMPLOYEES.EMAIL=in_emplogin and EMPLOYEES.ROLE='employee';
end;