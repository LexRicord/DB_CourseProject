create procedure getEmployeesByLogin(in_emplogin in EMPLOYEES.LOGIN%TYPE,curs out sys_refcursor)
is
begin
open curs for select EMPLOYEES.NAME,EMPLOYEES.SECONDNAME from Employees
where EMPLOYEES.LOGIN=in_emplogin and EMPLOYEES.POST='Работник';
end;