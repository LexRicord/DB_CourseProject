create or replace PROCEDURE getServicesByTypeName(in_types in TYPEOFAPPLIANCES.NAME%TYPE,
service out sys_refcursor)
IS
begin
open service for select Services.Name from Services
join TYPEOFAPPLIANCES on SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
where TYPEOFAPPLIANCES.NAME = in_types;
  dbms_output.enable();
  dbms_sql.return_result(service);
end getServicesByTypeName;