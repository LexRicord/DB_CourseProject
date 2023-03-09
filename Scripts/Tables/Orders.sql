create table Orders
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
PhoneNumber nvarchar2(14) NOT NULL,
OrderRegDate DATE NOT NULL,
OrderComplDate DATE NOT NULL,
OrderPrice int default 0,
OrderState number(1,0) default 0,
ServiceId int NOT NULL,
ServicePackInfoId int NOT NULL,
ModelId int NOT NULL,
ClientId int NOT NULL,
EmployeeId int NOT NULL,
CONSTRAINT fk_ServicePackInfoId FOREIGN KEY (ServicePackInfoId) REFERENCES ServicePackInfo(Id),
CONSTRAINT fk_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id),
CONSTRAINT fkOrders_ModelId FOREIGN KEY (ModelId) REFERENCES Models(Id),
CONSTRAINT fkOrders_ClientId FOREIGN KEY (ClientId) REFERENCES CLIENTS(Id),
CONSTRAINT fk_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES EMPLOYEES(Id)
);

alter table Orders add CONSTRAINT fkOrders_ModelId FOREIGN KEY (ModelId) REFERENCES Models(Id);
alter table Orders add CONSTRAINT fkOrders_ClientId FOREIGN KEY (ClientId) REFERENCES CLIENTS(Id);
alter table Orders add CONSTRAINT fk_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES EMPLOYEES(Id);
alter table Orders modify (ServiceId visible, ClientId visible, EmployeeId visible);
commit;