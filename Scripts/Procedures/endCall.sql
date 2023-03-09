create or replace procedure endCall(in_id in CLIENTS.Id%TYPE)
is
totalmins int;
diffmin decimal(5,2);
currbalance decimal(5,2);
mins int;
newb decimal(5,2);
minsch nvarchar2(50);
iscall exception;
callnum int;
remid int;
cd TIMESTAMP;
callinterval INTERVAL DAY TO SECOND;
begin
  select R.CLIENTID into remid from CLIENTS
  join REMAINDERS R on CLIENTS.ID = R.CLIENTID where CLIENTS.Id=in_id;
  select Remainders.RBalance into currbalance from CLIENTS
    join REMAINDERS on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
  select Remainders.RMINUTES into minsch from CLIENTS
     join REMAINDERS on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
  select count(*) into callnum from ClientCalls where ClientCalls.CLIENTID=in_id and ClientCalls.CallDuration is null;
  if callnum=0 then raise iscall;
  end if;
  select CallDate into cd from ClientCalls where CLIENTID=in_id and ClientCalls.CallDuration is null;
  callinterval:=CURRENT_TIMESTAMP-cd;
  totalmins:=EXTRACT(MINUTE FROM callinterval)+1;
  if minsch!='безлимит' then mins:=minsch;
  diffmin:=mins-totalmins;
  end if;
  if minsch!='безлимит' and diffmin>=0 then update Remainders set RMINUTES=cast(diffmin as nvarchar2(50)) where Remainders.CLIENTID=remid;
  elsif minsch!='безлимит' and diffmin<0 then update Remainders set RMINUTES='0', RBalance=currbalance-(0.1*(-diffmin)) where Remainders.CLIENTID=remid;
  end if;
  update ClientCalls set CallDuration=callinterval where ClientCalls.CLIENTID=in_id and CallDuration is null;
  commit;
  select Remainders.RBalance into newb from CLIENTS
      join Remainders on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
    if minsch!='безлимит' and currbalance>newb then debits(in_id,currbalance-newb);
    end if;
  exception
    when iscall then
    raise_application_error(-20024,'Вы ни с кем не связаны');
    commit;
end;