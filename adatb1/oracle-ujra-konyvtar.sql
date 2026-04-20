-- hány db 70-nél idősebb szerző van?
SELECT * FROM KONYVTAR.szerzo 
WHERE FLOOR(MONTHS_BETWEEN(sysdate, szuletesi_datum) / 12) > 70;

-- témák amihhez 7-nél több könyv tartozik
SELECT tema, COUNT(konyv_azon) FROM KONYVTAR.konyv
GROUP BY konyv.tema
HAVING COUNT(*) > 7;

-- témánként átlagos oldalszám
SELECT tema, FLOOR(AVG(oldalszam)) FROM KONYVTAR.konyv
GROUP BY konyv.tema;

-- születéseé név és hó, amiben 10-nél kevesebb tag született
SELECT TO_CHAR(szuletesi_datum, 'yyyy. MM.'), COUNT(*) FROM KONYVTAR.tag
GROUP BY TO_CHAR(szuletesi_datum, 'yyyy. MM.')
HAVING COUNT(*) < 10;

-- ki a legidősebb tag?
SELECT vezeteknev, keresztnev, TO_CHAR(szuletesi_datum, 'yyyy. MM. dd.') FROM KONYVTAR.tag
WHERE szuletesi_datum = (SELECT min(szuletesi_datum) FROM KONYVTAR.tag);

------ NINCS LIMIT?????
SELECT * FROM KONYVTAR.tag
ORDER BY szuletesi_datum ASC;
-----

-- legfiatalabb női tag
SELECT vezeteknev, keresztnev, TO_CHAR(szuletesi_datum, 'yyyy. MM. dd.') FROM KONYVTAR.tag
WHERE szuletesi_datum = (SELECT max(szuletesi_datum) FROM KONYVTAR.tag WHERE nem = 'n');

-- legidősebb diak besorolasu tag
SELECT vezeteknev, keresztnev, TO_CHAR(szuletesi_datum, 'yyyy. MM. dd.') FROM KONYVTAR.tag
WHERE szuletesi_datum = (SELECT min(szuletesi_datum) FROM KONYVTAR.tag WHERE besorolas = 'diák') AND besorolas = 'diák'; -- dupla ellenőrzés 

-- atlag árnál alacsonyabb árú könyvek
SELECT * FROM KONYVTAR.konyv
WHERE konyv.ar < (SELECT AVG(ar) FROM KONYVTAR.konyv);

-- melyek azok a szerzok akik nem szereztek konyvet?
SELECT * FROM KONYVTAR.szerzo 
WHERE szerzo_azon NOT IN (SELECT szerzo_azon FROM KONYVTAR.konyvszerzo);  -- nincs benne a visszaadott adathalmazban

-- a legdrágább krimi könyv címe
SELECT cim, ar, tema FROM KONYVTAR.konyv
WHERE ar = (SELECT MAX(ar) FROM KONYVTAR.konyv WHERE tema = 'krimi') AND tema = 'krimi'; -- elvileg kell de szerintem nem ahah

-- kik írtak 3-nál több könyv
SELECT vezeteknev, keresztnev FROM KONYVTAR.szerzo
WHERE szerzo_azon IN (
    SELECT szerzo_azon FROM KONYVTAR.konyvszerzo
    GROUP BY szerzo_azon
    HAVING COUNT(konyv_azon) > 3
);

-- kik kaptak horror, sci-fi, és krimi témáju konyvert összehonoráriumot
SELECT vezeteknev, keresztnev FROM KONYVTAR.konyvszerzo
INNER JOIN KONYVTAR.konyv ON konyv.konyv_azon = konyvszerzo.konyv_azon
INNER JOIN KONYVTAR.szerzo ON szerzo.szerzo_azon = konyvszerzo.szerzo_azon
WHERE tema IN ('horror', 'sci-fi', 'krimi') AND konyvszerzo.honorarium IS NOT NULL
GROUP BY vezeteknev, keresztnev;

-- honorariumok osszege
SELECT tema, SUM(honorarium)
FROM KONYVTAR.konyv 
INNER JOIN KONYVTAR.konyvszerzo ON konyvszerzo.konyv_azon = konyv.konyv_azon
WHERE tema IN ('horror', 'sci-fi', 'krimi')
GROUP BY tema;

-- melyik az a konyv amelyet nem sci-fi krimi és horror temaju es tobb mint 3 peldany tartozik ohzza
SELECT cim, COUNT(leltari_szam) FROM KONYVTAR.konyv
INNER JOIN KONYVTAR.konyvtari_konyv ON konyvtari_konyv.konyv_azon = konyv.konyv_azon
WHERE tema NOT IN ('horror', 'sci-fi', 'krimi')
GROUP BY konyv.konyv_azon, cim
HAVING COUNT(leltari_szam) > 3;

-- temankent hany darab 2000-3000 ft kozotti konyv van
SELECT tema, COUNT(konyv_azon)
FROM KONYVTAR.konyv
WHERE ar BETWEEN 2000 AND 3000
GROUP BY tema;


