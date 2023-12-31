CREATE OR REPLACE PROCEDURE getServiceByTypeAndName(in_serviceName Services.Name%TYPE, in_type TYPEOFAPPLIANCES.NAME%TYPE,curs OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN curs FOR
      SELECT Services.Name, SERVICES.PRICE, services.estimcomptime, TYPEOFAPPLIANCES.NAME AS typename, Services.Id
      FROM Services
      JOIN TYPEOFAPPLIANCES ON SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
      where Services.Name = in_serviceName and TYPEOFAPPLIANCES.NAME = in_type;
EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END getServiceByTypeAndName;