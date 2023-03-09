create or replace function get_client_cursor(in_login in nvarchar2, in_password in nvarchar2)
return sys_refcursor
as
    user_cur sys_refcursor;
    encode_pass nvarchar2(2000);
  begin
      encode_pass := COURSE_CRYPT.ENCRYPTION_S(in_password);
    open user_cur for select CLIENTS.Id, M.Model, Clients.Password from Clients
        join Orders on Clients.Id=Orders.ClientId
        join MODELS M on ORDERS.MODELID = M.ID
        where CLIENTS.LOGIN=in_login and Clients.Password=encode_pass;
    return user_cur;
  end get_client_cursor;