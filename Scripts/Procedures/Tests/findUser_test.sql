DECLARE
  -- Variables for testing
  v_login Employees.email%TYPE := 'admin@mail.ru';
  v_password Employees.Password%TYPE := 'admin';
  v_user_cur SYS_REFCURSOR;

BEGIN
  -- Call the findUser procedure
  findUser(v_login, v_password, v_user_cur);

  -- Check if the cursor contains at least one row
  IF NOT SQL%FOUND THEN
    DBMS_OUTPUT.PUT_LINE('Test failed: No user found for the given credentials');
    RETURN;
  END IF;

  -- Check if the returned columns have the expected values
  DECLARE
    v_id Employees.Id%TYPE;
    v_email Employees.Email%TYPE;
    v_role Employees.Role%TYPE;
  BEGIN
    FETCH v_user_cur INTO v_id, v_email, v_role;

    IF v_id IS NULL THEN
      DBMS_OUTPUT.PUT_LINE('Test failed: User ID is null');
      RETURN;
    END IF;

    IF v_email != v_login THEN
      DBMS_OUTPUT.PUT_LINE('Test failed: Unexpected email returned');
      RETURN;
    END IF;

    IF v_role IS NULL THEN
      DBMS_OUTPUT.PUT_LINE('Test failed: User role is null');
      RETURN;
    END IF;

    -- Add more assertions based on your specific data
  END;

  DBMS_OUTPUT.PUT_LINE('Test passed: findUser procedure successfully retrieved user data');
EXCEPTION
  WHEN OTHERS THEN
    -- Log or handle exceptions as needed
    DBMS_OUTPUT.PUT_LINE('Error: ' || SQLERRM);
    RAISE;
END;