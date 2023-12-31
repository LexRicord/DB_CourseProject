SELECT
    t1.OrderRegDate AS "Дата заказа",
    t7.Producer AS "Производитель",
    t2.Model AS "Модель",
    t3.Name AS "Тип устройства",
    t4.ServicePackOrder AS "Номер заказа",
    t5.StateDescription AS "Статус заказа",
    t6.Name AS "Тип услуги",
    t6.Price AS "Цена услуги",
    t6.EstimCompTime AS "Время выполнения услуги"
FROM Orders t1
JOIN Models t2 ON t1.ModelId = t2.Id
JOIN TypeOfAppliances t3 ON t2.TypeId = t3.Id
JOIN ServicePacks t4 ON t1.Id = t4.ServicePackOrder
JOIN OrderStates t5 ON t1.OrderStateId = t5.Id
JOIN Services t6 ON t4.ServiceId = t6.Id
Join Producers t7 on t2.ProducerId = t7.Id

