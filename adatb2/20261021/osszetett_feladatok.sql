-- 1. tábla létrehozás

CREATE TABLE space_missions (
    id INTEGER PRIMARY KEY NOT NULL,
    name VARCHAR2(100) NOT NULL,
    distance NUMBER(10) NOT NULL CHECK(distance > 0),
    fuel NUMBER(12, 2) DEFAULT 0 NOT NULL CHECK(fuel >= 0),
    status VARCHAR2(20) DEFAULT 'PREPARING' NOT NULL CHECK (status IN ('PREPARING', 'LAUNCHED'))
);

CREATE TABLE astronauts (
    id INTEGER PRIMARY KEY NOT NULL,
    name VARCHAR2(100) NOT NULL,
    specialty VARCHAR2(20) NOT NULL CHECK(specialty IN ('PILOT', 'ENGINEER', 'SCIENTIST', 'MEDIC'))
);

CREATE TABLE mission_crew (
    mission_id INTEGER NOT NULL REFERENCES space_missions(id),
    astronaut_id INTEGER NOT NULL REFERENCES astronauts(id),
    CONSTRAINT pk_mission_crew PRIMARY KEY (mission_id, astronaut_id)
);


-- 2. 

CREATE OR REPLACE FUNCTION uzemanyagigeny (
    p_id IN space_missions.id%type
) RETURN NUMBER AS 
    v_distance space_missions.DISTANCE%TYPE;
    v_people_count INTEGER;
    v_fuel_recommended space_missions.FUEL%TYPE := 0;
BEGIN 

    SELECT COUNT(mission_id)
    INTO v_people_count
    FROM MISSION_CREW
    WHERE MISSION_CREW.MISSION_ID = p_id
    GROUP BY mission_id;

    IF v_people_count < 1 then
        RETURN NULL;
    END IF;

    SELECT distance 
    INTO v_distance
    FROM space_missions
    WHERE space_missions.id = p_id;

    v_fuel_recommended := (v_distance * 0.5) + (v_people_count * 100);

    IF v_fuel_recommended > 5000 then
        v_fuel_recommended := v_fuel_recommended * 1.2;

    END IF;

    RETURN ROUND(v_fuel_recommended, 2);

EXCEPTION 
    WHEN NO_DATA_FOUND then
        DBMS_OUTPUT.PUT_LINE('Nincs ilyen küldetés');
        RETURN NULL;

    WHEN OTHERS THEN
        DBMS_OUTPUT.PUT_LINE('Valami hibázott');
        RETURN NULL;

END;
/

select name, fuel, UZEMANYAGIGENY(id) from space_missions;

SELECT COUNT(mission_id)
    FROM MISSION_CREW
    WHERE MISSION_CREW.MISSION_ID = 5
    GROUP BY mission_id;

-- 3.
CREATE OR REPLACE FUNCTION get_next_id 
RETURN space_missions.id%type
AS 
    v_uj_id space_missions.id%type;
BEGIN
    SELECT MAX(id) + 1 INTO v_uj_id FROM space_missions;
    return v_uj_id;
END;
/

CREATE OR REPLACE PROCEDURE create_mission (
    p_name IN space_missions.name%type,
    p_distance IN space_missions.distance%type,
    p_uj_azonosito OUT space_missions.id%type
) AS 
    v_uj_id space_missions.id%type;
BEGIN 
    v_uj_id := get_next_id();

    IF p_distance <= 0 then
        DBMS_OUTPUT.PUT_LINE('Rossz távolság');
        RETURN;
    END IF;

    IF p_name IS NULL then
        DBMS_OUTPUT.PUT_LINE('A név nem lehet üres');
        RETURN;
    END IF;

    INSERT INTO SPACE_MISSIONS (id, name, distance, fuel, status) 
    VALUES (v_uj_id, p_name, p_distance, 0, 'PREPARING');

    COMMIT;

    p_uj_azonosito := v_uj_id;
END;
/

SELECT MAX(id) + 1 FROM space_missions;
SELECT * FROM space_missions;

DECLARE 
    v_eredmeny space_missions.id%type;
BEGIN
    create_mission('qweqrqrqr', 2000, v_eredmeny);
    DBMS_OUTPUT.PUT_LINE(v_eredmeny); 
END;
/

-- 4. 
CREATE OR REPLACE PROCEDURE hozzarendeles (
    p_mission_id mission_crew.mission_id%type,
    p_aastronaut_id mission_crew.astronaut_id%type
) AS
    v_mission_status space_missions.status%type;
    v_letszam INT;
    v_ugyanaz INT;
    v_speciality VARCHAR2;
BEGIN 
    SELECT status INTO v_mission_status FROM SPACE_MISSIONS WHERE id = p_mission_id;

    IF v_mission_status != 'PREPARING' THEN 
        DBMS_OUTPUT.PUT_LINE('Nem jó a küldetés státusza');
        RETURN;
    END IF;

    SELECT COUNT(*) INTO v_letszam FROM MISSION_CREW WHERE MISSION_ID = p_mission_id;
    IF v_letszam >= 6 then
        DBMS_OUTPUT.PUT_LINE('A küldetés megtelt');
        RETURN;
    END IF;

    SELECT speciality INTO v_speciality FROM ASTRONAUTS WHERE id = p_aastronaut_id;

    SELECT COUNT(*) INTO v_ugyanaz from mission_crew mc INNER JOIN astronauts a 
    ON a.ID = mc.ASTRONAUT_ID
    WHERE mc.MISSION_ID = p_mission_id AND a.SPECIALTY = v_speciality;

    IF v_ugyanaz > 0 then
        DBMS_OUTPUT.PUT_LINE('Van már ilyen');
        RETURN;

    END IF;

    INSERT INTO MISSION_CREW (mission_id, astronaut_id)
    VALUES (p_mission_id, p_aastronaut_id);
    COMMIT;
    DBMS_OUTPUT.PUT_LINE('Sikeres hozzárendelés');
EXCEPTION 
    WHEN NO_DATA_FOUND THEN 
        DBMS_OUTPUT.PUT_LINE('Nem volt valamilyen, nem történt hozzárendelés');
END;
/

-- SELECT status FROM SPACE_MISSIONS WHERE id = 5;

-- SELECT * FROM MISSION_CREW WHERE MISSION_ID = 5;

-- SELECT COUNT(*) from mission_crew mc INNER JOIN astronauts a 
-- ON a.ID = mc.ASTRONAUT_ID
-- WHERE mc.MISSION_ID = 5 AND a.SPECIALTY = 'PILOT';

--5. 

CREATE OR REPLACE PROCEDURE elindit(
    p_mission_id IN space_missions.id%type
) AS 
    v_status space_missions.status%type;
    v_letszam INT;
    v_pilotak INT;
    v_fuel space_missions.fuel%type;
    v_fuel_igeny space_missions.fuel%type;
BEGIN 
    SELECT status INTO v_status FROM space_missions WHERE id = p_mission_id;

    IF v_status != 'PREPARING' then
        DBMS_OUTPUT.PUT_LINE('Az egység nem  indítható');
        RETURN;
    END IF;

    SELECT COUNT(*) INTO v_letszam FROM MISSION_CREW WHERE MISSION_ID = p_mission_id;
    IF v_letszam >= 6 OR v_letszam < 2 then
        DBMS_OUTPUT.PUT_LINE('Nem megfelelő létszám');
        RETURN;
    END IF;

    SELECT COUNT(*) INTO v_pilotak from mission_crew mc INNER JOIN astronauts a 
    ON a.ID = mc.ASTRONAUT_ID
    WHERE mc.MISSION_ID = p_mission_id AND a.SPECIALTY = 'PILOT';

    IF v_pilotak = 0 then
        DBMS_OUTPUT.PUT_LINE('Nincs pilóta');
        RETURN;
    END IF;

    SELECT fuel INTO v_fuel FROM SPACE_MISSIONS WHERE id = p_mission_id;
    v_fuel_igeny := UZEMANYAGIGENY(p_mission_id);

    IF v_fuel < v_fuel_igeny THEN 
        DBMS_OUTPUT.PUT_LINE('Túl kevés az üzemanyagn');
        RETURN;
    END IF;

    UPDATE space_missions SET status = 'LAUNCHED' WHERE id = p_mission_id;
    COMMIT;

EXCEPTION 
    WHEN NO_DATA_FOUND THEN 
        DBMS_OUTPUT.PUT_LINE('Nem volt valamilyen, nem történt hozzárendelés');
END;
/

