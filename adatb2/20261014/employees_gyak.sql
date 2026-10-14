CREATE OR REPLACE PROCEDURE employee (
    p_id IN NUMBER  -- in szócska kell bemenő paramnak
) AS    
    v_name VARCHAR2;    -- itt kell deklarálni a vááltozókat
    v_salary NUMBER;
BEGIN 
    SELECT name, salary 
    INTO v_name, v_salary -- lekérdetzéskor a paramétérekbe INTO-val lehet bele tölteni
    FROM employees 
    WHERE id = p_id;

    DBMS_OUTPUT.PUT_LINE(v_name || ' - ' || v_salary || 'Ft.');
END;
/

DECLARE 
    
BEGIN 
    employee(1);
    employee(2);
    employee(3);
END;
/


-- 2. 
-- incrase salary(%) -> minden dolgozónak %  0-100 között emeli a fizetését
CREATE OR REPLACE PROCEDURE emp_inc_salary (
    p_szazalek IN INTEGER
) AS 
    v_extra_szorzo NUMBER;
BEGIN
    IF p_szazalek < 0 OR p_szazalek > 100 THEN
        DBMS_OUTPUT.PUT_LINE('Helytelen százalék');
        RETURN;
    END IF;

    v_extra_szorzo := p_szazalek / 100;

    UPDATE employees SET salary = salary + salary * v_extra_szorzo;

    DBMS_OUTPUT.PUT_LINE('Minden dolgozó fizetése emelkedett ' || p_szazalek || '%-al.');
    COMMIT; 
END;
/

BEGIN
    emp_inc_salary(50); 
    emp_inc_salary(150); 
    emp_inc_salary(-50); 
END;
/


CREATE OR REPLACE FUNCTION emp_salary_category (
    p_id IN employees.id%type
) RETURN VARCHAR2 AS 
    v_salary employees.salary%type;
BEGIN 
    SELECT salary 
    INTO v_salary
    FROM employees
    WHERE id = p_id;

    IF v_salary < 300000 THEN
        RETURN 'Alacsony';

    ELSIF v_salary >= 300000 AND v_salary <= 600000 THEN
        RETURN 'Közepes';

    ELSE
        RETURN 'Magas';
    END IF;

END;
/

BEGIN
    DBMS_OUTPUT.PUT_LINE('Az 1. dolgozó fizetése ' || emp_salary_category(1));
    DBMS_OUTPUT.PUT_LINE('Az 2. dolgozó fizetése ' || emp_salary_category(2));
    DBMS_OUTPUT.PUT_LINE('Az 3. dolgozó fizetése ' || emp_salary_category(3));
    DBMS_OUTPUT.PUT_LINE('Az 4. dolgozó fizetése ' || emp_salary_category(4));
    DBMS_OUTPUT.PUT_LINE('Az 5. dolgozó fizetése ' || emp_salary_category(5));
    
    -- emp_salary_category(3); 
    -- emp_salary_category(5); 
END;
/