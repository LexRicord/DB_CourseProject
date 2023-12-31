create PROCEDURE getServicesByName(in_service in SERVICES.Name%type,
in_type in TYPEOFAPPLIANCES.Typename%type, curs out sys_refcursor)
IS
begin
open curs for select Services.Name,SERVICES.PRICE,SERVICES.ESTIMCOMPTIME, TYPEOFAPPLIANCES.TYPENAME
from Services join TYPEOFAPPLIANCES on SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
where TYPEOFAPPLIANCES.TYPENAME = in_type and SERVICES.NAME=in_service;
end getServicesByName;