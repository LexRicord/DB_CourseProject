create table TypeOfAppliances
(
	Id INTEGER GENERATED ALWAYS AS IDENTITY
	(START WITH 1 INCREMENT BY 1) primary key,
	Name nvarchar2(50) UNIQUE
);
insert into TypeOfAppliances(Name)	values('Notebook');
insert into TypeOfAppliances(Name)	values('PC');
commit;