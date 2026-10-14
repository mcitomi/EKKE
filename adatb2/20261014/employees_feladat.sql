SELECT MAX(salary) FROM employees GROUP BY name;

SELECT name, salary * 12 FROM employees WHERE SALARY = (SELECT MAX(salary) FROM EMLOYEES);

DECLARE 
    v_name employees.name%type;
    v_eves_fizetes employees.salary%type;

BEGIN
    SELECT name, salary 
    INTO v_name, v_eves_fizetes
    FROM employees 
    WHERE SALARY = (SELECT MAX(salary) FROM employees);

    v_eves_fizetes := v_eves_fizetes * 12;

    DBMS_OUTPUT.PUT_LINE(v_name || ': ' || v_eves_fizetes);
END;