create or replace procedure sendSMS(in_id in CLIENTS.Id%TYPE)
is
smscount int;
currbalance decimal(5,2);
smscountch nvarchar2(50);
remid int;
notenaughsms exception;
notmoney exception;
newb decimal(5,2);
begin
    select R.CLIENTID into remid from CLIENTS
    join REMAINDERS R on CLIENTS.ID = R.CLIENTID
    where CLIENTS.Id=in_id;
    select Remainders.RSMS into smscountch from CLIENTS join Remainders
        on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
    select Remainders.RBalance into currbalance from CLIENTS join Remainders
        on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
    smscount:=1;
    if smscountch!='безлимит' then smscount:=smscountch;
      end if;
      if currbalance<0 then raise notmoney;
        elsif smscount!=0 and smscountch!='безлимит' then update REMAINDERS set RSMS=cast (smscount-1 as nvarchar2(50)) where Id=remid;
        elsif currbalance>0 and smscountch!='безлимит' then update REMAINDERS set RBalance=currbalance-0.5 where Id=remid;
      end if;
      commit;
       select REMAINDERS.RBalance into newb from CLIENTS join REMAINDERS
           on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
    if smscountch!='безлимит' and currbalance>newb then debits(in_id,currbalance-newb);
    end if;
    exception
    when notenaughsms then
    raise_application_error(-20015,'Не хватает свободных SMS или не хватает средств');
    when notmoney then
    raise_application_error(-20016,'Пополните счет и повторите операцию');
    commit;
end;