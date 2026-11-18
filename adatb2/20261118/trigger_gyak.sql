-- https://ekke.szobo.dev/db2/plsql_05#%C3%B6sszetett-feladatok

CREATE TABLE mission_log (
    id integer generated always as identity primary key,
    mission_id INTEGER NOT NULL,
    message VARCHAR2(200) NOT NULL,
    updated_at DATE DEFAULT SYSDATE NOT NULL
);

CREATE OR REPLACE TRIGGER trg_mission_updated
AFTER UPDATE 
ON space_missions 
FOR EACH ROW
WHEN (OLD.status != NEW.status)
BEGIN 
    DBMS_OUTPUT.PUT_LINE('id: ' || :NEW.id || ', ' || :OLD.status || ' -> ' || :NEW.status);

    INSERT INTO mission_log (mission_id, message, updated_at) VALUES (:NEW.id, :OLD.status || ' -> ' || :NEW.status, SYSDATE);
END;
/


SELECT * FROM space_missions;

UPDATE space_missions SET status = 'LAUNCHED' WHERE id = 16;
UPDATE space_missions SET status = 'PREPARING' WHERE id = 1;
UPDATE space_missions SET status = 'LAUNCHED' WHERE id = 2;

SELECT * FROM mission_log;

-- 2. 

CREATE OR REPLACE TRIGGER trg_mission_check 
BEFORE UPDATE 
ON space_missions
FOR EACH ROW
WHEN (OLD.STATUS = 'LAUNCHED')
BEGIN 

    RAISE_APPLICATION_ERROR(-20151, 'A küldetés már elindult');
END;
/