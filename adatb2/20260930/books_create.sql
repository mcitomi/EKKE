CREATE TABLE books(
    id INT PRIMARY KEY,
    title VARCHAR(250) NOT NULL,
    author VARCHAR(150) NOT NULL,
    price INT NOT NULL CHECK(price > 0),
    published_on DATE DEFAULT CURRENT_DATE,
    category_id INT NOT NULL REFERENCES categories(id)
);

ALTER TABLE books ADD stock INT DEFAULT 0 NOT NULL; -- nem kell kiírni hogy ADD COLUMN , és a NOT NULL a végére menjen.
