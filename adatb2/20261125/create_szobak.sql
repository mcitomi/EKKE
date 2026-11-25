create table szobak (
    id        number(4,0) not null primary key,
    szobaszam varchar2(10) not null,
    tipus     varchar2(100) not null check ( tipus in ( 'egyagyas',
                                                       'ketagyas',
                                                       'lakosztaly' ) ),
    emelet    number(2,0) not null
);

INSERT INTO szobak (id, szobaszam, tipus, emelet)
VALUES (3001, '101', 'egyagyas', 1);

INSERT INTO szobak (id, szobaszam, tipus, emelet)
VALUES (3002, '204', 'ketagyas', 2);

INSERT INTO szobak (id, szobaszam, tipus, emelet)
VALUES (3003, '501', 'lakosztaly', 5);

INSERT INTO szobak (id, szobaszam, tipus, emelet)
VALUES (3004, '112', 'egyagyas', 1);

INSERT INTO szobak (id, szobaszam, tipus, emelet)
VALUES (3005, '310', 'ketagyas', 3);

commit;
