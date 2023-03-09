create table Clients
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
Login nvarchar2(50) not null unique,
PhoneNumber nvarchar2(14) not null,
Name nvarchar2(50) NOT NULL,
Surname nvarchar2(50) NOT NULL,
SecondName nvarchar2(50),
Balance decimal(5,2) default '0' not null ,
PassportNumber nvarchar2(50) default NULL,
Password nvarchar2(2000) default NULL,
PostIndex decimal(7,0) default '0' not null,
EMAIL nvarchar2(50) default '-',
MINUTES nvarchar2(50) default '-',
RemainderId int,
CONSTRAINT fkCli_Remainders FOREIGN KEY (RemainderId) REFERENCES Remainders(Id),
CONSTRAINT check_passport_number
CHECK (PassportNumber is null
or REGEXP_LIKE(PassportNumber,'^(AB|BM|HB|KH|MC|KB|PP)\d{7}'))
);

alter table Clients modify (Password visible);
alter table Clients add (Password nvarchar2(2000));
