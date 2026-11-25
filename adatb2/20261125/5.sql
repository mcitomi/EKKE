-- 5. Vendég foglalásainak kimutatása kurzorral

CREATE OR REPLACE PROCEDURE vendegFoglalasai (
    p_vendeg_id IN vendegek.id%type
)
AS 
    CURSOR c_foglalasok IS select sz.szobaszam, sz.tipus, f.ejszakak, f.ellatas, sz.id 
                            from foglalasok f 
                            INNER JOIN szobak sz ON f.szoba_id = sz.id
                            WHERE f.vendeg_id = p_vendeg_id;

    v_szobaszam szobak.szobaszam%type;
    v_tipus szobak.TIPUS%TYPE;
    v_ejszakak foglalasok.EJSZAKAK%TYPE;
    v_osszeg INTEGER := 0;
    v_szoba_id szobak.id%type;
    v_ellatas foglalasok.ellatas%type;
    v_vegosszeg INTEGER := 0;
BEGIN 
    -- szobaszam, tipus, ejszakak

    OPEN c_foglalasok;

    LOOP
        FETCH c_foglalasok INTO v_szobaszam, v_tipus, v_ejszakak, v_ellatas, v_szoba_id;

        EXIT WHEN c_foglalasok%notfound;    -- kilép a loopból ha nincs sor amit vissza ad a select

        v_osszeg := GETSZOBAAR(v_szoba_id, v_ellatas) * v_ejszakak;
        v_vegosszeg := v_vegosszeg + v_osszeg;

        DBMS_OUTPUT.PUT_LINE(v_szobaszam || '. szoba (' || v_tipus || '): ' || v_ejszakak || ' éjszaka, fizetendő: ' || v_osszeg || ' Ft');
    END LOOP;

    -- c_foglalasok%rowcount; -- hány sort adott vissz a selefct a cursorban

    IF c_foglalasok%rowcount > 0 THEN 
        DBMS_OUTPUT.PUT_LINE('Összesen' || c_foglalasok%rowcount || ' db foglalasa van, végösszeg: ' || v_vegosszeg || ' Ft.');
    ELSE
        DBMS_OUTPUT.PUT_LINE('A vendégnek nincs foglalasa');
    END IF;

    CLOSE c_foglalasok;
EXCEPTION
    WHEN OTHERS THEN 
        IF c_foglalasok%isopen THEN 
            CLOSE c_foglalasok;
        END IF;
        DBMS_OUTPUT.PUT_LINE('Valami hiba történt');


END;
/

select sz.szobaszam, sz.tipus, f.ejszakak 
from foglalasok f 
INNER JOIN szobak sz ON f.szoba_id = sz.id
WHERE f.vendeg_id = 1;
