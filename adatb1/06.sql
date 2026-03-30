SELECT cim, tema FROM konyvtar.konyv
WHERE konyv.tema = 'krimi';

SELECT cim, ar FROM konyvtar.konyv
WHERE konyv.ar > 3500;

SELECT cim FROM konyvtar.konyv
WHERE konyv.kiado = 'Park Kiadó';

SELECT leltari_szam FROM konyvtar.konyv
INNER JOIN konyvtari_konyv ON konyvtari_konyv.konyv_azon = konyv.konyv_azon
WHERE konyv.ar = 5000;

SELECT keresztnev, vezeteknev, nem FROM konyvtar.tag
WHERE tag.nem = 'n' AND besorolas = 'diák';

SELECT keresztnev, vezeteknev FROM konyvtar.tag
WHERE tag.besorolas = 'nyugdíjas' OR tag.tagdij  < 500;

SELECT cim FROM konyvtar.konyv
WHERE ar > 2000 AND tema <> 'horror';

SELECT leltari_szam FROM konyvtar.konyv
INNER JOIN konyvtari_konyv ON konyvtari_konyv.konyv_azon = konyv.konyv_azon
INNER JOIN kolcsonzes ON kolcsonzes.leltari_szam = konyvtari_konyv.leltari_szam
WHERE visszahozasi_datum IS NULL AND hany_napra > 14;

SELECT cim FROM konyvtar.konyv
WHERE konyv.tema IN ('sci-fi', 'fantasy') AND ar > 3000;

SELECT nev FROM konyvtar.tag
WHERE tag.tandij IN (500, 1000, 1500);

SELECT cim FROM konyvtar.konyv
WHERE konyv.oldalszam BETWEEN 150 AND 250;

SELECT cim FROM konyvtar.konyv
WHERE LOWER(konyv.cim) LIKE '%titok%';

