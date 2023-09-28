create or replace PROCEDURE addOrders(in_login in CLIENTS.LOGIN%TYPE,
in_services in Services.Name%TYPE, in_emplid in Orders.EmployeeId%TYPE,
in_modelname in Models.Model%TYPE, in_spackinfo in SERVICEPACKINFO.ID%type)
IS
tariff_id number;
create or replace PROCEDURE addOrders(in_login in CLIENTS.LOGIN%TYPE,
in_services in Services.Name%TYPE, in_emplid in Orders.EmployeeId%TYPE,
in_modelname in Models.Model%TYPE, in_spackinfo in SERVICEPACKINFO.ID%type)
IS
tariff_id number;
n number;
spackinfo_id number;
client_id number;
master_exists number;
not_type number;
type_id number;
mod_id number;
order_Price number;
order_Price2 number;
number_valid exception;
invaliddata exception;
employee_not_master exception;
is_not_master_type exception;
begin
    if in_login is null or in_services is null or in_emplid is null
    or in_modelname is null or in_spackinfo is null then raise invaliddata;
    end if;

    select count(*) into master_exists from EMPLOYEES
        join MASTERS on EMPLOYEES.ID = MASTERS.EMPLOYEESID
    where MASTERS.EMPLOYEESID = in_emplid;
    if master_exists = 0 then raise employee_not_master;
    end if;

    select count(*) into not_type from EMPLOYEES
        join MASTERS on EMPLOYEES.ID = MASTERS.EMPLOYEESID
        join MODELS on MASTERS.SPECTYPEID = MODELS.TYPEID
    where MODELS.MODEL = in_modelName and EMPLOYEES.ID = in_emplid;
    if not_type = 0 then raise is_not_master_type;
    end if;

    select SERVICES.Id into tariff_id from SERVICES inner join TYPEOFAPPLIANCES T
        on T.ID = SERVICES.TYPEAPPID inner join MODELS M on T.ID = M.TYPEID
        where SERVICES.Name=in_services and M.MODEL =in_modelName;
    select CLIENTS.id into client_id from CLIENTS
    where CLIENTS.LOGIN = in_login;

    select SERVICES.Price into order_Price from SERVICES where SERVICES.ID=tariff_id;
    select SERVICEPACKINFO.SPPrice into order_Price2 from SERVICEPACKINFO
    join ORDERS on SERVICEPACKINFO.ID = ORDERS.SERVICEPACKINFOID;

    select Models.Id into mod_id from Models where Models.Model=in_modelName;
    select TYPEOFAPPLIANCES.ID into type_id from TYPEOFAPPLIANCES
        join MODELS on TYPEOFAPPLIANCES.ID = MODELS.TYPEID
    where MODELS.id = mod_id;
    select (MAX(ID)+1) into spackinfo_id from SERVICEPACKINFO;
    insert into SERVICEPACKINFO(id,TYPEAPPID,SPPRICE)
    values (spackinfo_id,type_id,0);
    insert into Orders(ORDERSTATE, ORDERREGDATE ,ORDERCOMPLDATE, ORDERPRICE,
                       SERVICEID,MODELID,EMPLOYEEID,ClientId, SERVICEPACKINFOID)
    values(0, CURRENT_TIMESTAMP, (CURRENT_TIMESTAMP+12), order_Price,
           tariff_id, mod_id, in_emplid,client_id, spackinfo_id);
    commit;
    exception
    when employee_not_master then
    raise_application_error(-20003, 'Текущий работник не является мастером');
    when is_not_master_type then
    raise_application_error(-20004, 'Мастер существует, но не работает с данным типом приборов');
    when invaliddata then
    raise_application_error(-20030, 'Проверьте введенные данные');
end addOrders;