create or replace TRIGGER trg_clients_balance_after_update
AFTER UPDATE ON Clients
FOR EACH ROW
DECLARE
    v_transaction_type NVARCHAR2(25);
BEGIN
    IF :new.Balance > :old.Balance THEN
        v_transaction_type := 'Пополнение баланса';
    ELSE
        v_transaction_type := 'Уменьшение баланса';
    END IF;

    INSERT INTO BalanceHistory (ClientId, SumOfTransaction, TypeOfTransaction)
    VALUES (:new.Id, ABS(:new.Balance - :old.Balance), v_transaction_type);
END trg_clients_balance_after_update;