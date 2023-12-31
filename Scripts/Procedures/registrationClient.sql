create or replace PROCEDURE registrationClient(
    in_email IN Clients.Email%TYPE,
    in_password IN Clients.Password%TYPE,
    in_name IN Clients.Name%TYPE DEFAULT '-',
    in_surname IN Clients.Surname%TYPE DEFAULT '-',
    in_secondname IN Clients.SecondName%TYPE DEFAULT '-',
    in_passportnumber IN Clients.PassportNumber%TYPE DEFAULT '-',
    in_phonenumber IN Clients.Phonenumber%TYPE DEFAULT NULL)
IS
    encode_password VARCHAR2(2000);
    data_contains NUMBER;
    data_exists EXCEPTION;
BEGIN
    encode_password := COURSE_CRYPT.ENCRYPTION_S(in_password);
    SELECT COUNT(*) INTO data_contains FROM CLIENTS WHERE Clients.email = in_email;

    IF data_contains > 0 THEN
        RAISE data_exists;
    END IF;

    IF (data_contains = 0 AND in_passportnumber IS NULL) THEN 
        INSERT INTO Clients (Email, Password, Name, Surname, SecondName, Phonenumber, Balance, Role)
        VALUES (in_email, encode_password, in_name, in_surname, in_secondname, in_phonenumber, 0, 'client');
    ELSE
        INSERT INTO Clients (Email, Password, Name, Surname, SecondName, Phonenumber,
                             Balance, PassportNumber, Role)
        VALUES (in_email, encode_password, in_name, in_surname, in_secondname, in_phonenumber,
                20, in_passportnumber, 'client');
    END IF;

EXCEPTION
    WHEN data_exists THEN
        RAISE_APPLICATION_ERROR(-20006, 'Email уже привязан к учетной записи');
END registrationClient;