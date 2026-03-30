-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Gép: db
-- Létrehozás ideje: 2026. Már 30. 10:37
-- Kiszolgáló verziója: 8.0.45
-- PHP verzió: 8.3.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `konyvtar`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kolcsonzes`
--

CREATE TABLE `kolcsonzes` (
  `tag_azon` varchar(20) NOT NULL,
  `leltari_szam` varchar(20) NOT NULL,
  `kolcsonzes_datuma` date NOT NULL,
  `hany_napra` int DEFAULT NULL,
  `visszahozasi_datum` date DEFAULT NULL,
  `kesedelmi_dij` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `kolcsonzes`
--

INSERT INTO `kolcsonzes` (`tag_azon`, `leltari_szam`, `kolcsonzes_datuma`, `hany_napra`, `visszahozasi_datum`, `kesedelmi_dij`) VALUES
('A100', 'L1', '2025-01-01', 14, NULL, 0),
('A150', 'L2', '2025-02-01', 7, '2025-02-10', 200),
('A200', 'L3', '2025-03-01', 21, NULL, 500),
('A250', 'L4', '2025-01-15', 14, '2025-02-01', 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyv`
--

CREATE TABLE `konyv` (
  `konyv_azon` int NOT NULL,
  `cim` varchar(200) DEFAULT NULL,
  `isbn` varchar(13) DEFAULT NULL,
  `kiado` varchar(200) DEFAULT NULL,
  `kiadas_datuma` date DEFAULT NULL,
  `ar` int DEFAULT NULL,
  `tema` varchar(30) DEFAULT NULL,
  `oldalszam` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `konyv`
--

INSERT INTO `konyv` (`konyv_azon`, `cim`, `isbn`, `kiado`, `kiadas_datuma`, `ar`, `tema`, `oldalszam`) VALUES
(1, 'A titok háza', '1234567890123', 'Park', '2015-05-10', 3500, 'krimi', 320),
(2, 'Az elveszett világ', '2234567890123', 'Európa', '2005-03-12', 2500, 'kaland', 280),
(3, 'Sci-fi univerzum', '3234567890123', 'Móra', '2021-07-01', 4500, 'sci-fi', 500),
(4, 'Fantasy király', NULL, 'Park', '1999-01-01', 1990, 'fantasy', 600),
(5, 'A halál árnyéka', '5234567890123', 'Európa', '2010-10-10', 2990, 'horror', 220),
(6, 'Agatha rejtély', '6234567890123', 'Park', '1985-06-06', 1800, 'krimi', 150),
(7, 'A gyűrű titka', '7234567890123', 'Móra', '2022-02-02', 5200, 'fantasy', 700);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyvszerzo`
--

CREATE TABLE `konyvszerzo` (
  `szerzo_azon` int NOT NULL,
  `konyv_azon` int NOT NULL,
  `honorarium` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `konyvszerzo`
--

INSERT INTO `konyvszerzo` (`szerzo_azon`, `konyv_azon`, `honorarium`) VALUES
(1, 5, 60000),
(2, 6, 40000),
(3, 2, 30000),
(4, 1, 0);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `konyvtari_konyv`
--

CREATE TABLE `konyvtari_konyv` (
  `leltari_szam` varchar(20) NOT NULL,
  `konyv_azon` int DEFAULT NULL,
  `ertek` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `konyvtari_konyv`
--

INSERT INTO `konyvtari_konyv` (`leltari_szam`, `konyv_azon`, `ertek`) VALUES
('L1', 1, 4000.00),
('L2', 2, 2500.00),
('L3', 3, 6000.00),
('L4', 4, 1500.00),
('L5', 5, 5000.00);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szerzo`
--

CREATE TABLE `szerzo` (
  `szerzo_azon` int NOT NULL,
  `vezeteknev` varchar(30) DEFAULT NULL,
  `keresztnev` varchar(20) DEFAULT NULL,
  `szuletesi_datum` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `szerzo`
--

INSERT INTO `szerzo` (`szerzo_azon`, `vezeteknev`, `keresztnev`, `szuletesi_datum`) VALUES
(1, 'King', 'Stephen', '1947-09-21'),
(2, 'Christie', 'Agatha', '1890-09-15'),
(3, 'Verne', 'Jules', '1828-02-08'),
(4, 'Kovacs', 'Anna', '1980-01-01');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `tag`
--

CREATE TABLE `tag` (
  `olvasojegyszam` varchar(20) NOT NULL,
  `vezeteknev` varchar(30) DEFAULT NULL,
  `keresztnev` varchar(20) DEFAULT NULL,
  `szuletesi_datum` date DEFAULT NULL,
  `nem` char(1) DEFAULT NULL,
  `cim` varchar(200) DEFAULT NULL,
  `beiratkozasi_datum` date DEFAULT NULL,
  `tagdij` int DEFAULT NULL,
  `besorolas` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `tag`
--

INSERT INTO `tag` (`olvasojegyszam`, `vezeteknev`, `keresztnev`, `szuletesi_datum`, `nem`, `cim`, `beiratkozasi_datum`, `tagdij`, `besorolas`) VALUES
('A100', 'Kiss', 'Maria', '2008-01-01', 'N', 'Budapest 1', '2024-01-10', 500, 'diak'),
('A150', 'Nagy', 'Janos', '1980-05-05', 'F', 'Eger 2', '2023-03-15', 1000, 'felnott'),
('A200', 'Szabo', 'Anna', '1950-06-06', 'N', 'Budapest 3', '2024-06-20', 0, 'nyugdijas'),
('A250', 'Kadar', 'Miklos', '2005-07-07', 'F', 'Debrecen', '2025-01-01', 1200, 'diak');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `kolcsonzes`
--
ALTER TABLE `kolcsonzes`
  ADD PRIMARY KEY (`tag_azon`,`leltari_szam`,`kolcsonzes_datuma`),
  ADD KEY `leltari_szam` (`leltari_szam`);

--
-- A tábla indexei `konyv`
--
ALTER TABLE `konyv`
  ADD PRIMARY KEY (`konyv_azon`);

--
-- A tábla indexei `konyvszerzo`
--
ALTER TABLE `konyvszerzo`
  ADD PRIMARY KEY (`szerzo_azon`,`konyv_azon`),
  ADD KEY `konyv_azon` (`konyv_azon`);

--
-- A tábla indexei `konyvtari_konyv`
--
ALTER TABLE `konyvtari_konyv`
  ADD PRIMARY KEY (`leltari_szam`),
  ADD KEY `konyv_azon` (`konyv_azon`);

--
-- A tábla indexei `szerzo`
--
ALTER TABLE `szerzo`
  ADD PRIMARY KEY (`szerzo_azon`);

--
-- A tábla indexei `tag`
--
ALTER TABLE `tag`
  ADD PRIMARY KEY (`olvasojegyszam`);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `kolcsonzes`
--
ALTER TABLE `kolcsonzes`
  ADD CONSTRAINT `kolcsonzes_ibfk_1` FOREIGN KEY (`tag_azon`) REFERENCES `tag` (`olvasojegyszam`),
  ADD CONSTRAINT `kolcsonzes_ibfk_2` FOREIGN KEY (`leltari_szam`) REFERENCES `konyvtari_konyv` (`leltari_szam`);

--
-- Megkötések a táblához `konyvszerzo`
--
ALTER TABLE `konyvszerzo`
  ADD CONSTRAINT `konyvszerzo_ibfk_1` FOREIGN KEY (`szerzo_azon`) REFERENCES `szerzo` (`szerzo_azon`),
  ADD CONSTRAINT `konyvszerzo_ibfk_2` FOREIGN KEY (`konyv_azon`) REFERENCES `konyv` (`konyv_azon`);

--
-- Megkötések a táblához `konyvtari_konyv`
--
ALTER TABLE `konyvtari_konyv`
  ADD CONSTRAINT `konyvtari_konyv_ibfk_1` FOREIGN KEY (`konyv_azon`) REFERENCES `konyv` (`konyv_azon`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
