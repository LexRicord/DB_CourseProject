create or replace procedure addClient(in_name in Clients.Name%TYPE, in_surname in Clients.Surname%TYPE,
in_secondname in Clients.SecondName%TYPE, in_email in Clients.Email%TYPE, in_password in Clients.PASSWORD%TYPE)
is
    encode_pass nvarchar2(2000);
begin
    if in_name is null or in_surname is null or in_secondname is null or in_email is null
           or in_password is null or in_Role is null or in_ephonenumber is null
    then raise invaliddata;
    end if;
    encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
    if (in_passportnumber is null) then begin
    insert into Clients(CLIENTS.Name, Surname, SecondName, Email, CLIENTS.PASSWORD, PHONENUMBER, BALANCE)
    values (in_name, in_surname, in_secondname, in_login , encode_pass, in_phonenumber, 0);
    end;
    else insert into Clients(Email, PHONENUMBER, CLIENTS.Name, Surname, SecondName, CLIENTS.PASSWORD, PHONENUMBER,
                             BALANCE, PASSPORTNUMBER, POSTINDEX, Minutes, SMS)
    values (in_name, in_surname, in_secondname, in_login , encode_pass, in_phonenumber,
            20, in_passportnumber, in_postindex, 50, 100);
    end if;
  commit;
end;