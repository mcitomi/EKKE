DECLARE
    v_name VARCHAR2(30) := 'Mark';
BEGIN
    DBMS_OUTPUT.PUT_LINE('Hello, ' || v_name);
END;
/

-- ELJÁRÁS
CREATE OR REPLACE PROCEDURE udvozles (
    -- IN -> bemenő (nem modosithato)
    -- OUT -> kimenő (modosithato)
    -- IN OUT -> mindket irany
    p_nev IN VARCHAR2,
    p_szam OUT NUMBER
) AS 
    v_koszones VARCHAR2 := 'Szia: ';
BEGIN
    -- p_nev := 'valami';   nem lehet modositani, error
    p_szam := 50;   
    DBMS_OUTPUT.PUT_LINE(v_koszones || p_nev);
END;
/

DECLARE 
    v_name VARCHAR2 := 'Mark';
    v_szam NUMBER := 0;
BEGIN 
    UDVOZLES(v_name, v_szam); 
END;
/

