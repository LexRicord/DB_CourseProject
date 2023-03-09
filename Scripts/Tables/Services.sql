create table Services
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
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

select Services.Name,Services.Price,Services.EstimCompTime,TypeOfAppliances.TypeName
from Services inner join TypeOfAppliances
on Services.TypeAppId=TypeOfAppliances.Id;

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
