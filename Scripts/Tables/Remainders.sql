create table GAE_1.REMAINDERS
(
    ID       NUMBER generated as identity
        primary key,
    RBALANCE NUMBER(5, 2)  not null,
    RMINUTES NVARCHAR2(50) not null,
    RSMS     NVARCHAR2(50) not null,
    CLIENTID NUMBER
        constraint "REMAINDERS_CLIENTS_ID_fk"
            references GAE_1.CLIENTS
)