create or replace PROCEDURE getTypesOfAppliancesNames(types out sys_refcursor)
IS
begin
open types for select TYPEOFAPPLIANCES.NAME from TYPEOFAPPLIANCES;
  dbms_output.enable();
  dbms_sql.return_result(types);
end getTypesOfAppliancesNames;

