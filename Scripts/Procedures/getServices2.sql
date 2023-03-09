create or replace PROCEDURE getServices2(in_types in TYPEOFAPPLIANCES.TYPENAME%TYPE,
service out sys_refcursor)
IS
begin
open service for select Services.Name from Services
join TYPEOFAPPLIANCES on SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
where TYPEOFAPPLIANCES.TYPENAME = in_types;
  dbms_output.enable();
  dbms_sql.return_result(service);
end getServices2;