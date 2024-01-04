CREATE OR REPLACE PROCEDURE getBalanceHistoryForClient(
    p_clientId IN NUMBER,
    p_cursor OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_cursor FOR
        SELECT BalanceHistory.transactionid, BalanceHistory.sumoftransaction,
        BalanceHistory.typeoftransaction, BalanceHistory.orderid
        FROM BalanceHistory
        WHERE ClientId = p_clientId;
END getBalanceHistoryForClient;
/
