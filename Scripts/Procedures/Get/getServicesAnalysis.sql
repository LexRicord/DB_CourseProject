CREATE OR REPLACE PROCEDURE GetServiceAnalysis(
    p_cursor OUT SYS_REFCURSOR
)
AS
BEGIN
    OPEN p_cursor FOR
    SELECT
        Services.Name AS ServiceName,
        Orders.Id AS OrderId,
        COUNT(Orders.Id) AS TotalOrders,
        COUNT(DISTINCT Orders.ClientId) AS UniqueClients,
        AVG(Services.Price) AS AvgServicePrice,
        MAX(Services.Price) AS MaxServicePrice,
        MIN(Services.Price) AS MinServicePrice,
        SUM(Services.EstimCompTime) AS TotalEstimatedCompletionTime
    FROM
        Services
    JOIN
        ServicePacks ON Services.Id = ServicePacks.SERVICEID
    LEFT JOIN
        Orders ON ServicePacks.ServicePackOrder = Orders.Id
    LEFT JOIN
        OrderStates ON Orders.OrderStateId = OrderStates.Id
    GROUP BY
        Services.Name, Orders.Id;

END;
/
