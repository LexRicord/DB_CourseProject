create or replace procedure getMasters(curs out sys_refcursor)
is
begin
open curs for select LOGIN ,Surname, MASTERS.NUMBEROFCOMPLETEDORDERS, MASTERSINCOME, TYPENAME from Masters
join EMPLOYEES E on E.ID = MASTERS.EMPLOYEESID
join TYPEOFAPPLIANCES on MASTERS.SPECTYPEID = TYPEOFAPPLIANCES.ID
ORDER BY MASTERSINCOME;
end;