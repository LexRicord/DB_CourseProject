create or replace procedure addClient(in_name in Clients.Name%TYPE, in_surname in Clients.Surname%TYPE,
in_secondname in Clients.SecondName%TYPE, in_login in Clients.Login%TYPE, in_password in Clients.PASSWORD%TYPE,
in_passportnumber in Clients.PassportNumber%TYPE, in_postindex CLIENTS.PostIndex%type,
in_phonenumber CLIENTS.Phonenumber%type)
is
    encode_pass nvarchar2(2000);
begin
    encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
    if (in_passportnumber is null) then begin
    insert into Clients(CLIENTS.Name, Surname, SecondName, LOGIN, CLIENTS.PASSWORD, PHONENUMBER, BALANCE)
    values (in_name, in_surname, in_secondname, in_login , encode_pass, in_phonenumber, 0);
    end;
    else insert into Clients(CLIENTS.Name, Surname, SecondName, LOGIN, CLIENTS.PASSWORD, PHONENUMBER,
                             BALANCE, PASSPORTNUMBER, POSTINDEX, Minutes, SMS)
    values (in_name, in_surname, in_secondname, in_login , encode_pass, in_phonenumber,
            20,in_passportnumber, in_postindex,50,100);
    end if;
  commit;
end;