CREATE OR REPLACE TRIGGER TRG_SERVICEPACKS_AFTER_INSERT_ESTIM_TIME 
AFTER INSERT ON SERVICEPACKS 
FOR EACH ROW
DECLARE
    v_orders_id int;
    v_servicepack_id int;
    v_add_estim_time int;
BEGIN
    SELECT MAX(Orders.Id) into v_orders_id FROM Orders;
    SELECT MAX(SERVICEPACKS.Id) into v_servicepack_id FROM SERVICEPACKS;
    
    SELECT Services.EstimCompTime into v_add_estim_time from servicepacks
    join Services on Services.Id = servicepacks.serviceid
    where servicepacks.servicepackorder = v_orders_id and servicepacks.id = v_servicepack_id;
    
    UPDATE ORDERS SET ordercompldate = ordercompldate + TODATE(v_add_estim_time)
    where Orders.Id = v_orders_id;
END;