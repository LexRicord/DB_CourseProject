CREATE OR REPLACE PROCEDURE addEmployeeToOrder(
    p_orderId IN ORDERS.id%TYPE,
    p_employeeId IN EMPLOYEES.id%TYPE
) AS
    masterCount NUMBER;
    invaliddata EXCEPTION;
    nomaster EXCEPTION;
BEGIN
    IF p_orderId IS NULL OR p_employeeId IS NULL THEN 
        RAISE invaliddata;
    END IF;
    
    SELECT COUNT(*) INTO masterCount
    FROM EMPLOYEES
    JOIN MASTERS ON EMPLOYEES.ID = MASTERS.EMPLOYEESID
    WHERE EMPLOYEES.ID = p_employeeId;
    
    IF masterCount != 1 THEN
        RAISE nomaster;
    END IF;
    
    UPDATE ORDERS SET EMPLOYEEID = p_employeeId WHERE ORDERS.ID = p_orderId;
    UPDATE ORDERS SET ORDERSTATEID = 1 WHERE ORDERS.ID = p_orderId;
    
EXCEPTION
    WHEN invaliddata THEN
        raise_application_error(-20029, 'Проверьте введенные данные');
    WHEN nomaster THEN
        raise_application_error(-20061, 'Нет такого мастера');
END addEmployeeToOrder;