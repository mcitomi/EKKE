-- Mely szerzők összesített honoráriuma haladja meg a 10 000 Ft-ot?
SELECT szerzo.szerzo_azon, szerzo.vezeteknev, szerzo.keresztnev, SUM(konyvszerzo.honorarium) 
FROM KONYVTAR.szerzo
INNER JOIN KONYVTAR.konyvszerzo ON konyvszerzo.szerzo_azon = szerzo.szerzo_azon
GROUP BY szerzo.szerzo_azon, szerzo.vezeteknev, szerzo.keresztnev
HAVING SUM(konyvszerzo.honorarium) > 10000;

-- Mely témákhoz tartozik legalább 3 könyv az adatbázisban?
SELECT konyv.tema, COUNT(konyv.tema) FROM KONYVTAR.konyv 
GROUP BY konyv.tema
HAVING COUNT(konyv.tema) >= 3;

-- Mely tagok kölcsönöztek 3-nál több könyvet?
SELECT tag_azon, tag.vezeteknev, tag.keresztnev, COUNT(*) FROM KONYVTAR.tag
INNER JOIN KONYVTAR.kolcsonzes ON kolcsonzes.tag_azon = tag.olvasojegyszam
GROUP BY tag_azon, tag.vezeteknev, tag.keresztnev
HAVING COUNT(*) > 3;

-- Mely kiadók esetén haladja meg a könyvek átlagára a 6000 Ft-ot?
SELECT konyv.kiado, AVG(konyv.ar) FROM KONYVTAR.konyv
GROUP BY konyv.kiado
HAVING AVG(konyv.ar) > 6000;

-- Mely tagok fizettek 500 Ft-nál több késedelmi díjat összesen?
SELECT kolcsonzes.tag_azon, tag.vezeteknev, tag.keresztnev, SUM(kolcsonzes.kesedelmi_dij) FROM KONYVTAR.tag
INNER JOIN KONYVTAR.kolcsonzes ON kolcsonzes.tag_azon = tag.olvasojegyszam
GROUP BY kolcsonzes.tag_azon, tag.vezeteknev, tag.keresztnev
HAVING SUM(kolcsonzes.kesedelmi_dij) > 500;

-- Mi a címe azoknak a könyveknek, amelyek szerzője 1980 után született?
SELECT cim, szuletesi_datum, TO_CHAR(szuletesi_datum, 'yyyy.MM.dd.') FROM KONYVTAR.konyv
INNER JOIN KONYVTAR.konyvszerzo ON konyvszerzo.konyv_azon = konyv.konyv_azon
INNER JOIN KONYVTAR.szerzo ON szerzo.szerzo_azon = konyvszerzo.szerzo_azon
WHERE szerzo.szuletesi_datum > TO_DATE('1980', 'yyyy');

-- Mely könyvtári példányokat nem kölcsönözték még ki?
SELECT * FROM KONYVTAR.konyv
INNER JOIN KONYVTAR.konyvtari_konyv ON konyvtari_konyv.konyv_azon = konyv.konyv_azon
LEFT JOIN KONYVTAR.kolcsonzes ON kolcsonzes.leltari_szam = konyvtari_konyv.leltari_szam
WHERE kolcsonzes.leltari_szam IS NULL;

-- Kik azok a tagok, akik kölcsönöztek legalább egy 8000 Ft feletti árú könyvet?
SELECT vezeteknev, keresztnev, ar FROM KONYVTAR.tag t
INNER JOIN KONYVTAR.kolcsonzes k ON k.tag_azon = t.olvasojegyszam
INNER JOIN KONYVTAR.konyvtari_konyv ON konyvtari_konyv.leltari_szam = k.leltari_szam
INNER JOIN konyv ON konyv.konyv_azon = konyvtari_konyv.konyv_azon
WHERE ar > 8000;

-- Mely könyvek szerepelnek több példányban is a könyvtárban?
SELECT konyv.cim, COUNT(konyv.cim) FROM KONYVTAR.konyv
INNER JOIN KONYVTAR.konyvtari_konyv ON konyvtari_konyv.konyv_azon = konyv.konyv_azon
GROUP BY konyv.cim
HAVING COUNT(konyv.cim) > 1;

-- Kik azok a tagok, akik még nem kölcsönöztek egyetlen könyvet sem?
SELECT vezeteknev, keresztnev FROM KONYVTAR.tag
LEFT JOIN KONYVTAR.kolcsonzes ON kolcsonzes.tag_azon = tag.olvasojegyszam
WHERE kolcsonzes.leltari_szam IS NULL;

-- Növeld meg 1000 Ft-tal azoknak a könyveknek az árát, amelyeknek ára kisebb, mint 4000 Ft
UPDATE KONYVTAR.konyv SET konyv.ar = (konyv.ar + 1000) WHERE konyv.ar < 4000;

-- Töröld azokat a kölcsönzéseket, ahol a visszahozási dátum több mint 1 éve lejárt
DELETE FROM KONYVTAR.kolcsonzes WHERE FLOOR(MONTHS_BETWEEN(sysdate, kolcsonzzes.visszahozasi_datum) / 12) > 1;

-- Csökkentsd azoknak a tagoknak a tagsági díját 500 Ft-tal, akiknek díja meghaladja a 2000 Ft-ot
UPDATE KONYVTAR.tag SET tag.tagdij = (tag.tagdij - 500) WHERE tag.tagdij > 2000; 

-- !!!! Klónozás
CREATE TABLE konyv as (
SELECT *
FROM KONYVTAR.konyv);
-- !!!! Klónozás

-- Majd törlés

DROP TABLE konyv;




