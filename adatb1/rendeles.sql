create schema rendeles;
use rendeles;

CREATE TABLE Ettermek (
    etterem_id INT PRIMARY KEY,
    nev VARCHAR(100),
    cim VARCHAR(200),
    telefonszam VARCHAR(20),
    tipus VARCHAR(50)
);

CREATE TABLE Kategoriak (
    kategoria_id INT PRIMARY KEY,
    nev VARCHAR(50)
);

CREATE TABLE Etelek (
    etel_id INT PRIMARY KEY,
    etterem_id INT,
    kategoria_id INT,
    nev VARCHAR(100),
    ar INT,
    FOREIGN KEY (etterem_id) REFERENCES Ettermek(etterem_id),
    FOREIGN KEY (kategoria_id) REFERENCES Kategoriak(kategoria_id)
);

CREATE TABLE Felhasznalok (
    felhasznalo_id INT PRIMARY KEY,
    teljes_nev VARCHAR(100),
    email VARCHAR(100),
    cim VARCHAR(200),
    regisztracio_datuma DATE
);

CREATE TABLE Rendelesek (
    rendeles_id INT PRIMARY KEY,
    felhasznalo_id INT,
    etterem_id INT,
    rendeles_ideje DATETIME,
    osszertek INT,
    statusz VARCHAR(50),
    FOREIGN KEY (felhasznalo_id) REFERENCES Felhasznalok(felhasznalo_id),
    FOREIGN KEY (etterem_id) REFERENCES Ettermek(etterem_id)
);

CREATE TABLE Rendeles_Tetelek (
    tetel_id INT PRIMARY KEY,
    rendeles_id INT,
    etel_id INT,
    mennyiseg INT,
    egyseg_ar INT,
    FOREIGN KEY (rendeles_id) REFERENCES Rendelesek(rendeles_id),
    FOREIGN KEY (etel_id) REFERENCES Etelek(etel_id)
);

INSERT INTO Kategoriak VALUES 
(1, 'Leves'), (2, 'Főétel'), (3, 'Desszert'), (4, 'Pizza'), (5, 'Burger'),
(6, 'Saláta'), (7, 'Tészta'), (8, 'Sushi'), (9, 'Reggeli'), (10, 'Ital'),
(11, 'Kebab'), (12, 'Vegetáriánus'), (13, 'Halétel'), (14, 'Mexikói'), (15, 'Kínai'),
(16, 'Szendvics'), (17, 'Street Food'), (18, 'Magyaros'), (19, 'Indiai'), (20, 'Főzelék');

INSERT INTO Ettermek VALUES 
(1, 'Gulyás Csárda', 'Budapest, Fő utca 1.', '061234567', 'Magyaros'),
(2, 'Pizza Paradicsom', 'Szeged, Tisza Lajos krt. 12.', '0662345678', 'Olasz'),
(3, 'Burger Báró', 'Debrecen, Piac utca 5.', '0652112233', 'Amerikai'),
(4, 'Sushi Világ', 'Győr, Baross út 10.', '0696334455', 'Japán'),
(5, 'Zöld Kert', 'Pécs, Király utca 8.', '0672556677', 'Vegán'),
(6, 'Tészta Mester', 'Eger, Dobó tér 2.', '0636778899', 'Olasz'),
(7, 'Csípős Mexikó', 'Kecskemét, Rákóczi út 4.', '0676990011', 'Mexikói'),
(8, 'Kínai Falatok', 'Miskolc, Széchenyi utca 20.', '0646112233', 'Kínai'),
(9, 'Halász tanya', 'Baja, Duna part 1.', '0679223344', 'Magyaros'),
(10, 'Reggeli Pont', 'Szentendre, Duna korzó 15.', '0626334455', 'Reggeliző'),
(11, 'Doner Király', 'Budapest, Akácfa utca 10.', '0617788990', 'Török'),
(12, 'Pasta Príma', 'Budapest, Bartók Béla út 5.', '0615544332', 'Olasz'),
(13, 'Street Burger', 'Veszprém, vár utca 3.', '0688112233', 'Street Food'),
(14, 'Wok Expressz', 'Sopron, Várkerület 11.', '0699223344', 'Ázsiai'),
(15, 'Főzelék Faló', 'Budapest, Oktogon 2.', '0613322110', 'Magyaros'),
(16, 'Bagel Bázis', 'Székesfehérvár, Fő tér 4.', '0622554433', 'Pékáru'),
(17, 'Indiai Ízek', 'Budapest, Ráday utca 18.', '0619988776', 'Indiai'),
(18, 'Grill Terasz', 'Siófok, Petőfi sétány 2.', '0684112233', 'Grill'),
(19, 'Saláta Box', 'Budapest, Váci út 50.', '0616655443', 'Egészséges'),
(20, 'Édes Élet Cukrászda', 'Keszthely, Kossuth utca 1.', '0683445566', 'Cukrászda');

INSERT INTO Etelek VALUES 
(1, 1, 1, 'Húsleves gazdagon', 1800), (2, 1, 18, 'Marhapörkölt', 3200),
(3, 2, 4, 'Margherita Pizza', 2500), (4, 2, 4, 'Magyaros Pizza', 2900),
(5, 3, 5, 'Sajtos Burger', 2100), (6, 3, 5, 'BBQ Burger', 2400),
(7, 4, 8, 'Maki válogatás', 3500), (8, 4, 8, 'Lazac Nigiri', 1200),
(9, 5, 12, 'Lencsefőzelék', 1600), (10, 5, 6, 'Görög saláta', 1900),
(11, 6, 7, 'Carbonara Spagetti', 2600), (12, 6, 7, 'Bolognai Lasagne', 2800),
(13, 7, 14, 'Csirkés Burrito', 2450), (14, 7, 14, 'Nachos táll', 1800),
(15, 8, 15, 'Szecsuáni csirke', 2300), (16, 8, 15, 'Illatos-omlós kacsa', 3100),
(17, 9, 13, 'Bajai halászlé', 3500), (18, 10, 9, 'Bundás kenyér', 1400),
(19, 20, 3, 'Somlói galuska', 1500), (20, 11, 11, 'Borjú Döner Tál', 2700);

INSERT INTO Felhasznalok VALUES 
(1, 'Kovács János', 'kovacs.janos@email.com', 'Budapest, Kiss utca 10.', '2023-01-10'),
(2, 'Nagy Erzsébet', 'nagy.erzsi@email.com', 'Szeged, Napfény út 5.', '2023-02-15'),
(3, 'Szabó Péter', 'szabo.p@email.com', 'Debrecen, Erdő sor 22.', '2023-03-05'),
(4, 'Tóth Anita', 'toth.anita@email.com', 'Győr, Bridge utca 1.', '2023-04-12'),
(5, 'Kiss László', 'kiss.laci@email.com', 'Pécs, Mecsek köz 7.', '2023-05-20'),
(6, 'Molnár Dóra', 'molnar.d@email.com', 'Budapest, Váci út 100.', '2023-06-01'),
(7, 'Varga Tamás', 'varga.t@email.com', 'Eger, vár utca 12.', '2023-06-15'),
(8, 'Farkas Béla', 'farkas.b@email.com', 'Miskolc, Kohász út 3.', '2023-07-02'),
(9, 'Horváth Júlia', 'horvath.j@email.com', 'Kecskemét, Alföld út 8.', '2023-07-20'),
(10, 'Papp Gábor', 'papp.g@email.com', 'Sopron, Lővér körút 4.', '2023-08-05'),
(11, 'Balogh Zoltán', 'balogh.z@email.com', 'Budapest, Thököly út 15.', '2023-08-25'),
(12, 'Takács Noémi', 'takacs.n@email.com', 'Veszprém, Bakony utca 2.', '2023-09-10'),
(13, 'Lakatos Márió', 'lakatos.m@email.com', 'Budapest, Népszínház utca 45.', '2023-09-15'),
(14, 'Németh Eszter', 'nemeth.e@email.com', 'Székesfehérvár, Alba krt. 3.', '2023-10-01'),
(15, 'Simon Balázs', 'simon.b@email.com', 'Zalaegerszeg, Göcsej út 9.', '2023-10-20'),
(16, 'Kelemen Anna', 'kelemen.a@email.com', 'Budapest, Corvin köz 2.', '2023-11-05'),
(17, 'Fodor Imre', 'fodor.i@email.com', 'Szentendre, Művész út 11.', '2023-11-15'),
(18, 'Antal Krisztina', 'antal.k@email.com', 'Érd, Fő utca 50.', '2023-12-01'),
(19, 'Szőke Márton', 'szoke.m@email.com', 'Budapest, Bécsi út 102.', '2023-12-10'),
(20, 'Gál Sándor', 'gal.s@email.com', 'Kaposvár, Somogyi út 6.', '2024-01-05');

INSERT INTO Rendelesek VALUES 
(1, 1, 1, '2024-02-01 12:30:00', 6800, 'Kiszállítva'),
(2, 2, 2, '2024-02-01 18:45:00', 10400, 'Kiszállítva'),
(3, 3, 3, '2024-02-02 11:20:00', 9000, 'Kiszállítva'),
(4, 4, 4, '2024-02-02 19:10:00', 8300, 'Kiszállítva'),
(5, 5, 5, '2024-02-03 13:00:00', 5400, 'Lemondva'),
(6, 6, 6, '2024-02-03 20:15:00', 8000, 'Kiszállítva'),
(7, 7, 7, '2024-02-04 12:00:00', 10950, 'Kiszállítva'),
(8, 8, 8, '2024-02-04 17:30:00', 5400, 'Folyamatban'),
(9, 9, 9, '2024-02-05 13:10:00', 7000, 'Kiszállítva'),
(10, 10, 10, '2024-02-05 08:30:00', 5600, 'Kiszállítva'),
(11, 11, 1, '2024-02-06 14:20:00', 3600, 'Kiszállítva'),
(12, 12, 11, '2024-02-06 18:50:00', 5400, 'Kiszállítva'),
(13, 13, 20, '2024-02-07 15:00:00', 7500, 'Kiszállítva'),
(14, 14, 3, '2024-02-07 19:00:00', 8400, 'Kiszállítva'),
(15, 15, 6, '2024-02-08 12:45:00', 5600, 'Kiszállítva'),
(16, 16, 2, '2024-02-08 20:30:00', 12500, 'Várakozik'),
(17, 17, 4, '2024-02-09 13:20:00', 7000, 'Kiszállítva'),
(18, 18, 8, '2024-02-09 18:00:00', 6900, 'Kiszállítva'),
(19, 19, 7, '2024-02-10 12:00:00', 9800, 'Kiszállítva'),
(20, 20, 5, '2024-02-10 14:00:00', 3200, 'Kiszállítva');

INSERT INTO Rendeles_Tetelek VALUES 
(1, 1, 1, 2, 1800), (2, 1, 2, 1, 3200),
(3, 2, 3, 3, 2500), (4, 2, 4, 1, 2900),
(5, 3, 5, 2, 2100), (6, 3, 6, 2, 2400),
(7, 4, 7, 2, 3500), (8, 4, 8, 1, 1200),
(9, 5, 10, 2, 1900), (10, 5, 9, 1, 1600),
(11, 6, 11, 1, 2600), (12, 6, 12, 2, 2800),
(13, 7, 13, 3, 2450), (14, 7, 14, 2, 1800),
(15, 8, 15, 1, 2300), (16, 8, 16, 1, 3100),
(17, 9, 17, 2, 3500), (18, 10, 18, 4, 1400),
(19, 13, 19, 5, 1500), (20, 12, 20, 2, 2700);
