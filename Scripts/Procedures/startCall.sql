create or replace procedure startCall(in_id in Orders.Id%TYPE, in_phone in ClientCalls.InterlocutorNumber%TYPE)
is
myph int;
myphex exception;
countofClientCalls int;
currbalance decimal(5,2);
mins int;
minsch nvarchar2(50);
notmoney exception;
ce exception;
numnotf exception;
begin
      if in_phone not like '+375%' then raise numnotf;
      end if;
      select COUNT(*) into myph from CLIENTS where CLIENTS.PHONENUMBER=in_phone and CLIENTS.ID=in_id;
      if myph!=0 then raise myphex;
      end if;
      select Remainders.RBalance into currbalance from CLIENTS join Remainders
          on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
      select Remainders.RMinutes into minsch from CLIENTS join Remainders
          on CLIENTS.ID = REMAINDERS.CLIENTID where CLIENTS.Id=in_id;
      select COUNT(*) into countofClientCalls from ClientCalls
                                              where InterlocutorNumber=in_phone and CallDuration is null;
      if countofClientCalls!=0 then raise ce;
      end if;
      countofClientCalls:=0;
      select COUNT(*) into countofClientCalls from ClientCalls where CLIENTID=in_id and CallDuration is null;
      if countofClientCalls!=0 then raise ce;
      end if;
      if minsch!='безлимит' then mins:=minsch;
      end if;
      if currbalance<0 then raise notmoney;
      else insert into ClientCalls(InterlocutorNumber, CallDate, CLIENTID) values (in_phone,CURRENT_TIMESTAMP, in_id);
      end if;
    exception
    when notmoney then
    raise_application_error(-20021,'Пополните счет и повторите операцию');
     when ce then
    raise_application_error(-20022,'Невозможно набрать указанный номер или вы уже с кем-то соединены');
    when myphex then
    raise_application_error(-20023,'Невозможно набрать свой номер');
    when numnotf then
    raise_application_error(-20024,'Проверьте введенный номер');
    commit;
end;