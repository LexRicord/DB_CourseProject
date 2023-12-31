create or replace PROCEDURE addClient(
    in_email IN Clients.Email%TYPE,
    in_password IN Clients.Password%TYPE,
    in_name IN Clients.Name%TYPE DEFAULT '-',
    in_surname IN Clients.Surname%TYPE DEFAULT '-',
    in_secondname IN Clients.SecondName%TYPE DEFAULT '-',
    in_passportnumber IN Clients.PassportNumber%TYPE DEFAULT NULL,
    in_postindex IN Clients.PostIndex%TYPE DEFAULT 0,
    in_phonenumber IN Clients.Phonenumber%TYPE DEFAULT NULL)
IS
    encode_pass NVARCHAR2(2000);
BEGIN
    encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);

    IF (in_passportnumber IS NULL) THEN
        INSERT INTO Clients (Email, Password, Name, Surname, SecondName, Phonenumber, Balance, Role)
        VALUES (in_email, encode_pass, in_name, in_surname, in_secondname, in_phonenumber, 0, 'client');
    ELSE
        INSERT INTO Clients (Email, Password, Name, Surname, SecondName, Phonenumber,
                             Balance, PassportNumber, PostIndex, Role)
        VALUES (in_email, encode_pass, in_name, in_surname, in_secondname, in_phonenumber,
                20, in_passportnumber, in_postindex, 'client');
    END IF;

    COMMIT;
END;