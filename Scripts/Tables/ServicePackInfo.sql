create table ServicePackInfo
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
TypeAppId int not null,
CONSTRAINT fkServPackInfo_TypeAppId FOREIGN KEY(TypeAppId) REFERENCES TypeOfAppliances(Id)
);