CREATE OR REPLACE PROCEDURE getTypeByModel(in_model in MODELS.MODEL%TYPE, curs OUT SYS_REFCURSOR)
IS
BEGIN
   OPEN curs FOR
      SELECT TYPEOFAPPLIANCES.NAME AS typename
      FROM TYPEOFAPPLIANCES
      JOIN Models ON Models.TYPEID = TYPEOFAPPLIANCES.ID
      where Models.MODEL = in_model;
EXCEPTION
   WHEN OTHERS THEN
      DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
END getTypeByModel;
/