-- HF: fel kell rakni a oracle sql developert, vpn-t is. SQL pass: EKKE_2026
-- ZH: ha nem fut le, gatya, egyből eggyes

-- HF: van e olyan tag a db-ben aki velünk egykorú (csak év, kor)

-- HF
SELECT vezeteknev, keresztnev, szuletesi_datum
FROM konyvtar.tag
WHERE FLOOR(MONTHS_BETWEEN(sysdate, TO_DATE('2005. 10. 30.', 'yyyy. MM. dd.')) / 12) = FLOOR(MONTHS_BETWEEN(sysdate, szuletesi_datum) / 12);

orai:

-- kik azok, szegedi nők

SELECT vezeteknev, keresztnev
FROM konyvtar.tag
WHERE tag.cim LIKE '%Szeged,%' AND nem = 'n';

-- nem krimi nem horror, kiado szerint nov, nev szerint csokk

SELECT *
FROM konyvtar.konyv
WHERE tema NOT IN ('horror', 'krimi')
ORDER BY kiado, cim DESC;

SELECT 2+3
FROM dual;

SELECT sysdate
FROM dual;

SELECT TO_CHAR(sysdate, 'yyyy.MM.dd hh24:mi:ss')
FROM dual;

SELECT TO_CHAR(sysdate, 'yyyyMMddhh24miss')
FROM dual;

SELECT TO_CHAR(sysdate, 'yyyy MONTH dd hh24:mi:ss')
FROM dual;

SELECT TO_DATE('2005. 10. 30.', 'yyyy. MM. dd.')
FROM dual;

SELECT FLOOR(MONTHS_BETWEEN(sysdate, TO_DATE('2005. 10. 30.', 'yyyy. MM. dd.')) / 12) as "Életkor"
FROM dual;

SELECT vezeteknev, keresztnev, szuletesi_datum, FLOOR(MONTHS_BETWEEN(sysdate, tag.szuletesi_datum) / 12) as "Kor"
FROM konyvtar.tag
WHERE FLOOR(MONTHS_BETWEEN(sysdate, tag.szuletesi_datum) / 12) < 30;

-- augusztusi tagok
SELECT vezeteknev, keresztnev, szuletesi_datum, TO_CHAR(szuletesi_datum, 'MM')
FROM konyvtar.tag
WHERE TO_CHAR(szuletesi_datum, 'MM') = '08';

-- téli tagok
SELECT vezeteknev, keresztnev, szuletesi_datum, TO_CHAR(szuletesi_datum, 'MM')
FROM konyvtar.tag
WHERE TO_CHAR(szuletesi_datum, 'MM') IN ('12', '01', '02');

-- szerzők akik egy naptári honapon belül 1 és tizedike kozott szulettek
SELECT vezeteknev, keresztnev, szuletesi_datum
FROM konyvtar.szerzo
WHERE TO_CHAR(szerzo.szuletesi_datum, 'dd') BETWEEN '01' AND '10';

-- zok a tagok akik 1989 előtt születtek
SELECT vezeteknev, keresztnev, szuletesi_datum
FROM konyvtar.tag
WHERE TO_CHAR(szuletesi_datum, 'yyyy') < '1989';

-- HF
SELECT vezeteknev, keresztnev, szuletesi_datum, FLOOR(MONTHS_BETWEEN(sysdate, szuletesi_datum) / 12)
FROM konyvtar.tag
WHERE FLOOR(MONTHS_BETWEEN(sysdate, TO_DATE('2005. 10. 30.', 'yyyy. MM. dd.')) / 12) = FLOOR(MONTHS_BETWEEN(sysdate, szuletesi_datum) / 12);

-- egy szerző egy konyvert mennyi honort kapott
SELECT vezeteknev, keresztnev, honorarium
FROM konyvtar.szerzo sz INNER JOIN konyvtar.konyvszerzo ksz
ON sz.szerzo_azon = ksz.szerzo_azon;

-- egy konyv könyvtári értéke
SELECT cim, ertek
FROM konyvtar.konyv k
INNER JOIN konyvtar.konyvtari_konyv kk ON k.konyv_azon = kk.konyv_azon;
   
-- ki melyik konyvet írta
SELECT cim, vezeteknev, keresztnev
FROM konyvtar.konyv k
INNER JOIN konyvtar.konyvszerzo ksz ON ksz.konyv_azon = k.konyv_azon
INNER JOIN konyvtar.szerzo sz ON ksz.szerzo_azon = sz.szerzo_azon;
