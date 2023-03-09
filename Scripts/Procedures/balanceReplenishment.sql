create or replace procedure balanceReplenishment(in_id in CLIENTS.Id%TYPE, in_summ decimal)
is
curr_balance decimal(5,2);
balanceOutOfRange exception;
remid int;
begin
    select Remainders.RBalance into curr_balance from CLIENTS join Remainders
        on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.ID=in_id;
    if curr_balance+in_summ>999 then raise balanceOutOfRange;
    end if;
    select Remainders.ClientId into remid from REMAINDERS where Remainders.ClientId=in_id;
    curr_balance:=in_summ+curr_balance;
    update Remainders set Remainders.RBalance=curr_balance where Remainders.ClientId=remid;
    exception
  when balanceOutOfRange then
  raise_application_error(-20010,'Залог не может быть больше 999 руб.');
  commit;
end balanceReplenishment;