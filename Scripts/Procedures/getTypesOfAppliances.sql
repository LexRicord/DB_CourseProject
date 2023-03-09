create or replace PROCEDURE getTypesOfAppliances(types out sys_refcursor)
IS
begin
open types for select TYPEOFAPPLIANCES.TYPENAME, sum(MASTERSINCOME) as MI,sum(NUMBEROFCOMPLETEDORDERS) as NUM,count(MASTERS.id) as COUNT from TYPEOFAPPLIANCES
join MASTERS on TYPEOFAPPLIANCES.ID = MASTERS.SPECTYPEID
group by TYPENAME;
  dbms_output.enable();
  dbms_sql.return_result(types);
end getTypesOfAppliances;