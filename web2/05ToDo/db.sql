-- Fajl: database.sql - adatbazis letrehozas es tabla definiciok.
-- Letrehozzuk a php_todo adatbazist UTF-8 tamogatassal.
CREATE DATABASE php_todo CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
-- Kivalasztjuk az eppen hasznalando adatbazist.
USE php_todo;

-- Felhasznalok tablaja: bejelentkezeshez szukseges adatok.
CREATE TABLE users (
    -- Egyedi, automatikusan novekvo azonosito.
    id INT AUTO_INCREMENT PRIMARY KEY,
    -- Felhasznalonev, kotelezo es egyedi.
    username VARCHAR(100) NOT NULL UNIQUE,
    -- Jelszo hash tarolasa, kotelezo mezokent.
    password VARCHAR(255) NOT NULL
);

-- Feladatok tablaja, userhez rendelve.
CREATE TABLE tasks (
    -- Egyedi, automatikusan novekvo task azonosito.
    id INT AUTO_INCREMENT PRIMARY KEY,
    -- A tulajdonos user azonositoja.
    user_id INT NOT NULL,
    -- A feladat szoveges leirasa.
    task VARCHAR(255) NOT NULL,
    -- Kategoria (pl. iskola/otthon/munka).
    category VARCHAR(50) NOT NULL,
    -- Prioritas (alacsony/kozepes/magas).
    priority VARCHAR(20) NOT NULL,
    -- Allapot: 0 = folyamatban, 1 = kesz.
    is_done TINYINT(1) NOT NULL DEFAULT 0,
    -- Letrehozas idopontja automatikusan.
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    -- Kapcsolat a users tablaval (idegen kulcs).
    FOREIGN KEY (user_id) REFERENCES users(id)
);