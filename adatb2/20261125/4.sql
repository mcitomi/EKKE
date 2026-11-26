-- 4. Extra: Lemondáskorlátozó trigger (plusz pontért)

CREATE OR REPLACE TRIGGER trg_foglalas_lemondas 
BEFORE DELETE
ON foglalasok
FOR EACH ROW 
-- DECLARE
    
BEGIN 
    IF :OLD.erkezes < systimestamp + INTERVAL '1' day THEN 
        RAISE_APPLICATION_ERROR(-20003, 'Már nem törölhető a foglalas');
    END IF;
END;
/

select * from foglalasok;