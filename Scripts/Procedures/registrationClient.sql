create or replace procedure registrationClient(in_number in CLIENTS.PHONENUMBER%TYPE,
in_password in Clients.Password%TYPE, in_login CLIENTS.Login%type)
IS
encode_password varchar2(2000);
log_exists number;
data_contains number;
data_exists exception;
login_exists exception;
begin
      encode_password := COURSE_CRYPT.ENCRYPTION_S(in_password);
      select Count(*) into data_contains from CLIENTS
        where Clients.PHONENUMBER = in_number;
      if data_contains>0 then raise data_exists;
      end if;
      select Count(*) into log_exists from CLIENTS
        where Clients.Login = in_login;
      if log_exists>0 then raise login_exists;
      end if;
      if (log_exists=0 and data_contains=0) then insert into Clients(CLIENTS.Name, Surname, LOGIN, CLIENTS.PASSWORD, PHONENUMBER, BALANCE)
        values ('User', 'User', in_login , encode_password, in_number, 0);
      end if;
exception
    when data_exists then
      raise_application_error(-20006, 'Номер телефона уже привязан к учетной записи');
    when login_exists then
      raise_application_error(-20042, 'Логин уже существует');
      commit;
end registrationClient;
commit;