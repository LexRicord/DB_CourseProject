CREATE DIMENSION Product_Dim
LEVEL ProductType IS TypeOfAppliances.Name
LEVEL Producer IS Producers.Producer
LEVEL Model IS Models.Model
HIERARCHY ProductHierarchy (ProductType IS ProductType, Producer IS Producer, Model IS Model);

CREATE DIMENSION Services_Dim
LEVEL Services_Level IS (
    ServiceId INTEGER,
    ServiceName NVARCHAR2(100),
    ServiceCategory NVARCHAR2(50),
    ServicePrice DECIMAL
) HIERARCHIES (
    Services_Hierarchy IS (
        ServiceName IS Services_Level.ServiceName,
        ServiceCategory IS Services_Level.ServiceCategory,
        ServicePrice IS Services_Level.ServicePrice
    )
);

CREATE DIMENSION Orders_Dim
LEVEL Orders_Level IS (
    OrderId INTEGER,
    CustomerId INTEGER,
    ServiceId INTEGER,
    OrderDate DATE,
    OrderStatus NVARCHAR2(50),
    PaymentStatus NVARCHAR2(50),
    OrderAmount DECIMAL
) HIERARCHIES (
    Orders_Hierarchy IS (
        CustomerId IS Orders_Level.CustomerId,
        ServiceId IS Orders_Level.ServiceId,
        OrderDate IS Orders_Level.OrderDate,
        OrderStatus IS Orders_Level.OrderStatus,
        PaymentStatus IS Orders_Level.PaymentStatus,
        OrderAmount IS Orders_Level.OrderAmount
    )
);
