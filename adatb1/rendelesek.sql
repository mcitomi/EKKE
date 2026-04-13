SELECT * FROM Felhasznalok;

-- kik laknak veszpremben?
SELECT Felhasznalok.teljes_nev FROM Felhasznalok WHERE Felhasznalok.cim LIKE 'Veszprém%';

-- milyen éttermek milyen kajakat csinalnak?
SELECT Etelek.nev, Ettermek.nev FROM Etelek INNER JOIN Ettermek ON Ettermek.etterem_id = Etelek.etterem_id;

-- aggregációs függvények
SELECT MIN(Etelek.ar), MAX(Etelek.ar), AVG(Etelek.ar), SUM(Etelek.ar), COUNT(Etelek.ar) FROM Etelek;

-- __Ami a group byba van, az kell a selectbe is__ oracle sql-ben

-- számolmjuk meg hogy hany adott tipusu etterme van
SELECT COUNT(Ettermek.nev), Ettermek.tipus FROM Ettermek GROUP BY Ettermek.tipus;

-- megkkora a legdrágább étel ára minden egyes étteremben
SELECT MAX(Etelek.ar), Ettermek.nev, Ettermek.etterem_id FROM Etelek
INNER JOIN Ettermek On Ettermek.etterem_id = Etelek.etterem_id
GROUP BY Ettermek.etterem_id, Ettermek.nev;

-- kategoriankent az atlagos ár

SELECT AVG(Etelek.ar), Etelek.kategoria_id FROM Etelek
INNER JOIN Kategoriak ON Kategoriak.kategoria_id = Etelek.kategoria_id
GROUP BY Etelek.kategoria_id;

-- hány rendeles futott be az egyes statuszok szerint?
SELECT Rendelesek.statusz, COUNT(Rendelesek.statusz) FROM Rendelesek
GROUP BY Rendelesek.statusz;

-- "A HAVING a GROP BY HAVE-je"

-- csak azok a statuszok jelenjenek meg, amikből több mint 2 rendeles van
SELECT Rendelesek.statusz, COUNT(Rendelesek.statusz) FROM Rendelesek
GROUP BY Rendelesek.statusz
HAVING COUNT(Rendelesek.statusz) > 2;

-- étterem tipusok ahol kettőnel tobb etterem van
SELECT Ettermek.tipus, COUNT(*) FROM Ettermek
GROUP BY Ettermek.tipus
HAVING COUNT(*) > 2;

-- vagy 

SELECT Ettermek.tipus, COUNT(*) as "Darab" FROM Ettermek
GROUP BY Ettermek.tipus
HAVING Darab > 2;

-- Kettőezer forintnal dragabb kateqoriak atlagar szerint
SELECT Etelek.kategoria_id, AVG(Etelek.ar) as "Atlagar" FROM Etelek
GROUP BY Etelek.kategoria_id
HAVING Atlagar > 2000;

-- mely userek rendeltek legalabb 2 alkalommal
SELECT Felhasznalok.felhasznalo_id, Felhasznalok.teljes_nev, COUNT(Felhasznalok.felhasznalo_id) FROM Felhasznalok
INNER JOIN Rendelesek ON Rendelesek.felhasznalo_id = Felhasznalok.felhasznalo_id
GROUP BY Felhasznalok.felhasznalo_id
HAVING COUNT(Felhasznalok.felhasznalo_id) > 1;

-- kik azok akik osszesen 10k felett költöttek?
SELECT Felhasznalok.felhasznalo_id, Felhasznalok.teljes_nev, SUM(Rendelesek.osszertek) FROM Felhasznalok 
INNER JOIN Rendelesek ON Rendelesek.felhasznalo_id = Felhasznalok.felhasznalo_id
GROUP BY Felhasznalok.felhasznalo_id
HAVING SUM(Rendelesek.osszertek) > 10000;

-- mely ételekből adtak le 2nél több db rendelest
SELECT Etelek.etel_id, Etelek.nev, COUNT(*) FROM Etelek
INNER JOIN Rendeles_Tetelek ON Rendeles_Tetelek.etel_id = Etelek.etel_id
GROUP BY Etelek.etel_id
HAVING COUNT(*) > 2;

