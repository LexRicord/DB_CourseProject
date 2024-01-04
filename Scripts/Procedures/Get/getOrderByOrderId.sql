CREATE OR REPLACE PROCEDURE getOrderByOrderId(
    p_orderId IN ORDERS.id%TYPE,
    p_curs OUT SYS_REFCURSOR
) AS
BEGIN
    OPEN p_curs FOR
        SELECT DISTINCT Orders.id,
                        Clients.Email,
                        orders.orderprice,
                        ServicePacks.ServicePackOrder,
                        Orders.OrderRegDate,
                        ORDERS.ORDERCOMPLDATE,
                        OrderStates.StateDescription,
                        Orders.OrderDescription,
                        MODELS.MODEL,
                        EMPLOYEES.ID AS "EID"
        FROM ORDERS
        JOIN OrderStates ON OrderStates.Id = Orders.OrderStateId
        JOIN Models ON Orders.MODELID = Models.ID
        JOIN CLIENTS ON ORDERS.CLIENTID = CLIENTS.ID
        JOIN ServicePacks ON ServicePacks.ServicePackOrder = Orders.Id
        JOIN EMPLOYEES ON ORDERS.EMPLOYEEID = EMPLOYEES.ID
        WHERE Orders.id = p_orderId;
END getOrderByOrderId;
/
