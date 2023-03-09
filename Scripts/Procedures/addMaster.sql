create or replace procedure addMaster(in_name in EMPLOYEES.Name%TYPE, in_surname in EMPLOYEES.Surname%TYPE,
in_secondname in EMPLOYEES.SecondName%TYPE, in_empllogin EMPLOYEES.LOGIN%type,
in_typename in TYPEOFAPPLIANCES.TYPENAME%TYPE)
is
    invaliddata exception;
    curr_master_exists exception;
    empl_id number;
    type_id number;
begin
    if in_name is null or in_surname is null or in_secondname is null
           or in_empllogin is null or in_typename is null
    then raise invaliddata;
    end if;
    select TYPEOFAPPLIANCES.ID into type_id from TYPEOFAPPLIANCES
        where TYPEOFAPPLIANCES.TYPENAME = in_typename;
    select EMPLOYEES.ID into empl_id from EMPLOYEES
        where EMPLOYEES.NAME = in_name and EMPLOYEES.SURNAME = in_surname
          and EMPLOYEES.SECONDNAME = in_secondname and EMPLOYEES.LOGIN = in_empllogin;
    insert into Masters(Masters.NUMBEROFCOMPLETEDORDERS,
             Masters.MASTERSINCOME, Masters.EMPLOYEESID,Masters.SPECTYPEID)
    values (0, 0, empl_id, type_id);
    exception
    when curr_master_exists then
    raise_application_error(-20001, 'Такой мастер уже существует');
    when invaliddata then
    raise_application_error(-20029, 'Проверьте введенные данные');
  commit;
end;