select *
from konyvtar.tag;

select vezeteknev, tag.keresztnev, concat(vezeteknev, concat(' ', keresztnev)), vezeteknev || ' ' || keresztnev
from konyvtar.tag;

select cim, oldalszam
from konyvtar.konyv
where konyv.oldalszam > 200;

select *
from konyvtar.tag
where nem = 'n';

SELECT cim, tema
FROM konyvtar.konyv
WHERE konyv.tema = 'krimi' OR konyv.tema = 'horror' OR konyv.tema = 'sci-fi';

SELECT cim, tema
FROM konyvtar.konyv
WHERE konyv.tema IN ('sci-fi', 'horror', 'krimi');

-- diak vagy felnott ferfiak nevét írjuk ki
SELECT vezeteknev || ' ' || keresztnev, besorolas
FROM konyvtar.tag
WHERE nem = 'f' AND besorolas IN ('diák', 'felnőtt');


-- konyvenkrol minden info ami nem töri vagy krimi és kevesebb mint 200 oldal

SELECT *
FROM konyvtar.konyv
WHERE konyv.oldalszam < 200 AND tema NOT IN ('történelem', 'krimi');

-- cím és ár ami 1000 é 3000F között vannak

SELECT cim, ar
FROM konyvtar.konyv
WHERE konyv.ar BETWEEN 1000 AND 3000;

-- ahol nincs kiadó

SELECT *
FROM konyvtar.konyv
WHERE kiado IS NULL;

-- ahol null van ott 'nincs megadva' string legyen

SELECT cim, NVL(kiado, 'nincs megadva')
FROM konyvtar.konyv;

-- A-val kezdodo keresztnevek
 
SELECT *
FROM konyvtar.tag
WHERE tag.keresztnev LIKE 'A%';

-- S-re végződik

SELECT *
FROM konyvtar.tag
WHERE tag.keresztnev LIKE '%s';

-- tartalmaz a teljes neve a betűt

SELECT *
FROM konyvtar.tag
WHERE LOWER(CONCAT(vezeteknev, keresztnev)) LIKE '%a%';

-- NEW tartalmaz a teljes neve a betűt

SELECT *
FROM konyvtar.tag
WHERE UPPER(CONCAT(vezeteknev, keresztnev)) NOT LIKE '%A%';

-- !!! ISBN legalabb 2db 7-est tartalmaz

SELECT *
FROM konyvtar.konyv
WHERE isbn LIKE '%7%7%';

-- tag teljes nevében pontosan 2db A
-- tehat legalabb ketto de harom mar ne
SELECT *
FROM konyvtar.tag
WHERE LOWER(CONCAT(vezeteknev, keresztnev)) LIKE '%a%a%' AND LOWER(CONCAT(vezeteknev, keresztnev)) NOT LIKE '%a%a%a%';

-- teljes nevek ahol a vezetek nev 2. karaktere L

SELECT vezeteknev || ' ' || keresztnev AS "Teljes név"
FROM konyvtar.tag
WHERE LOWER(vezeteknev) LIKE '_l%';

-- utolso elotti karakter keresztnevben N

SELECT vezeteknev || ' ' || keresztnev AS "Teljes név"
FROM konyvtar.tag
WHERE LOWER(keresztnev) LIKE '%n_';

-- akkor kell like mikor vizsgálunk valamit a = jel csak pontosan tudjuk az adatot

-- listazzuk ki a debreceni tagokat

SELECT *
FROM konyvtar.tag
WHERE LOWER(Cim) LIKE '____ debrecen%'; -- iranyitoszam helyét ki maskoljuk (pl debrecen utca ne legyen benne)

-- csak a konyv cimek

SELECT cim, kiado, oldalszam
FROM konyvtar.konyv
WHERE LOWER(cim) LIKE 'a%'
ORDER BY kiado ASC;

SELECT cim, kiado, oldalszam
FROM konyvtar.konyv
WHERE LOWER(cim) LIKE 'a%'
ORDER BY kiado DESC;

SELECT cim, kiado, oldalszam
FROM konyvtar.konyv
WHERE LOWER(cim) LIKE 'a%'
ORDER BY kiado DESC, oldalszam ASC; -- dupla rendezes