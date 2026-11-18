UPDATE EMPLOYEES SET SALARY = 5000;

-- minden emp beszúras utan írja ki a beszúrt értékeket
-- Nev, Salary
CREATE OR REPLACE TRIGGER trg_emp_insert_info
AFTER INSERT -- after/before, milyen művelet
ON EMPLOYEES -- melyik táblán
FOR EACH ROW -- sor vagy művelet szintű, most sor szintű minden sort ki írunk
-- DECLARE -- Segédváltozóknak kell a declare
BEGIN 
    -- sor szintű példányok
    -- :NEW új példány
    -- :OLD a régi

    DBMS_OUTPUT.PUT_LINE('Nev: ' || :NEW.name || ', Salary: ' || :NEW.salary || ' Ft.');
END;
/

INSERT INTO EMPLOYEES (id, name, salary)
VALUES (101, 'Mark', 12415);

-- Írj BEFORE UPDATE triggert, amely megakadályozza, hogy egy dolgozó fizetését 50%-nál nagyobb mértékben csökkentsék.
CREATE OR REPLACE TRIGGER trg_emp_salary_defender
BEFORE UPDATE 
ON EMPLOYEES
FOR EACH ROW 
BEGIN 
    -- insert into log
    IF :NEW.salary < :OLD.salary * 0.5 THEN
        DBMS_OUTPUT.PUT_LINE(:NEW.id || ' nem lehet módosítani');
        RAISE_APPLICATION_ERROR(-20150, 'Túl nagy csükkentés lenne');
    END IF;
END;
/

UPDATE EMPLOYEES SET salary = 100 WHERE id < 5;
COMMIT; 

SELECT * FROM EMPLOYEES;


-- Hozz létre egy AFTER DELETE triggert, ami naplózza a törölt dolgozók adatait egy employees_deleted táblába (id, név, törlés ideje).
CREATE TABLE emp_deleted (
    id INTEGER PRIMARY KEY, 
    name VARCHAR2(255) NOT NULL,
    deleted_at TIMESTAMP DEFAULT SYSTIMESTAMP 
);

SELECT * FROM emp_deleted;

CREATE OR REPLACE TRIGGER trg_emp_deleted_log 
AFTER DELETE 
ON EMPLOYEES
FOR EACH ROW 
WHEN (OLD.salary < 5000) -- csak okkor fut le a triigger ha ez, de nem kell : a new és old elé itt mert idk
BEGIN
    IF :OLD.salary < 5000 then
        DBMS_OUTPUT.PUT_LINE('Nem kár érte, amúgy is keves volt a fizetése ' || :OLD.name || '-nak/nek.');
    END IF;

    DBMS_OUTPUT.PUT_LINE(:OLD.id || ' id törlése naplózva');
    
    INSERT INTO emp_deleted (id, name, deleted_At) VALUES (:OLD.id, :OLD.name, SYSTIMESTAMP);
    -- nem kell commit, majd kint a delettel együtt felmegy ez is.
    -- ha a deletet nem commitoljuk fel akkor ez se megy fel, nem kerül be ghost sor
END;
/

DELETE FROM EMPLOYEES WHERE id < 10;

COMMIT;
ROLLBACK;