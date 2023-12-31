create or replace procedure getServ(curs out sys_refcursor)
is
begin
open curs for select Services.Name, Price from Services;
end;