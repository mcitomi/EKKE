-- 2. Segédfüggvény a szoba éjszakánkénti árára

CREATE OR REPLACE FUNCTION getSzobaAr (
    p_szoba_id IN szobak.id%type,
    p_ellatas_tipusa IN foglalasok.ellatas%type
) RETURN INTEGER 
AS
    v_ar INTEGER := 0;
    v_tipus szobak.TIPUS%TYPE;
    v_emelet szobak.emelet%type;
BEGIN 
    select tipus, emelet into v_tipus, v_emelet from szobak where id = p_szoba_id;

    IF v_tipus = 'egyagyas' THEN
        v_ar := 15000;

    ELSIF v_tipus = 'ketagyas' THEN 
        v_ar := 22000;

    ELSIF v_tipus = 'lakosztaly' THEN 
        v_ar := 40000;

    END IF;

    CASE p_ellatas_tipusa 
        WHEN 'R'then
            v_ar := v_ar * 1.10;

        WHEN 'F' THEN 
            v_ar := v_ar * 1.20;

        WHEN 'T' then
            v_ar := v_ar * 1.30;

    END CASE;

    v_ar := v_ar + (1000 * v_emelet);

    IF v_ar > 80000 THEN 
        RAISE_APPLICATION_ERROR(-20001, 'Túl drága');
    END IF;

    return v_ar;
END;
/

BEGIN 
    DBMS_OUTPUT.PUT_LINE(getSzobaAr(3001, 'R'));
END;
/