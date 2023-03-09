create table ServicePack
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
SPackInfo int,
ServiceId int,
CONSTRAINT fkServicePackInfo_SPackInfo FOREIGN KEY (SPackInfo) REFERENCES ServicePack(Id),
CONSTRAINT fkServices_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id)
);