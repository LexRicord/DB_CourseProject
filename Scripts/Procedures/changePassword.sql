create or replace procedure changePassword (in_cliendid in CLIENTS.ID%TYPE, in_oldpass in CLIENTS.PASSWORD%TYPE,
in_newpass in CLIENTS.PASSWORD%TYPE)
as
    wrong_pass exception;
    invaliddata exception;
    n number;
    encode_password raw(2000);
    new_password raw(2000);
begin
    encode_password := COURSE_CRYPT.ENCRYPTION_S(in_oldpass);
    new_password := COURSE_CRYPT.ENCRYPTION_S(in_newpass);
    if in_cliendid is null or in_oldpass is null or in_newpass is null
    then raise invaliddata;
    end if;
    select CLIENTS.PASSWORD into n from CLIENTS where CLIENTS.ID = in_cliendid and CLIENTS.PASSWORD=encode_password;
    if n = 0 then raise wrong_pass;
    end if;
    update CLIENTS set CLIENTS.PASSWORD=new_password where CLIENTS.ID=in_cliendid and CLIENTS.PASSWORD=encode_password;
exception
when invaliddata then
    raise_application_error(-20028, 'Проверьте введенные данные');
when wrong_pass then
    raise_application_error(-20043, 'Пароль неверный!');
  commit;
end;