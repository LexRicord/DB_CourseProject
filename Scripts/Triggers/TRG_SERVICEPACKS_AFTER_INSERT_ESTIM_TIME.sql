CREATE OR REPLACE TRIGGER TRG_SERVICEPACKS_AFTER_INSERT_ESTIM_TIME
AFTER INSERT ON SERVICEPACKS
FOR EACH ROW
DECLARE
    v_orders_id INT;
    v_servicepack_id INT;
    v_add_estim_time INT;
BEGIN
    SELECT MAX(Id) INTO v_orders_id FROM Orders;
    
    v_servicepack_id := :NEW.Id;
    
    SELECT s.EstimCompTime INTO v_add_estim_time
    FROM SERVICEPACKS sp
    JOIN Services s ON s.Id = sp.serviceid
    WHERE sp.Id = v_servicepack_id;

    UPDATE ORDERS
    SET ordercompldate = ordercompldate + (v_add_estim_time / 24)
    WHERE Id = v_orders_id;
END;
/
