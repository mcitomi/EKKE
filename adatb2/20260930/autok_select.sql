SELECT * FROM AUTOK;

SELECT a.rendszam, m.name as "márka neve", m.country as "ország"
FROM AUTOK a 
INNER JOIN MARKAK m ON a.MARKA_ID = m.ID;

