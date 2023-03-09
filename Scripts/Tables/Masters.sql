CREATE TABLE Masters
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
NumberOfCompletedOrders int default '0',
NumberOfReturnedOrders int default '0',
MastersIncome int default '0',
EmployeesId int,
SpecTypeId int,
CONSTRAINT fkEmployees_EmployeesId FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
CONSTRAINT fkEmployees_SpecTypeId FOREIGN KEY(SpecTypeId) REFERENCES TypeOfAppliances(Id)
);
insert into Masters(EmployeesId,SpecTypeId) values(1,1);
insert into Masters(EmployeesId,SpecTypeId) values(1,2);
select * from Masters;