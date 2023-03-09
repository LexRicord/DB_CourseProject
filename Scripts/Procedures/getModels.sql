create or replace PROCEDURE getModels(in_type in TYPEOFAPPLIANCES.TYPENAME%TYPE,
servpacks out sys_refcursor)
IS
begin
open servpacks for select MODELS.MODEL from MODELS
join TYPEOFAPPLIANCES on MODELS.TYPEID = TYPEOFAPPLIANCES.ID
where TYPEOFAPPLIANCES.TYPENAME = in_type;
  dbms_output.enable();
  dbms_sql.return_result(servpacks);
end getModels;
