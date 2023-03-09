create or replace procedure getClientData(in_id in CLIENTS.Id%TYPE, curs out sys_refcursor)
is
begin
  open curs for select Clients.PHONENUMBER,Remainders.RBalance, Remainders.RMinutes, Remainders.RSMS
  from Clients join Remainders on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
end;