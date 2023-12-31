CREATE OR REPLACE PACKAGE ORDERS_PKG AS
    CURSOR cur_ord IS
        SELECT Orders.id, Clients.Email,
               orders.orderprice, ServicePacks.ServicePackOrder,
               Orders.OrderRegDate, ORDERS.ORDERCOMPLDATE, OrderStates.StateDescription,
               Orders.OrderDescription, MODELS.MODEL
        FROM ORDERS JOIN OrderStates ON OrderStates.Id = Orders.OrderStateId
        JOIN Models ON Orders.MODELID = Models.ID
        JOIN CLIENTS ON ORDERS.CLIENTID = CLIENTS.ID
        JOIN ServicePacks ON ServicePacks.ServicePackOrder = Orders.Id
        WHERE Orders.EMPLOYEEID IS NULL AND Orders.ORDERSTATEID = 6;

    CURSOR cur_ord2 IS
        SELECT Orders.id, Clients.Email,
               orders.orderprice, ServicePacks.ServicePackOrder,
               Orders.OrderRegDate, ORDERS.ORDERCOMPLDATE, OrderStates.StateDescription,
               Orders.OrderDescription, MODELS.MODEL, EMPLOYEES.ID AS "EID"
        FROM ORDERS JOIN OrderStates ON OrderStates.Id = Orders.OrderStateId
        JOIN Models ON Orders.MODELID = Models.ID
        JOIN CLIENTS ON ORDERS.CLIENTID = CLIENTS.ID
        JOIN ServicePacks ON ServicePacks.ServicePackOrder = Orders.Id
        JOIN EMPLOYEES ON ORDERS.EMPLOYEEID = EMPLOYEES.ID
        WHERE Orders.EMPLOYEEID IS NOT NULL AND Orders.ORDERSTATEID = 1 AND EMPLOYEES.Role = 'employee';

    CURSOR cur_ord3 IS
        SELECT Orders.id, Clients.Email,
               orders.orderprice, ServicePacks.ServicePackOrder,
               Orders.OrderRegDate, ORDERS.ORDERCOMPLDATE, OrderStates.StateDescription,
               Orders.OrderDescription, MODELS.MODEL, EMPLOYEES.ID AS "EID"
        FROM ORDERS JOIN OrderStates ON OrderStates.Id = Orders.OrderStateId
        JOIN Models ON Orders.MODELID = Models.ID
        JOIN CLIENTS ON ORDERS.CLIENTID = CLIENTS.ID
        JOIN ServicePacks ON ServicePacks.ServicePackOrder = Orders.Id
        JOIN EMPLOYEES ON ORDERS.EMPLOYEEID = EMPLOYEES.ID
        WHERE Orders.EMPLOYEEID IS NOT NULL AND Orders.ORDERSTATEID = 2 AND EMPLOYEES.Role = 'employee';

    TYPE OrderType IS RECORD(
        or_id ORDERS.id%TYPE,
        cl_log CLIENTS.EMAIL%TYPE,
        or_price ORDERS.OrderPrice%TYPE,
        sp_order ServicePacks.ServicePackOrder%TYPE,
        or_regdate ORDERS.OrderRegDate%TYPE,
        or_enddate ORDERS.ORDERCOMPLDATE%TYPE,
        or_state OrderStates.StateDescription%TYPE,
        or_descr ORDERS.OrderDescription%TYPE,
        or_model MODELS.MODEL%TYPE,
        empl_id EMPLOYEES.ID%TYPE
    );
    TYPE OrderTypeNoEmp IS RECORD(
        or_id ORDERS.id%TYPE,
        cl_log CLIENTS.EMAIL%TYPE,
        or_price ORDERS.OrderPrice%TYPE,
        sp_order ServicePacks.ServicePackOrder%TYPE,
        or_regdate ORDERS.OrderRegDate%TYPE,
        or_enddate ORDERS.ORDERCOMPLDATE%TYPE,
        or_state OrderStates.StateDescription%TYPE,
        or_descr ORDERS.OrderDescription%TYPE,
        or_model MODELS.MODEL%TYPE
    );

    TYPE TableOrderType IS TABLE OF OrderType;
    TYPE TableOrderTypeNoEmp IS TABLE OF OrderTypeNoEmp;

    FUNCTION GET_NOT_ACCEPTED_ORDERS RETURN TableOrderTypeNoEmp PIPELINED;
    FUNCTION GET_ACCEPTED_ORDERS RETURN TableOrderType PIPELINED;
    FUNCTION GET_READY_ORDERS RETURN TableOrderType PIPELINED;

    no_masters EXCEPTION;
    not_ready EXCEPTION;
END ORDERS_PKG;

CREATE OR REPLACE PACKAGE BODY ORDERS_PKG AS
    FUNCTION GET_NOT_ACCEPTED_ORDERS RETURN TableOrderTypeNoEmp PIPELINED IS
        roww1 cur_ord%ROWTYPE;
    BEGIN
        OPEN cur_ord;
        LOOP
            FETCH cur_ord INTO roww1;
            EXIT WHEN cur_ord%NOTFOUND;
            PIPE ROW(roww1);
        END LOOP;
        CLOSE cur_ord;
    END GET_NOT_ACCEPTED_ORDERS;

    FUNCTION GET_ACCEPTED_ORDERS RETURN TableOrderType PIPELINED IS
        roww2 cur_ord2%ROWTYPE;
        c NUMBER;
    BEGIN
        SELECT COUNT(*) INTO c FROM MASTERS WHERE MASTERS.EMPLOYEESID > 0;

        IF c < 1 THEN
            RAISE no_masters;
        END IF;

        OPEN cur_ord2;
        LOOP
            FETCH cur_ord2 INTO roww2;
            EXIT WHEN cur_ord2%NOTFOUND;
            PIPE ROW(roww2);
        END LOOP;
        CLOSE cur_ord2;

    EXCEPTION
        WHEN no_masters THEN
            RAISE_APPLICATION_ERROR(-20031, 'No masters / Мастеров не добавлено.');
    END GET_ACCEPTED_ORDERS;

    FUNCTION GET_READY_ORDERS RETURN TableOrderType PIPELINED IS
        roww3 cur_ord3%ROWTYPE;
    BEGIN
        OPEN cur_ord3;
        LOOP
            FETCH cur_ord3 INTO roww3;
            IF roww3.StateDescription != 'Заказ готов' THEN
                RAISE not_ready;
            END IF;
            EXIT WHEN cur_ord3%NOTFOUND;
            PIPE ROW(roww3);
        END LOOP;
        CLOSE cur_ord3;

    EXCEPTION
        WHEN not_ready THEN
            RAISE_APPLICATION_ERROR(-20032, 'Order not ready / Заказ не готов.');
    END GET_READY_ORDERS;

END ORDERS_PKG;

    SELECT * FROM TABLE(ORDERS_PKG.GET_NOT_ACCEPTED_ORDERS);
    SELECT * FROM TABLE(ORDERS_PKG.GET_ACCEPTED_ORDERS);
    SELECT * FROM TABLE(ORDERS_PKG.GET_READY_ORDERS);


