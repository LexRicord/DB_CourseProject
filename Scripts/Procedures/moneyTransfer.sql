
create or replace procedure moneyTransfer(in_id in CLIENTS.Id%TYPE, in_summ decimal, in_phone in CLIENTS.PHONENUMBER%TYPE)
is
newb decimal(5,2);
num_check number;
num_exist number;
balanceSender decimal(5,2);
balanceReciever decimal(5,2);
nfound exception;
samenum exception;
balanceOutOfRange exception;
balanceNegative exception;
remidS int;
remidR int;
begin
    select Remainders.RBalance into balanceSender from CLIENTS join Remainders
        on Remainders.CLIENTID=CLIENTS.ID where CLIENTS.Id=in_id;
    select Remainders.RBalance into balanceReciever from CLIENTS join Remainders
        on Remainders.CLIENTID=CLIENTS.ID where CLIENTS.PHONENUMBER=in_phone;
    select COUNT(*) into num_exist from CLIENTS where CLIENTS.PHONENUMBER=in_phone and CLIENTS.Id=in_id;
    select CLIENTS.Id into remidS from CLIENTS where Id=in_id;
    select CLIENTS.Id into remidR from CLIENTS where PHONENUMBER=in_phone;
    if num_exist!=0 then raise samenum;
    end if;
    if num_check=0 then raise nfound;
    end if;
    if balanceReciever+in_summ>999 then raise balanceOutOfRange;
    end if;
    if balanceSender-in_summ<0 then raise balanceNegative;
    end if;
    balanceSender:=balanceSender-in_summ;
    balanceReciever:=balanceReciever+in_summ;
    update Remainders set Remainders.RBalance=balanceSender where Remainders.CLIENTId=remidS;
    update Remainders set Remainders.RBalance=balanceReciever where Remainders.CLIENTId=remidR;
    commit;
    select Remainders.RBalance into newb from CLIENTS join Remainders
        on Remainders.CLIENTID=CLIENTS.ID where CLIENTS.Id=in_id;
    debits(in_id,in_summ);
    exception
  when balanceNegative then
  raise_application_error(-20011,'Не хватает средств на перевод денег на счет');
  when balanceOutOfRange then
  raise_application_error(-20012,'Счёт не может быть больше 999 руб.');
  when samenum then
  raise_application_error(-20014,'Нельзя оплатить деньги за свой заказ');
  commit;
end moneyTransfer;