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
    
END;
/

select name, fuel, UZEMANYAGIGENY(id) from space_missions;

SELECT COUNT(mission_id)
    FROM MISSION_CREW
    WHERE MISSION_CREW.MISSION_ID = 5
    GROUP BY mission_id;