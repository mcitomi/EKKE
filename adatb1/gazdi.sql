create table Gazdi(
    Gazdi_id char(3) not null,
    vnev VARCHAR2(40),
    knev VARCHAR2(40),
    varos VARCHAR2(40),
    nem char(1),
    constraint pk_gazdi primary key(Gazdi_id)
);

create table Gazdi(
    Gazdi_id char(3) not null,
    vnev varchar2(40),
    knev varchar2(40),
    varos varchar2(40),
    nem char(1),
    constraint gazdi_pk primary key(Gazdi_id)
    );

drop table Gazdi;

select *
from gazdi;
-- szerkezeti módosítás
alter table gazdi
rename column vnev to vezeteknev;
alter table gazdi
rename column knev to keresztnev;


select *
from gazdi;

insert into gazdi values('001', 'Kiss', 'Pista', 'Eger', 'f');
insert into gazdi values('002', 'Nagy', 'Piroska', 'Debrecen', 'n');
insert into gazdi values('003', 'Kovács', 'Zoltán', 'Eger', 'f');
insert into gazdi values('004', 'Molnár', 'Ákos', 'Budapest', 'f');
insert into gazdi values('005', 'Molnár', 'Éva', 'Budapest', 'n');
insert into gazdi values('006', 'Kiss', 'Ibolya', 'Eger', 'n');



create table kedvenc(
    kedvenc_id number(3) not null,
    nev varchar2(20),
    faj varchar2(20),
    kor number(3),
    gazdi_id char(3) references gazdi(gazdi_id),
    constraint kedvenc_pk PRIMARY key(kedvenc_id));

INSERT INTO kedvenc VALUES (101, 'Marcipán', 'Cica', 2, '001');
INSERT INTO kedvenc VALUES (102, 'Fifi', 'Kutya', 3, '001');
INSERT INTO kedvenc VALUES (103, 'Barcelona', 'Hal', 1, '002');
INSERT INTO kedvenc VALUES (104, '', 'Hal', '', '002');
INSERT INTO kedvenc VALUES (105, '', 'Hal', '', '002');
INSERT INTO kedvenc VALUES (106, 'Kormi', 'Cica', 5, '005');
INSERT INTO kedvenc VALUES (107, 'Cuki', 'Madár', 3, '006');
INSERT INTO kedvenc VALUES (108, 'Bodri', 'Kutya', 3, '006');
INSERT INTO kedvenc VALUES (109, 'Bözsi', 'Tehén', 6, '001');
INSERT INTO kedvenc VALUES (110, 'Csőri', 'Madár', '', '001');
INSERT INTO kedvenc VALUES (111, '', 'Tyúk', 2, '002');
INSERT INTO kedvenc VALUES (112, '', 'Kakas', 2, '001');

select *
from kedvenc;

select nev, faj, vezeteknev, keresztnev
from kedvenc k inner join gazdi g
on k.gazdi_id = g.gazdi_id;

select *
from kedvenc k right join gazdi g
on k.gazdi_id = g.gazdi_id;

select *
from gazdi g left join kedvenc k
on k.gazdi_id = g.gazdi_id
where kedvenc_id is null;

alter table kedvenc
add (szin varchar2(20));

select *
from kedvenc;

update kedvenc
set szin = 'fekete'
where faj = 'Cica';

commit;

delete kedvenc
where kor is null;


update kedvenc
set szin = 'Fehér'
where faj = 'Kutya';

select *
from kedvenc;

rollback;


update gazdi
set keresztnev = 'Lilla'
where gazdi_id = '002';

select *
from gazdi;
 --- !!!! Klónozás
create table konyv as(
select *
from konyvtar.konyv);
 --- !!!! Klónozás

--töröljük a horror témájú könyveket

select *
from konyv;

delete from konyv
where tema = 'horror';

delete from konyv
where tema is null;

drop table konyv;

-- klónozás --> feladat megoldása --> tábla eldobása (zh így kérem beadni)

create table tag_1 as (
select *
from konyvtar.tag);

-- 18 év alattiak besorolása legyen kiskoru

update tag_1
set besorolas = 'kiskoru'
where months_between(sysdate, szuletesi_datum)/12 < 18;

select *
from tag_1;

-- töröljük az Erna keresztnevű nőket

drop table tag_1;

delete from tag_1
where keresztnev = 'Erna';

-- ahol nem ismert a kiadó legyen 'Nem ismert' string

select cim, nvl(kiado, 'Nem ismert')
from konyvtar.konyv;

create table konyv as(
select *
from konyvtar.konyv);

drop table konyv;

update konyv
set kiado = 'nem ismert'
where kiado is null;
-- szúrjunk be a szerzőbe egy nem oszlopot
create table szerzo as(
select *
from konyvtar.szerzo);

alter table szerzo
add column (nem char(1));

-- a 2000 után kiadott könyvek árát növeljük a duplájára az oldalszámát felezzük el


drop table konyv;

create table konyv as
(select *
from konyvtar.konyv);

update konyv
set ar = ar * 2, oldalszam = oldalszam / 2
where kiadas_datuma >=to_date('2000', 'yyyy');


select *
from konyv;