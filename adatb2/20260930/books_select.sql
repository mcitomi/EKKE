-- https://ekke.szobo.dev/db2/sql_alapok#4-egyszer%C5%B1-lek%C3%A9rdez%C3%A9sek

SELECT * FROM books
INNER JOIN CATEGORIES ON books.CATEGORY_ID = CATEGORIES.ID;

SELECT title, price FROM BOOKS
ORDER BY price DESC, title ASC;

SELECT * FROM BOOKS
WHERE price BETWEEN 4000 AND 6000;

SELECT * FROM BOOKS
WHERE price < 5000 AND stock > 0;

SELECT * FROM BOOKS
WHERE title LIKE 'A%';

SELECT * FROM BOOKS
WHERE PUBLISHED_ON >= TO_DATE('2023-01-01', 'YYYY-MM-DD');

-- https://ekke.szobo.dev/db2/sql_alapok#5-%C3%B6sszes%C3%ADt%C3%A9sek-%C3%A9s-allek%C3%A9rdez%C3%A9sek

SELECT COUNT(id), MAX(price) FROM BOOKS;

SELECT SUM(stock) FROM BOOKS;

SELECT category_id, COUNT(id) FROM BOOKS
GROUP BY category_id
HAVING COUNT(id) >= 2;

SELECT MAX(price) FROM BOOKS;

SELECT title, price FROM BOOKS
WHERE price = (SELECT MAX(price) FROM BOOKS);

-- https://ekke.szobo.dev/db2/sql_alapok#6-t%C3%A1bl%C3%A1k-%C3%B6sszekapcsol%C3%A1sa

SELECT title, author, name FROM books
INNER JOIN CATEGORIES ON books.CATEGORY_ID = CATEGORIES.ID;

SELECT title FROM BOOKS
INNER JOIN CATEGORIES c ON BOOKS.CATEGORY_ID = c.ID
WHERE c.name = 'Informatika';

SELECT c.name, COUNT(b.id) FROM BOOKS b
INNER JOIN CATEGORIES c ON b.CATEGORY_ID = c.ID
GROUP BY c.NAME;
