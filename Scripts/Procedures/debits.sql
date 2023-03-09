create or replace procedure debits(in_id in CLIENTS.Id%TYPE, in_amount in Debit.Amount%TYPE)
is
begin
    insert into Debit(DebitDate, Amount, CLIENTID) values (CURRENT_TIMESTAMP, in_amount, in_id);
    commit;
end;