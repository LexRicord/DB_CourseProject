create or replace PACKAGE ORDERS_PKG AS
    CURSOR cur_ord
    is
        select Orders.id, Clients.PHONENUMBER,
               CLIENTS.LOGIN, Orders.OrderRegDate,
        MODELS.MODEL, Producers.Producer,  Services.NAME,
        ORDERS.OrderPrice, Orders.OrderState, ORDERS.ORDERCOMPLDATE, EMPLOYEES.ID as "EID"
        from ORDERS join SERVICES on Orders.SERVICEID=Services.ID
        join Models on Orders.MODELID = Models.ID
        join CLIENTS on ORDERS.CLIENTID = CLIENTS.ID
        join EMPLOYEES on ORDERS.EMPLOYEEID = EMPLOYEES.ID
        join PRODUCERS on MODELS.PRODUCERID = PRODUCERS.ID
        where Orders.EMPLOYEEID is not null and Orders.ORDERSTATE=0 and EMPLOYEES.POST='Работник';

        CURSOR cur_ord2
    is
        select Orders.id, Clients.PHONENUMBER,
               CLIENTS.LOGIN, Orders.OrderRegDate,
        MODELS.MODEL, Producers.Producer,  Services.NAME,
        ORDERS.OrderPrice, Orders.OrderState, ORDERS.ORDERCOMPLDATE, EMPLOYEES.ID as "EID"
        from ORDERS join SERVICES on Orders.SERVICEID=Services.ID
        join Models on Orders.MODELID = Models.ID
        join CLIENTS on ORDERS.CLIENTID = CLIENTS.ID
        join EMPLOYEES on ORDERS.EMPLOYEEID = EMPLOYEES.ID
        join PRODUCERS on MODELS.PRODUCERID = PRODUCERS.ID
        where Orders.EMPLOYEEID is not null and Orders.ORDERSTATE=1 and EMPLOYEES.POST='Работник';

    TYPE OrderType IS RECORD(or_id Orders.id%TYPE,
    or_num CLIENTS.PHONENUMBER%TYPE,
    cl_log CLIENTS.LOGIN%TYPE,
    or_date Orders.OrderRegDate%TYPE,
    or_model MODELS.MODEL%TYPE,
    m_prod PRODUCERS.Producer%TYPE,
    serv SERVICES.NAME%TYPE,
    or_price ORDERS.OrderPrice%TYPE,
    or_state Orders.OrderState%TYPE,
    or_enddate Orders.ORDERCOMPLDATE%TYPE,
    empl_id EMPLOYEES.ID%TYPE);
    TYPE TableOrderType IS TABLE OF OrderType;

    function GET_ACCEPTED_ORDERS
    return TableOrderType PIPELINED;
    function GET_READY_ORDERS
    return TableOrderType PIPELINED;

    no_masters exception;
    not_ready exception;
END ORDERS_PKG;

create or replace PACKAGE BODY ORDERS_PKG AS
function GET_ACCEPTED_ORDERS
return TableOrderType pipelined is
    out_rec OrderType;
    roww cur_ord%rowtype;
    c number;
Begin
        select count(*) into c from MASTERS where MASTERS.EMPLOYEESID > 0;
        if c < 1 then raise no_masters;
        end if;
        Open cur_ord;
        loop
            fetch cur_ord into roww;
            exit when cur_ord%notfound;
            PIPE ROW(roww);
        End loop;
        Close cur_ord;
exception
when no_masters then
        raise_application_error(-20031, 'No masters / Мастеров не добавлено.');
end GET_ACCEPTED_ORDERS;

function GET_READY_ORDERS
return TableOrderType pipelined is
    out_rec OrderType;
    roww cur_ord2%rowtype;
Begin
        Open cur_ord2;
        loop
            fetch cur_ord2 into roww;
            if roww.ORDERSTATE=0 then raise not_ready;
            end if;
            exit when cur_ord2%notfound;
            PIPE ROW(roww);
        End loop;
        Close cur_ord2;
exception
when not_ready then
        raise_application_error(-20032, 'Order not ready / Заказ не готов.');
end GET_READY_ORDERS;
END ORDERS_PKG;
commit;
declare
BEGIN
    select * from table(ORDERS_PKG.GET_accepted_Orders);
    select * from table(ORDERS_PKG.GET_READY_ORDERS);
end;