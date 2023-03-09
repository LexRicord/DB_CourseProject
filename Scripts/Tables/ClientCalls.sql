create table ClientCalls
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1),
InterlocutorNumber nvarchar2 (14) NOT NULL,
CallDuration INTERVAL DAY(0) TO SECOND NOT NULL,
CallDate DATE NOT NULL,
ClientId int,
CONSTRAINT fkClientCalls_OrdersId FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);
alter table ClientCalls modify (CallDate visible, OrdersId visible);
alter table ClientCalls add (CallDuration INTERVAL DAY(0) TO SECOND);
alter table ClientCalls drop column CallDuration;
alter table ClientCalls modify CallDate TIMESTAMP;