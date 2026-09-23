-- DDL Data Definition Language (CREATE, ALTER, DROP, TRUNCATE
-- impliucit command hajtódik végre)

-- DML Data Manipulation language (insert, update, delete)

-- QL Query Lang : SELECT

-- Tipusok
-- VARCHAR2(10), dinamikus hosszú szöveg, max 10 hosszúsággal korlátolva
-- CHAR(2) FIX hosszú szöveg
-- NUMBER(10), 10 jegyű egész szám
-- NUMBER(4, 2), 2 jegyű egész szám kettő tizedessel pl 13,32
-- INTEGER -> NUMBER(38)
-- DATE
-- TIMESTAMP

-- Megszorítások
-- Elsődleges kulcs: PRIMARY KEY
-- check
-- default
-- not null
-- foreign key
-- unique

CREATE TABLE people(
    id INT PRIMARY KEY,
    name VARCHAR2(255) NOT NULL,
    age NUMBER(3) NOT NULL CHECK(age BETWEEN 0 AND 115),
    birthdate DATE DEFAULT SYSDATE
)

-- CREATE TABLE people(
--     id INT PRIMARY KEY,
--     name VARCHAR2(255) NOT NULL,
--     age NUMBER(3) NOT NULL CHECK(age BETWEEN 0 AND 115),
--     birthdate DATE DEFAULT SYSDATE,
--     constraint pk_id PRIMARY KEY(id),
--     constraint ck_age CHECK(age > 0 AND age < 115)
-- )

SELECT * FROM people;

-- ALTER TABLE people ADD constraint uq_name 

INSERT INTO PEOPLE(id, name, age) VALUES (1, 'Zoltán', 45);

INSERT INTO PEOPLE VALUES (2, 'Ágnes', 43, TO_DATE('1982-10-31', 'YYYY-MM-DD'));

COMMIT; -- elmentés szerverre, insert és delete után mindig fontos véglegesíteni
ROLLBACK; -- commit előtt vissza állíthatjuk az előző commit állpotra.

UPDATE PEOPLE SET name = 'Kunhalmi Ágnes' WHERE id = 2;
DELETE FROM PEOPLE WHERE age > 50;

ALTER TABLE people ADD GENDER CHAR(1) DEFAULT 'F';
ALTER TABLE people ADD CONSTRAINT ck_gender CHECK(gender IN ('F', 'N'));

UPDATE PEOPLE SET gender = 'N' WHERE name LIKE '%Ágnes%';

DELETE FROM PEOPLE WHERE id = 1;