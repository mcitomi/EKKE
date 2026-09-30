-- 1. MÁRKÁK BETÖLTÉSE (MARKAK)
INSERT INTO markak (id, name, country) VALUES (1, 'Suzuki', 'Japán');
INSERT INTO markak (id, name, country) VALUES (2, 'Opel', 'Németország');
INSERT INTO markak (id, name, country) VALUES (3, 'Volkswagen', 'Németország');
INSERT INTO markak (id, name, country) VALUES (4, 'Ford', 'Egyesült Államok');
INSERT INTO markak (id, name, country) VALUES (5, 'Renault', 'Franciaország');
INSERT INTO markak (id, name, country) VALUES (6, 'Fiat', 'Olaszország');
INSERT INTO markak (id, name, country) VALUES (7, 'Daewoo', 'Dél-Korea');
INSERT INTO markak (id, name, country) VALUES (8, 'Skoda', 'Csehország');
INSERT INTO markak (id, name, country) VALUES (9, 'Seat', 'Spanyolország');
INSERT INTO markak (id, name, country) VALUES (10, 'Peugeot', 'Franciaország');

-- 2. AUTÓK BETÖLTÉSE (AUTOK) - 30 db magyar shitbox
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GCX-102', 180000, 312000, 1); -- Swift 1.0 "A mi autónk"
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HBA-431', 220000, 285000, 1); -- Swift Sedan
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FCD-889', 150000, 340000, 1); -- Swift 1.3
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('JDF-221', 290000, 210000, 1); -- Wagon R+
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('IUA-003', 120000, 195000, 1); -- Alto


INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GFT-554', 210000, 380000, 2); -- Astra F rohadó sárvédővel
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HJK-112', 350000, 290000, 2); -- Astra G
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FKK-901', 130000, 310000, 2); -- Corsa B 1.0 12V
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('IOP-443', 270000, 245000, 2); -- Corsa C
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('EWR-671', 160000, 410000, 2); -- Vectra B

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GZU-882', 320000, 420000, 3); -- Golf 3 1.9 TDI (óra visszatekerve)
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HHH-301', 450000, 390000, 3); -- Golf 4
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FDE-119', 280000, 360000, 3); -- Passat B5 lógó tetőkárpittal
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('JTG-554', 190000, 230000, 3); -- Polo III

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FXA-771', 140000, 260000, 4); -- Escort
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HLM-092', 230000, 205000, 4); -- Focus Mk1
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GBC-334', 110000, 180000, 4); -- Ka (küszöb hiányzik)
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('KLP-881', 310000, 295000, 4); -- Mondeo Mk3

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GTR-902', 170000, 215000, 5); -- Twingo vászontetős
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('JHG-411', 250000, 270000, 5); -- Thalia (hatalmas csomagtartó, nulla esztétika)
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HRE-123', 200000, 230000, 5); -- Megane I

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FDS-661', 135000, 190000, 6); -- Seicento
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HUZ-772', 260000, 220000, 6); -- Punto II (elektromos szervó hiba)

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GCD-001', 95000, 175000, 7);  -- Matiz
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HEW-543', 150000, 240000, 7); -- Lanos

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GXM-442', 200000, 310000, 8); -- Felicia 1.3 MPI
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('JPR-991', 380000, 350000, 8); -- Fabia I 1.4 MPI

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('FGB-223', 180000, 280000, 9); -- Ibiza II
INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('HKL-654', 210000, 265000, 9); -- Cordoba

INSERT INTO autok (rendszam, ar, km, marka_id) VALUES ('GVA-321', 190000, 225000, 10); -- Peugeot 206

COMMIT;