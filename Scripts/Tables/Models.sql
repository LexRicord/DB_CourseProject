create table Models
(
	Id INTEGER GENERATED ALWAYS AS IDENTITY
	(START WITH 1 INCREMENT BY 1) primary key,
	Model nvarchar2(50),
	ProducerId int,
    TypeId int not null,
	CONSTRAINT fkModels_ProducerId FOREIGN KEY (ProducerId) REFERENCES Producers(Id),
    CONSTRAINT fkModels_TypeOfAppliancesId FOREIGN KEY (TypeId) REFERENCES TypeOfAppliances(Id)
);
alter table MODELS modify (MODEL unique);

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

select Producers.Producer, Models.Model,TypeOfAppliances.TypeName
from Models inner join Producers
on Producers.Id=Models.ProducerId
inner join TypeOfAppliances 
on TypeOfAppliances.Id = Models.TypeId;