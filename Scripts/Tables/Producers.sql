create table Producers
(
    Id  INTEGER GENERATED ALWAYS AS IDENTITY
    (START WITH 1 INCREMENT BY 1) primary key,
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