-- 3. Naplózó módosító trigger a foglalások táblára

CREATE OR REPLACE trigger trg_foglalas_log 
BEFORE UPDATE
ON foglalasok
FOR EACH ROW
DECLARE 
    v_tipus szobak.TIPUS%TYPE;
    v_szobaszam szobak.SZOBASZAM%TYPE;
BEGIN 
    -- :OLD :NEW

    select tipus, szobaszam into v_tipus, v_szobaszam from szobak WHERE id = :NEW.szoba_id;

    IF v_tipus = 'lakosztaly' AND :NEW.ejszakak > 7 THEN 
        RAISE_APPLICATION_ERROR(-20002, 'Nem megengedett foglalás');
    END IF;

    INSERT INTO foglalas_naplo (foglalas_id, szobaszam, regi_ejszakak, uj_ejszakak ) VALUES (:NEW.id, v_szobaszam, :OLD.ejszakak, :NEW.ejszakak);

END;
/

select * from szobak;
select * from foglalasok;