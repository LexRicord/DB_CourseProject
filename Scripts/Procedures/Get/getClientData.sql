create or replace procedure getClientData(in_id in CLIENTS.Id%TYPE, curs out sys_refcursor)
is
begin
  open curs for select Clients.Id, Clients.PhoneNumber, Clients.Email, clients.Balance, clients.Role
  from Clients where CLIENTS.Id=in_id;
end;