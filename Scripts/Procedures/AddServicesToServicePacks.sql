CREATE OR REPLACE PROCEDURE AddServicesToServicePacks (
  in_service_id IN NUMBER,
  in_order_number IN NUMBER
) AS
BEGIN
  -- Вставляем данные в таблицу ServicePacks
  INSERT INTO ServicePacks (ServicePackOrder, ServiceId)
  VALUES (in_order_number, in_service_id);

  COMMIT;
END AddServicesToServicePacks;
