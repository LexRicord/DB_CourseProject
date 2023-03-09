create PROCEDURE addService(in_name in SERVICES.Name%TYPE, in_price in SERVICES.Price%TYPE,
in_typename TYPEOFAPPLIANCES.TYPENAME%TYPE, in_time SERVICES.EstimCompTime%type)
IS
service_exists number;
curr_service_exists exception;
invaliddata exception;
in_type SERVICES.TypeAPPID%TYPE;
begin
    if in_name is null or in_price is null or in_typename is null or in_time is null
        then raise invaliddata;
    end if;
    SELECT COUNT(*) into service_exists from SERVICES where SERVICES.Name = in_name;
    if service_exists != 0 then raise curr_service_exists;
    end if;
    select TYPEOFAPPLIANCES.ID into in_type from TYPEOFAPPLIANCES
    where TYPEOFAPPLIANCES.TYPENAME=in_typename;
    insert into Services(Name, Price,ESTIMCOMPTIME,TYPEAPPID)
    values (in_name,in_price,in_time, in_type);
    exception
    when curr_service_exists then
    raise_application_error(-20002, 'Такой набор услуг уже существует');
    when invaliddata then
    raise_application_error(-20028, 'Проверьте введенные данные');
  commit;
end addService;