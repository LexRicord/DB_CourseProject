create or replace PROCEDURE getModels(in_type in TYPEOFAPPLIANCES.NAME%TYPE,
servpacks out sys_refcursor)
IS
begin
open servpacks for select MODELS.MODEL from MODELS
join TYPEOFAPPLIANCES on MODELS.TYPEID = TYPEOFAPPLIANCES.ID
where TYPEOFAPPLIANCES.NAME = in_type;
  dbms_output.enable();
  dbms_sql.return_result(servpacks);
end getModels;
