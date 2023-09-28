create or replace PROCEDURE addTypeOfAppliance(in_name in TYPEOFAPPLIANCES.Name%TYPE)
IS
type_exists number;
curr_service_exists exception;
invaliddata exception;
begin
    if in_name is null then raise invaliddata;
    end if;
    SELECT COUNT(*) into type_exists from TYPEOFAPPLIANCES
    where TYPEOFAPPLIANCES.Name = in_name;
    if type_exists != 0 then raise curr_service_exists;
    end if;
    insert into TYPEOFAPPLIANCES(Name)
    values (in_name);
    exception
    when curr_service_exists then
    raise_application_error(-20002, 'Такой тип приборое существует');
    when invaliddata then
    raise_application_error(-20028, 'Проверьте введенные данные');
  commit;
end addTypeOfAppliance;