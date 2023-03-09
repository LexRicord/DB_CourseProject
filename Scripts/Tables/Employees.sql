CREATE TABLE Employees
(
Id INTEGER GENERATED ALWAYS AS IDENTITY
(START WITH 1 INCREMENT BY 1) primary key,
Name nvarchar2(50) NOT NULL,
Surname nvarchar2(50) NOT NULL,
SecondName nvarchar2(50),
Login nvarchar2(50) NOT NULL,
EPhoneNumber nvarchar2(50) NOT NULL,
Password nvarchar2(2000) NOT NULL,
Post nvarchar2(50) NOT NULL,
CONSTRAINT check_empl_phonenumber
CHECK (REGEXP_LIKE(EPhoneNumber,'^\+375(17|29|33|44)[0-9]{7}$'))
);
alter table Employees modify (Login unique);

insert into Employees(Name, Surname, SecondName, Login,EPHONENUMBER, Password, Post)
values('Александр','Герман','Евгеньевич','admin','+375292383759','admin','admin');
select * from Employees;

drop table EMPLOYEES;