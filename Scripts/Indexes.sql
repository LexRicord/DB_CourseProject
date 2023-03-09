----------------------------------------------------------------------
create index SERVICEPACKIND on SERVICEPACK(Name);
drop index SERVICEPACKIND;
create or replace procedure testRows
is
i number(8):=0;
begin
    while i< 100000
    loop
        insert into Debit(DebitDate,Amount, OrderId) values (CURRENT_TIMESTAMP, 1, 21);
        i:= i+1;
    end loop;
    commit;
    exception when others then raise_application_error(-20024,'Вы ни с кем не связаны');
end testRows;
begin
testRows;
end;
EXPLAIN PLAN FOR
SELECT * FROM Debit where OrderId>1;
SELECT * FROM TABLE (dbms_xplan.display);

delete from Debit where id>1000

drop index pr_ind;
drop table Table_1;

create table Table_1 (pr int);
create index pr_ind on Table_1(pr);

SELECT * FROM DEBIT ORDER BY id
begin
for i in 0..1000000
loop
insert into Table_1 values (i);
end loop;
end;