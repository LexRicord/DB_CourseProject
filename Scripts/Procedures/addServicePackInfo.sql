create or replace PROCEDURE addServicePackInfo(in_service in SERVICES.Name%TYPE,
in_typename TYPEOFAPPLIANCES.TYPENAME%TYPE)
IS
service_exists number;
curr_service_exists exception;
invaliddata exception;
in_type SERVICES.TypeAPPID%TYPE;
pr SERVICES.Price%type;
spi_id ServicePackInfo.ID%TYPE;
no_spi exception;
begin
    if in_service is null or in_typename is null
        then raise invaliddata;
    end if;
    SELECT COUNT(*) into service_exists from SERVICES where SERVICES.Name = in_service;
    if service_exists != 0 then raise curr_service_exists;
    end if;
    select count(*) into spi_id from SERVICEPACKINFO
    join ORDERS O on SERVICEPACKINFO.ID = O.SERVICEPACKINFOID;
    if (spi_id > 0) then select max(SERVICEPACKINFO.ID) into spi_id from SERVICEPACKINFO
    join ORDERS O on SERVICEPACKINFO.ID = O.SERVICEPACKINFOID;
    else raise no_spi;
    end if;
    select TYPEOFAPPLIANCES.ID into in_type from TYPEOFAPPLIANCES
    where TYPEOFAPPLIANCES.TYPENAME=in_typename;
    select Services.Price into pr from SERVICES
    join TYPEOFAPPLIANCES on SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
    where Services.Name = in_service and TYPEAPPID=in_type;
    update SERVICEPACKINFO set SPPRICE = pr where SERVICEPACKINFO.ID= spi_id;
    exception
    when no_spi then
    raise_application_error(-20043, 'Такого ServicePackInfo не существует');
    when curr_service_exists then
    raise_application_error(-20002, 'Такой набор услуг уже существует');
    when invaliddata then
    raise_application_error(-20028, 'Проверьте введенные данные');
  commit;
end addServicePackInfo;