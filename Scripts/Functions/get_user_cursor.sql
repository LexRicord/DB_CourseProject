CREATE OR REPLACE FUNCTION get_user_cursor(in_login IN NVARCHAR2, in_password IN NVARCHAR2)
RETURN SYS_REFCURSOR
AS
  cr_raw NVARCHAR2(2000);
  user_cur SYS_REFCURSOR;
BEGIN
  cr_raw := COURSE_CRYPT.ENCRYPTION_S(in_password);
  OPEN user_cur FOR SELECT * FROM Employees WHERE EMAIL = in_login AND Password = cr_raw;
  RETURN user_cur;
END get_user_cursor;
/
