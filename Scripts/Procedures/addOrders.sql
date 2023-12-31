create or replace PROCEDURE addOrders(
  in_login IN CLIENTS.EMAIL%TYPE,
  in_emplid IN ORDERS.EMPLOYEEID%TYPE,
  in_modelname IN MODELS.MODEL%TYPE,
  in_price IN ORDERS.ORDERPRICE%TYPE,
  in_descr IN ORDERS.ORDERDESCRIPTION%TYPE
) IS
  client_id NUMBER;
  estim_time_sum NUMBER;
  order_price NUMBER;
  mod_id NUMBER;
  type_id NUMBER;
  master_exists NUMBER;
  not_type NUMBER;
BEGIN
  IF in_login IS NULL OR in_emplid IS NULL OR in_modelname IS NULL OR in_descr IS NULL THEN
    RAISE_APPLICATION_ERROR(-20030, 'Проверьте введенные данные');
  END IF;

  -- Проверка, является ли сотрудник мастером
  SELECT COUNT(*)
  INTO master_exists
  FROM EMPLOYEES E
       JOIN MASTERS M ON E.ID = M.EMPLOYEESID
  WHERE M.EMPLOYEESID = in_emplid;

  IF master_exists = 0 THEN
    RAISE_APPLICATION_ERROR(-20003, 'Текущий работник не является мастером');
  END IF;

  -- Проверка, является ли мастер специалистом по данной модели
  SELECT COUNT(*)
  INTO not_type
  FROM EMPLOYEES E
       JOIN MASTERS M ON E.ID = M.EMPLOYEESID
       JOIN MODELS MO ON M.SPECTYPEID = MO.TYPEID
  WHERE MO.MODEL = in_modelname AND E.ID = in_emplid;

  IF not_type = 0 THEN
    RAISE_APPLICATION_ERROR(-20004, 'Мастер существует, но не работает с данной моделью');
  END IF;

  -- Получение ID клиента
  SELECT C.ID
  INTO client_id
  FROM CLIENTS C
  WHERE C.EMAIL = in_login;

  -- Получение ID модели
  SELECT M.ID
  INTO mod_id
  FROM MODELS M
  WHERE M.MODEL = in_modelname;

  -- Получение ID типа прибора
  SELECT T.ID
  INTO type_id
  FROM TYPEOFAPPLIANCES T
       JOIN MODELS MO ON T.ID = MO.TYPEID
  WHERE MO.ID = mod_id;

  -- Вставка новой записи в ORDERS, compldate - заглушка перед триггером after insert для ServicePacks
  INSERT INTO ORDERS (ORDERREGDATE, ORDERCOMPLDATE, ORDERPRICE, ORDERSTATEID, ORDERDESCRIPTION,
    MODELID, CLIENTID, EMPLOYEEID
  )
  VALUES (CURRENT_TIMESTAMP, CURRENT_TIMESTAMP , in_price, 6, in_descr,
    mod_id, client_id, in_emplid
  );

  COMMIT;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    RAISE_APPLICATION_ERROR(-20001, 'Нет данных');
  WHEN OTHERS THEN
    RAISE_APPLICATION_ERROR(-20000, 'Ошибка в addOrdersProcedure: ' || SQLERRM);
END addOrders;