create or replace function get_user_cursor_by_login(in_login in nvarchar2, in_password in nvarchar2)
return sys_refcursor
as
cr_raw raw(2000);
user_cur sys_refcursor;
begin
    cr_raw := COURSE_CRYPT.ENCRYPTION_S(in_password);
    open user_cur for select * from Employees where Login=in_login and Password=cr_raw;
    return user_cur;
end get_user_cursor_by_login;