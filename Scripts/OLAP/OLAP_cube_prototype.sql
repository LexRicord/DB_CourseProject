CREATE VIEW OrderCountView AS
SELECT
    TimeDimension.Year,
    TimeDimension.Month,
    ProductDimension.TypeOfAppliances,
    ProductDimension.Producer,
    ClientDimension.ClientId,
    EmployeeDimension.EmployeeId,
    OrderStateDimension.OrderStateId,
    COUNT(Orders.Id) AS OrderCount
FROM
    Orders
    JOIN TimeDimension ON Orders.OrderRegDate = TimeDimension.Date
    JOIN ProductDimension ON Orders.ModelId = ProductDimension.ModelId
    JOIN ClientDimension ON Orders.ClientId = ClientDimension.ClientId
    LEFT JOIN EmployeeDimension ON Orders.EmployeeId = EmployeeDimension.EmployeeId
    JOIN OrderStateDimension ON Orders.OrderStateId = OrderStateDimension.OrderStateId
GROUP BY
    TimeDimension.Year,
    TimeDimension.Month,
    ProductDimension.TypeOfAppliances,
    ProductDimension.Producer,
    ClientDimension.ClientId,
    EmployeeDimension.EmployeeId,
    OrderStateDimension.OrderStateId;
