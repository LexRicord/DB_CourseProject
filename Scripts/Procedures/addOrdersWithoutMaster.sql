CREATE OR REPLACE PROCEDURE addOrdersWithoutMaster(
  in_login IN CLIENTS.EMAIL%TYPE,
  in_modelname IN MODELS.MODEL%TYPE,
  in_price IN ORDERS.ORDERPRICE%TYPE,
  in_descr IN ORDERS.ORDERDESCRIPTION%TYPE
) IS
  spackinfo_id NUMBER;
  client_id NUMBER;
  order_price NUMBER;
  mod_id NUMBER;
  type_id NUMBER;
  master_exists NUMBER;
  not_type NUMBER;
BEGIN
  IF in_login IS NULL OR in_modelname IS NULL OR in_descr IS NULL THEN
    RAISE_APPLICATION_ERROR(-20030, 'Проверьте введенные данные');
  END IF;

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
  
  -- Вставка новой записи в ORDERS
  INSERT INTO ORDERS (ORDERREGDATE, ORDERPRICE, ORDERSTATEID, ORDERDESCRIPTION,
    MODELID, CLIENTID
  )
  VALUES (CURRENT_TIMESTAMP, in_price, 6, in_descr,
    mod_id, client_id
  );

  COMMIT;
EXCEPTION
  WHEN NO_DATA_FOUND THEN
    RAISE_APPLICATION_ERROR(-20001, 'Нет данных');
  WHEN OTHERS THEN
    RAISE_APPLICATION_ERROR(-20000, 'Ошибка в addOrdersProcedure: ' || SQLERRM);
END addOrdersWithoutMaster;