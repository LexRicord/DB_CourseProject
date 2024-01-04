CREATE OR REPLACE PROCEDURE getServicesByServicePackOrder(in_servicepackorder in SERVICEPACKS.ServicePackOrder%Type,
curs OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN curs FOR
      SELECT Services.Name, SERVICES.PRICE, SERVICES.EstimCompTime, TYPEOFAPPLIANCES.NAME AS typename,
      Services.Id
      FROM Services
      JOIN TYPEOFAPPLIANCES ON SERVICES.TYPEAPPID = TYPEOFAPPLIANCES.ID
      JOIN SERVICEPACKS ON SERVICEPACKS.SERVICEID = Services.Id
      where SERVICEPACKS.servicepackorder = in_servicepackorder;
EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END getServicesByServicePackOrder;