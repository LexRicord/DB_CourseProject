create or replace procedure addRemainder(in_client in CLIENTS.ID%TYPE)
is
mins nvarchar2(50);
extr2 nvarchar2(50);
balance decimal(5,2);
begin
    select CLIENTS.Minutes into mins from CLIENTS where CLIENTS.id=in_client;
    select CLIENTS.SMS into extr2 from CLIENTS where CLIENTS.id=in_client;
    select CLIENTS.BALANCE into balance from CLIENTS where CLIENTS.id=in_client;
    insert into Remainders(RBalance, RMinutes, RSMS,CLIENTID) values (balance, mins, extr2, in_client);
    commit;
end;