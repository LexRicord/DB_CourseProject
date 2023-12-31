create or replace procedure findClient(
  in_login in CLIENTS.email%TYPE,
  in_password in CLIENTS.Password%TYPE,
  user_cur out sys_refcursor
) is
  invalid_user exception;
  check_login number;
  check_phone number;
  phn CLIENTS.Phonenumber%type;
  encode_pass nvarchar2(2000);
begin
  encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
  phn := in_login;

  select count(*) into check_login
  from Clients
  where CLIENTS.email = in_login and Clients.Password = encode_pass;

  select count(*) into check_phone
  from Clients
  where CLIENTS.PHONENUMBER = in_login and Clients.Password = encode_pass;

  if check_login > 0 then
    user_cur := get_client_cursor(in_login, in_password);
  elsif check_phone > 0 then
    user_cur := get_client_cursor2(in_login, in_password);
  else
    raise invalid_user;
  end if;

  dbms_output.enable();
  dbms_sql.return_result(user_cur);

exception
  when invalid_user then
    raise_application_error(-20007, 'Проверьте введенные данные');
end findClient;