CREATE OR REPLACE PROCEDURE balanceReplenishment(in_id IN CLIENTS.Id%TYPE, in_summ NUMBER)
IS
    curr_balance NUMBER(7,2);
    balanceOutOfRange EXCEPTION;
    remid INT;
BEGIN
    BEGIN
        SELECT Clients.Balance INTO curr_balance FROM CLIENTS 
        WHERE CLIENTS.ID = in_id;

        IF curr_balance + in_summ > 9999 THEN
            RAISE balanceOutOfRange;
        END IF;

        UPDATE CLIENTS
        SET Balance = curr_balance + in_summ
        WHERE ID = in_id;

    EXCEPTION
        WHEN NO_DATA_FOUND THEN
            RAISE_APPLICATION_ERROR(-20011, 'Клиент с ID ' || in_id || ' не найден.');
        WHEN balanceOutOfRange THEN
            RAISE_APPLICATION_ERROR(-20010, 'Баланс не может быть больше 9999 руб.');
    END;
END balanceReplenishment;
