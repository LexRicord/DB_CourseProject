create or replace procedure  ReadyOrder(in_orderid ORDERS.ID%TYPE)
is
    price number;
    emp_id number;
    type_id number;
    invaliddata exception;
begin
    if in_orderid is null then raise invaliddata;
    end if;
    select ORDERS.ORDERPRICE into price from ORDERS where ORDERS.ID=in_orderid;
    select ORDERS.EMPLOYEEID into emp_id from ORDERS where ORDERS.ID=in_orderid;
    select MODELS.TYPEID into type_id from ORDERS
    join MODELS on ORDERS.MODELID = MODELS.ID where ORDERS.ID=in_orderid;

    update Orders set ORDERCOMPLDATE=CURRENT_TIMESTAMP where ORDERS.ID=in_orderid;
	update Orders set ORDERSTATE=1 where ORDERS.ID=in_orderid;
	update MASTERS set MASTERS.MASTERSINCOME = (MASTERS.MASTERSINCOME+price) where MASTERS.EMPLOYEESID = emp_id;
    update MASTERS set MASTERS.NUMBEROFCOMPLETEDORDERS = (MASTERS.NUMBEROFCOMPLETEDORDERS+1)
    where MASTERS.EMPLOYEESID = emp_id and MASTERS.SPECTYPEID = type_id;
exception
    when invaliddata then
    raise_application_error(-20029, 'Проверьте введенные данные');
end ReadyOrder;