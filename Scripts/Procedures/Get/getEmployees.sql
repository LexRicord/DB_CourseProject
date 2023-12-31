CREATE OR REPLACE PROCEDURE getEmployees(curs OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN curs FOR SELECT email, Surname, Name, SecondName, Role FROM Employees;
END;
/
