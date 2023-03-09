create procedure getEmployeesBySurname(in_empsurname in EMPLOYEES.SURNAME%TYPE,curs out sys_refcursor)
is
begin
open curs for select EMPLOYEES.LOGIN from Employees
where EMPLOYEES.SURNAME=in_empsurname and EMPLOYEES.POST='Работник';
end;