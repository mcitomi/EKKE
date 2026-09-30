CREATE TABLE autok(
    rendszam VARCHAR(7) PRIMARY KEY,
    ar INT NOT NULL CHECK(ar > 0),
    km INT NOT NULL CHECK(km > 0),
    marka_id INT NOT NULL REFERENCES MARKAK(id)
);
