CREATE OR REPLACE PROCEDURE AddBalanceTransaction (
    in_ClientId NUMBER,
    in_Sum NUMBER
) AS
BEGIN
    UPDATE Clients
    SET Balance = Balance + in_Sum
    WHERE Id = in_ClientId;

    INSERT INTO BalanceHistory (ClientId, SumOfTransaction, TypeOfTransaction)
    VALUES (in_ClientId, in_Sum, 'Пополнение баланса');

    COMMIT;
END AddBalanceTransaction;