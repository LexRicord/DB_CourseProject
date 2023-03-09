create or replace procedure findUser(in_login in Employees.Login%TYPE, in_password in Employees.Password%TYPE, user_cur out sys_refcursor)
is
invalid_user exception;
check_count number;
encode_pass raw(2000);
begin
encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
select count(*) into check_count from Employees where Login=in_login and Password=encode_pass;
  if check_count!=0 then user_cur := get_user_cursor(in_login, encode_pass);
  else raise invalid_user;
  end if;
  dbms_output.enable();
  dbms_sql.return_result(user_cur);
  exception
  when invalid_user then
  raise_application_error(-20000,'Проверьте введенные данные');
end findUser;