create or replace procedure getPrice(in_service in Services.Name%TYPE,in_type in TYPEOFAPPLIANCES.TYPENAME%TYPE,
servs out sys_refcursor)
is
begin
open servs for select Price from Services join TYPEOFAPPLIANCES T on Services.TYPEAPPID = T.ID
where Services.NAME = in_service and T.ID = in_type;
end;