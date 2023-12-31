create table TypeOfAppliances
(
	Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	Name nvarchar2(50) UNIQUE
);
insert into TypeOfAppliances(Name)	values('Notebook');
insert into TypeOfAppliances(Name)	values('PC');
commit;
create table Producers
(
    Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    Producer nvarchar2(50) UNIQUE
); 
insert into Producers(Producer)	values('Acer');
insert into Producers(Producer)	values('Apple');
insert into Producers(Producer)	values('Asus');
insert into Producers(Producer)	values('Dell');
insert into Producers(Producer)	values('Dream Machines');
insert into Producers(Producer)	values('HP');
insert into Producers(Producer)	values('Huawei');
insert into Producers(Producer)	values('Lenovo');
insert into Producers(Producer)	values('Prestigio');
insert into Producers(Producer)	values('Xiaomi');
commit;
create table Models
(
	Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	Model nvarchar2(50) UNIQUE,
	ProducerId int,
    	TypeId int not null,
	CONSTRAINT fkModels_ProducerId FOREIGN KEY (ProducerId) REFERENCES Producers(Id),
    	CONSTRAINT fkModels_TypeOfAppliancesId FOREIGN KEY (TypeId) REFERENCES TypeOfAppliances(Id)
);
--alter table MODELS modify (MODEL unique);
insert into Models(ProducerId, Model, TypeId) values(1,'Aspire A315-21G-955U',2);
            insert into Models(ProducerId, Model, TypeId) values (1,'Nitro 5 AN515-52-50NB',2);
            insert into Models(ProducerId, Model, TypeId) values (1,'Aspire 5 A515-54-38HR',2);
            insert into Models(ProducerId, Model, TypeId)	values  (1,'Aspire 5 A515-54G-30WF',2);
            insert into Models(ProducerId, Model, TypeId)	values  (1,'Aspire 3 A317-51G-50AD',2);
            insert into Models(ProducerId, Model, TypeId) values (1,'Nitro 5 AN515-54-79MM',2);
            insert into Models(ProducerId, Model, TypeId) values  (1,'Aspire A315-21-94QT',2);
            insert into Models(ProducerId, Model, TypeId)	values  (1,'Acer Predator PH315-52-768W',2);
            insert into Models(ProducerId, Model, TypeId)	values  (1,'Predator PH517-51-59A6',2);
            
            insert into Models(ProducerId, Model, TypeId)	values  (1,'Aspire 3 A317-51G-35PU',1);
            insert into Models(ProducerId, Model, TypeId) values  (1,'A315-34-C6W0',1);
            insert into Models(ProducerId, Model, TypeId) values  (1,'Swift 5 SF514-52T-590S',1);
            insert into Models(ProducerId, Model, TypeId) values  (1,'Aspire A315-51-39TT',1);
            insert into Models(ProducerId, Model, TypeId)	values (1,'Aspire A515-54G-57LM',1);
            insert into Models(ProducerId, Model, TypeId)	values (2,'MacBook Air 13" 2020 512GB/MVH22',1);
            insert into Models(ProducerId, Model, TypeId)	values (2,'MacBook Air 13" 2019 128GB/MVFH2',1);
            insert into Models(ProducerId, Model, TypeId)	values  (2,'MacBook Pro 13" Touch Bar 2019 128GB/MUHN2',1);
            insert into Models(ProducerId, Model, TypeId)  values (2,'MacBook Pro 16" Touch Bar 2019 512GB/MVVL2',1);
            insert into Models(ProducerId, Model, TypeId) values  (2,'MacBook Air 13" 2020 256GB/MWTK2',1);
            insert into Models(ProducerId, Model, TypeId) values (2,'MacBook Pro 13" Touch Bar 2019 128GB/MUHQ2',1);
            insert into Models(ProducerId, Model, TypeId) values (2,'MacBook Pro 13" 128GB/MPXQ2',1);
            insert into Models(ProducerId, Model, TypeId)	values  (2,'MacBook Pro 15" Touch Bar/MR962',1);
            insert into Models(ProducerId, Model, TypeId) values (3,'TUF Gaming FX505DY-BQ009',1);
            insert into Models(ProducerId, Model, TypeId)	values  (3,'X407MA-BV088T',1);
            insert into Models(ProducerId, Model, TypeId)	values  (3,'X509FB-EJ221',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'VivoBook X512FL-BQ287',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'TUF Gaming FX505DT-AL187',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'X571GT-BQ214',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'X509FB-EJ185',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'X509FJ-EJ014',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'ROG Strix G G731GT-AU004T',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'ROG Strix G G531GT-AL499',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'F509FJ-EJ392',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'ROG Zephyrus G15 GA502IU-AL051',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'VivoBook X505ZA-BR004',1);
              insert into Models(ProducerId, Model, TypeId)	values  (3,'ROG Zephyrus S GX502GV-AZ035',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Vostro 3581 (210-ARKV-273277506)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron 3582-9881',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron 15 (3583-1940)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron G3 15 (3590-4888)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Vostro 5481 (210-AQZC-273227235)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'G3 15 (3590-4830)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron 15 (3583-2877)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Vostro 3590 (210-ASVS-273284148)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Vostro 14 (5490-279955)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Dell G3 17 (3779-9123)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'XPS 13 (9380-0150)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'XPS 13 (9370-1695)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Vostro (3590-275493)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron 15 (3576-1480)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (4,'Inspiron 17 (3793-2928)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1660Ti-15BY45',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1660Ti-15BY40',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1660Ti-15BY41',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1650-15BY40',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1660Ti-15BY21',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1650-15BY22',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1650-15BY28',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1660Ti-15BY20',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1050-15BY51',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1050Ti-15BY28',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1050-15BY57',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1050-17BY57',1);
              insert into Models(ProducerId, Model, TypeId)	values  (5,'G1050-17BY58',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-da0482ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-db0113ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-db0441ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'Pavilion Gaming 15-cx0124ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-db0452ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'250 G7(6MQ39EA)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'250 G7(6BP26EA)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'Pavilion 13-an0031ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'HP Omen 15-dc0084ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-db0429ur(7BW51EA)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'255 G7 (7DF20EA)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'HP Pavilion Gaming 15-ec0035ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'15-db0450ur',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'255 G7 (6BP86ES)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (6,'ProBook 455 G6 (7QL74ES)',1);
              insert into Models(ProducerId, Model, TypeId)	values  (7,'MateBook X Pro MACH-W19',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad L340-15',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad S145-15',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad S145-15AST',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad S145-15IGM',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad S145-15API',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad S145-15IWL',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad 330-15ARR',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad L340-15IRH Gaming',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad L340-15API',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad 330-15AST',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'IdeaPad 330-15IKBR',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'Legion Y540-15IRH',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'Legion Y530-15ICH',1);
              insert into Models(ProducerId, Model, TypeId)	values  (8,'ThinkBook 13s-IWL',1);
              insert into Models(ProducerId, Model, TypeId)	values  (9,'SmartBook 141 C3/DB_CIS',1);
              insert into Models(ProducerId, Model, TypeId)	values  (9,'SmartBook 141 C3/DG_CIS',1);
              insert into Models(ProducerId, Model, TypeId)	values  (9,'SmartBook 141 C4/MG_CIS',1);
              insert into Models(ProducerId, Model, TypeId)	values  (9,'SmartBook 141 C4/DG_CIS',1);
              insert into Models(ProducerId, Model, TypeId)	values  (9,'Visconte Ecliptica',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook/JYU4140CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook Pro/JYU4057CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook Pro/JYU4147CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook Pro/JYU4035CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook/JYU4093CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'Mi Notebook Air/JYU4149CN',1);
              insert into Models(ProducerId, Model, TypeId)	values  (10,'RedmiBook JYU4153CN',1);
commit;
select Producers.Producer, Models.Model,TypeOfAppliances.Name
from Models inner join Producers
on Producers.Id=Models.ProducerId
inner join TypeOfAppliances 
on TypeOfAppliances.Id = Models.TypeId;

create table Services
(
	Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	Name nvarchar2(50) NOT NULL,
	Price nvarchar2(5) NOT NULL,
	EstimCompTime int not null,
	TypeAppId int not null,
	CONSTRAINT fkServices_TypeAppId FOREIGN KEY(TypeAppId) REFERENCES TypeOfAppliances(Id),
	CONSTRAINT check_comp_time
	CHECK (EstimCompTime >= 0),
	CONSTRAINT check_price
	CHECK (Price >= 0)
);

    	 insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Диагностика', '5', 4, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена сетевой карты', 21, 2, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Ремонт материнской платы', 73, 72, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Ремонт блока питания', 26, 10, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Ремонт кулера', 18, 3, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена процессора', 48, 12, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена ОЗУ', 14, 2,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Установка/переустановка ПО', 25, 4,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Подключение периф. устройств', 15, 1, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Установка драйверов', 8, 3, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена/ремонт видеокарты', 150, 12, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена матрицы', 70, 8,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Чистка аппаратов после попадания влаги', 85, 30,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена/ремонт клавиатуры', 60, 6,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена динамиков', 30, 2, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Замена разъемов', 15, 10,1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Ремонт петель', 20, 4, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Чистка системы охлаждения', 25, 2, 1);
	insert into Services(Name, Price,EstimCompTime, TypeAppId) values	('Другое', 0, 0, 1);

    insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Диагностика', 5, 6, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена сетевой карты', 80,4,2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Ремонт материнской платы', 220, 96, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Ремонт блока питания', 100, 25,2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Ремонт кулера', 38, 4, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена процессора', 48, 6, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена ОЗУ', 200, 2,2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Установка/переустановка ПО', 15, 6, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Подключение периф. устройств', 15, 2, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Установка драйверов', 8, 2, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена/ремонт видеокарты', 150, 24, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена матрицы', 150, 20, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Чистка аппаратов после попадания влаги', 100, 40,2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена/ремонт клавиатуры', 45, 3, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена динамиков', 50, 1, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Замена разъемов', 55, 3, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Полный ремонт/Замена дисковода', 60, 6, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Чистка системы охлаждения', 10, 2, 2);
	insert into Services(Name, Price, EstimCompTime, TypeAppId) values	('Другое', 0, 0, 2);

select Services.Name,Services.Price,Services.EstimCompTime,TypeOfAppliances.Name
from Services inner join TypeOfAppliances
on Services.TypeAppId=TypeOfAppliances.Id;

CREATE TABLE Clients
(
    Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    Email NVARCHAR2(256) NOT NULL UNIQUE,
    PhoneNumber NVARCHAR2(14) DEFAULT NULL,
    Name NVARCHAR2(50) DEFAULT '-' NOT NULL,
    Surname NVARCHAR2(50) DEFAULT '-' NOT NULL,
    SecondName NVARCHAR2(50) DEFAULT '-' NOT NULL,
    PassportNumber NVARCHAR2(12) DEFAULT '-',
    Password NVARCHAR2(2000) DEFAULT NULL,
    PostIndex NUMBER(7, 0) DEFAULT 0 NOT NULL,
    Balance NUMBER(7, 2),
    Role NVARCHAR2(30),
    CONSTRAINT check_client_email CHECK (REGEXP_LIKE(Email, '.*@.*\..*', 'i')),
    CONSTRAINT check_passport_number CHECK (
        PassportNumber = '-' OR
        REGEXP_LIKE(PassportNumber, 'AB[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'BM[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'HB[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'KH[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'MC[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'KB[0-9]{7}', 'i') OR
        REGEXP_LIKE(PassportNumber, 'PP[0-9]{7}', 'i')
    ),
    CONSTRAINT check_cli_phonenumber CHECK (
        REGEXP_LIKE(PhoneNumber, '\+37529[0-9]{7}', 'i') OR
        REGEXP_LIKE(PhoneNumber, '\+37517[0-9]{7}', 'i') OR
        REGEXP_LIKE(PhoneNumber, '\+37533[0-9]{7}', 'i') OR
        REGEXP_LIKE(PhoneNumber, '\+37544[0-9]{7}', 'i')
    )
);

CREATE TABLE Employees (
    Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    Email NVARCHAR2(256) NOT NULL UNIQUE,
    Name NVARCHAR2(50) DEFAULT '-' NOT NULL,
    Surname NVARCHAR2(50) DEFAULT '-' NOT NULL,
    SecondName NVARCHAR2(50) DEFAULT '-' NOT NULL,
    EPhoneNumber NVARCHAR2(14), 
    Password NVARCHAR2(2000) NOT NULL,
    Role NVARCHAR2(50) NOT NULL,
    CONSTRAINT check_employee_email CHECK (REGEXP_LIKE(Email, '.*@.*\..*', 'i')), 
    CONSTRAINT check_empl_phonenumber CHECK (
        REGEXP_LIKE(EPhoneNumber, '\+37529[0-9]{7}', 'i') OR
        REGEXP_LIKE(EPhoneNumber, '\+37517[0-9]{7}', 'i') OR
        REGEXP_LIKE(EPhoneNumber, '\+37533[0-9]{7}', 'i') OR
        REGEXP_LIKE(EPhoneNumber, '\+37544[0-9]{7}', 'i')
    )
);


INSERT INTO Employees (Email, Name, Surname, SecondName, EPhoneNumber, Password, Role)
VALUES ('admin@mail.ru', 'Александр', 'Герман', 'Евгеньевич', '+375292383759', '764FD29C35622204B5192753E5A66BB9','admin');

SELECT * FROM Employees;

CREATE TABLE Masters
(
	Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	NumberOfCompletedOrders int default '0',
	NumberOfReturnedOrders int default '0',
	EmployeesId int,
	SpecTypeId int,
	CONSTRAINT fkEmployees_EmployeesId FOREIGN KEY(EmployeesId) REFERENCES Employees(Id),
	CONSTRAINT fkEmployees_SpecTypeId FOREIGN KEY(SpecTypeId) REFERENCES TypeOfAppliances(Id)
);

create table OrderStates
(
	Id NUMBER(1,0) GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	StateDescription NVARCHAR2(50) NOT NULL,
	OrderStateCounter int default '0',
	CONSTRAINT check_order_state
	CHECK (Id <= 10 and Id >= 0)
);

insert into OrderStates(StateDescription) values('Заказ выполняется');
insert into OrderStates(StateDescription) values('Заказ готов');
insert into OrderStates(StateDescription) values('Заказ возвращён');
insert into OrderStates(StateDescription) values('Заказ требует согласования');
insert into OrderStates(StateDescription) values('Заказ переоформлен');
insert into OrderStates(StateDescription) values('Заказ не принят');
select * from OrderStates;

CREATE TABLE Orders
(
    Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    OrderRegDate DATE NOT NULL,
    OrderComplDate DATE,
    OrderPrice INT DEFAULT 0,
    OrderStateId NUMBER(1,0) DEFAULT 0,
    OrderDescription NVARCHAR2(1000),
    ModelId INT NOT NULL,
    ClientId INT NOT NULL,
    EmployeeId INT,
    CONSTRAINT fkOrders_ModelId FOREIGN KEY (ModelId) REFERENCES Models(Id),
    CONSTRAINT fkOrders_ClientId FOREIGN KEY (ClientId) REFERENCES CLIENTS(Id),
    CONSTRAINT fk_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES EMPLOYEES(Id),
    CONSTRAINT fkOrders_OrderStateId FOREIGN KEY (OrderStateId) REFERENCES OrderStates(Id)
);

create table ServicePacks
(
	Id NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY 
	(START WITH 1 INCREMENT BY 1) PRIMARY KEY,
	ServicePackOrder int,
	ServiceId int,

	CONSTRAINT fkOrders_SPackOrder FOREIGN KEY (ServicePackOrder) REFERENCES Orders(Id),
	CONSTRAINT fkServices_ServiceId FOREIGN KEY (ServiceId) REFERENCES Services(Id)
);
CREATE TABLE BalanceHistory
(
    TransactionId NUMBER GENERATED BY DEFAULT ON NULL AS IDENTITY (START WITH 1 INCREMENT BY 1) PRIMARY KEY,
    ClientId NUMBER NOT NULL,
    SumOfTransaction NUMBER(7, 0) DEFAULT 0 NOT NULL,
    TypeOfTransaction NVARCHAR2(25),
    OrderId NUMBER DEFAULT 0,
    CONSTRAINT fkBalanceHistory_ClientId FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);


