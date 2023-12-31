CREATE OR REPLACE PROCEDURE getServices(curs OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN curs FOR
      SELECT Services.Name, SERVICES.PRICE, TYPEOFAPPLIANCES.NAME AS typename
      FROM Services
      JOIN TYPEOFAPPLIANCES ON SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID;
EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
      -- You can handle the exception as needed, such as raising or logging an error.
END getServices;
/
