create table vendegek (
    id      number(4,0) not null primary key,
    nev     varchar2(250) not null,
    statusz char(1) not null check ( statusz in ( 'A', 'T' ) )
);

INSERT INTO vendegek (id, nev, statusz) VALUES (1, 'Kozma Levente', 'A');
INSERT INTO vendegek (id, nev, statusz) VALUES (2, 'Simon Eszter', 'T');
INSERT INTO vendegek (id, nev, statusz) VALUES (3, 'Juhász Márton', 'A');
INSERT INTO vendegek (id, nev, statusz) VALUES (4, 'Vincze Petra', 'A');
INSERT INTO vendegek (id, nev, statusz) VALUES (5, 'Bognár Ádám', 'T');
COMMIT;
