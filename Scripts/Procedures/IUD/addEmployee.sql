CREATE or replace PROCEDURE addEmployee(in_name in Employees.Name%TYPE, in_surname in Employees.Surname%TYPE,
in_secondname in Employees.SecondName%TYPE, in_email in Employees.Email%TYPE, in_ephonenumber EMPLOYEES.EPHONENUMBER%Type,
in_password in Employees.Password%TYPE, in_Role in Employees.Role%TYPE)
IS
user_exists number;
user_p_exists number;
curr_user_exists exception;
curr_phone_exists exception;
encode_pass raw(2000);
invaliddata exception;
begin
    if in_name is null or in_surname is null or in_secondname is null or in_email is null
           or in_password is null or in_Role is null or in_ephonenumber is null
    then raise invaliddata;
    end if;
    encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
    SELECT COUNT(*) into user_exists from Employees where Employees.Email = in_email;
    SELECT COUNT(*) into user_p_exists from Employees where Employees.EPHONENUMBER = in_ephonenumber;
    if (user_exists != 0 ) then raise curr_user_exists;
    elsif (user_p_exists != 0) then raise curr_phone_exists;
        else insert into Employees (Email, Name, Surname, SecondName, EPHONENUMBER, Password, Role)
        values (in_email, in_name, in_surname, in_secondname, in_ephonenumber ,encode_pass, in_Role);
    end if;
    exception
    when curr_user_exists then
    raise_application_error(-20001, 'Пользователь с таким логином или номером телефона существует');
    when curr_phone_exists then
    raise_application_error(-20041, 'Пользователь с таким номером телефона существует');
    when invaliddata then
    raise_application_error(-20029, 'Проверьте введенные данные');
  commit;
end addEmployee;