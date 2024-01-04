CREATE OR REPLACE PROCEDURE ReadyOrder(in_orderid ORDERS.ID%TYPE)
IS
    price number;
    emp_id number;
    type_id number;
    client_balance number;
    client_id number;
    invaliddata exception;
    nomaster exception;
    notenoughmoney exception;
BEGIN
    IF in_orderid IS NULL THEN
        RAISE invaliddata;
    END IF;

    SELECT ORDERS.ORDERPRICE INTO price FROM ORDERS WHERE ORDERS.ID = in_orderid;
    SELECT ORDERS.EMPLOYEEID INTO emp_id FROM ORDERS WHERE ORDERS.ID = in_orderid;
    SELECT MODELS.TYPEID INTO type_id FROM ORDERS JOIN MODELS ON ORDERS.MODELID = MODELS.ID WHERE ORDERS.ID = in_orderid;
    
    IF emp_id is NULL then
        raise nomaster;
    end if;
    
    UPDATE Orders SET ORDERS.ORDERCOMPLDATE = CURRENT_TIMESTAMP WHERE ORDERS.ID = in_orderid;
    UPDATE Orders SET ORDERS.ORDERSTATEID = 2 WHERE ORDERS.ID = in_orderid;
    UPDATE MASTERS SET MASTERS.NUMBEROFCOMPLETEDORDERS = (MASTERS.NUMBEROFCOMPLETEDORDERS + 1)
    WHERE MASTERS.EMPLOYEESID = emp_id AND MASTERS.SPECTYPEID = type_id;

    SELECT clients.balance INTO client_balance
    FROM clients JOIN ORDERS ON ORDERS.CLIENTID = CLIENTS.ID
    WHERE orders.id = in_orderid;
    SELECT CLIENTS.ID INTO client_id 
    FROM clients JOIN ORDERS ON ORDERS.CLIENTID = CLIENTS.ID
    WHERE orders.id = in_orderid;

    IF (client_balance - price) < 0 THEN
        RAISE notenoughmoney;
    END IF;

    INSERT INTO BalanceHistory (ClientId, SumOfTransaction, TypeOfTransaction, OrderId)
    VALUES (client_id, ABS(client_balance - price), 'Оплата заказа', in_orderid);
    
    COMMIT;
EXCEPTION
    WHEN invaliddata THEN
        RAISE_APPLICATION_ERROR(-20029, 'Проверьте введенные данные');
    WHEN notenoughmoney THEN
        RAISE_APPLICATION_ERROR(-20062, 'На балансе у клиента недостаточно средств');
    WHEN nomaster THEN
        RAISE_APPLICATION_ERROR(-20063, 'У заказа нет мастера');
END ReadyOrder;