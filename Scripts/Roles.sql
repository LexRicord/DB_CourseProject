create role employee_role;
grant create session to employee_role;
grant execute on addClient to employee_role;
grant execute on addRemainder to employee_role;
grant execute on addOrders to employee_role;
grant execute on getTypesOfAppliances to employee_role;
grant execute on getServicePacks to employee_role;
grant execute on getServices to employee_role;
grant execute on getPrice to employee_role;
grant execute on getModels to employee_role;
grant execute on ORDERS_PKG to employee_role;
grant execute on addTypeOfAppliance to employee_role;
grant execute on getTypesOfAppliances to employee_role;
grant execute on getModels to employee_role;
grant execute on GETSERVICES2 to employee_role;
grant execute on sys.dbms_crypto to employee_role;

commit;

create role client_role;
grant create session to client_role;
grant execute on getClientData to client_role;
grant execute on getServices to client_role;
grant execute on balanceReplenishment to client_role;
grant execute on moneyTransfer to client_role;
grant execute on debits to client_role;
grant execute on sendSMS to client_role;
grant execute on startCall to client_role;
grant execute on endCall to client_role;
grant execute on changePassword to client_role;
grant execute on sys.dbms_crypto to employee_role;

commit;

create user employee identified by emppass account unlock;
grant employee_role to employee;
create user client identified by clipass account unlock;
grant client_role to client;


