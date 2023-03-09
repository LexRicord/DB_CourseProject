create table Debit
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
DebitDate Date NOT NULL,
Amount decimal(5,2) NOT NULL,
ClientId int,
CONSTRAINT fkDebit_ClientId FOREIGN KEY(ClientId) REFERENCES Clients(Id)
);