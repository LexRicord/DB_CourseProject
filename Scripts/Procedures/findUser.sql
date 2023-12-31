CREATE OR REPLACE PROCEDURE findUser(
    in_login IN Employees.email%TYPE,
    in_password IN Employees.Password%TYPE,
    user_cur OUT SYS_REFCURSOR
)
IS
   invalid_user EXCEPTION;
   check_count NUMBER;
   encode_pass NVARCHAR2(2000);
BEGIN
   DBMS_OUTPUT.PUT_LINE('Provided Login: ' || in_login);
   DBMS_OUTPUT.PUT_LINE('Provided Password: ' || in_password);

   encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);

   DBMS_OUTPUT.PUT_LINE('Encrypted Password: ' || encode_pass);

   SELECT COUNT(*)
   INTO check_count
   FROM Employees
   WHERE email = in_login AND Password = encode_pass;

   DBMS_OUTPUT.PUT_LINE('Check Count: ' || check_count);

   IF check_count > 0 THEN
      OPEN user_cur FOR
         SELECT *
         FROM Employees
         WHERE email = in_login AND Password = encode_pass;
   ELSIF check_count = 0 THEN
    OPEN user_cur FOR
         SELECT *
         FROM Clients
         WHERE email = in_login AND Password = encode_pass;
   ELSE
      RAISE invalid_user;
   END IF;

EXCEPTION
   WHEN invalid_user THEN
      RAISE_APPLICATION_ERROR(-20000, 'Неверные данные пользователя');
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
      RAISE;
END findUser;