create or replace PROCEDURE getServices(curs out sys_refcursor)
IS
begin
open curs for select Services.Name,SERVICES.PRICE,SERVICES.ESTIMCOMPTIME, TYPEOFAPPLIANCES.TYPENAME
from Services join TYPEOFAPPLIANCES on SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID;
end getServices;