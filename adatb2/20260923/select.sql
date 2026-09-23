SELECT * FROM PEOPLE;

SELECT MAX(age) FROM PEOPLE;

SELECT * FROM PEOPLE WHERE age = (SELECT MAX(age) FROM PEOPLE);

-- jelenítsük meg az összes olyan embert aki idősebb mint 25 és fiatalabb mint 40, életkor szerint növekvő
SELECT * FROM PEOPLE WHERE age BETWEEN 25 AND 40 ORDER BY age ASC;

-- jelenítsük meg nemenként azt hogy hány 30 év feletti ember van
SELECT gender, COUNT(gender) FROM PEOPLE WHERE age > 30 GROUP BY gender;

