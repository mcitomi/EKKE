-- 1. Foglalások tábla létrehozása

CREATE TABLE foglalasok (
    id NUMBER(10,0) NOT NULL PRIMARY KEY,
    vendeg_id NUMBER(4,0) NOT NULL references vendegek(id),
    szoba_id NUMBER(4,0) NOT NULL references szobak(id),
    ellatas CHAR(1) NOT NULL CHECK (ellatas IN ('R', 'F', 'T')),
    erkezes timestamp default systimestamp,
    ejszakak NUMBER(2,0) NOT NULL CHECK(ejszakak >= 1)

    -- constraint fk_vendegek FOREIGN KEY(vendeg_id) references vendegek(id)
);