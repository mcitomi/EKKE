create table foglalas_naplo (
    id              number(10,0) generated always as identity primary key,
    foglalas_id     number(10,0) not null,
    szobaszam       varchar2(10) not null,
    regi_ejszakak   number(2,0),
    uj_ejszakak     number(2,0),
    modositas_ideje timestamp default systimestamp not null
);
