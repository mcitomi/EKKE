CREATE OR REPLACE PROCEDURE emp_insert (
    p_id IN EMPLOYEES.id%type,
    p_name IN EMPLOYEES.name%type,
    p_salary IN EMPLOYEES.salary%type
) AS
    v_salary EMPLOYEES.salary%type;
BEGIN
    v_salary := p_salary;

    IF v_salary < 400000 then
        v_salary := v_salary * 1.1;
    END IF;

    INSERT INTO EMPLOYEES (id, name, salary)
    VALUES (p_id, p_name, v_salary);

    COMMIT;
END;
/

CREATE OR REPLACE PROCEDURE emp_insert_row (
    p_employee IN OUT EMPLOYEES%rowtype
    
) AS
    v_salary EMPLOYEES.salary%type;
BEGIN
    v_salary := 1234;

    IF p_employee.salary < 400000 then
        p_employee.salary := p_employee.salary * 1.1;
    END IF;

    -- INSERT INTO EMPLOYEES (id, name, salary)
    -- VALUES (p_employee.id, p_employee.name, p_employee.salary);

    INSERT INTO EMPLOYEES VALUES p_employee;

    COMMIT;
END;
/

DECLARE 
    v_emp_row1 EMPLOYEES%rowtype;

    -- AUTHID DEFINER (default) -- -> a függvény létrehozojának jogaival fut
    -- AUTHID CURRENT_USER -- -> A meghívó jogaival fut

BEGIN
    -- emp_insert(11, 'Mate', 560000);

    v_emp_row1.id := 27;
    v_emp_row1.name := 'Ágnes';
    v_emp_row1.salary := 150000;
    DBMS_OUTPUT.PUT_LINE('Fizetes:' || v_emp_row1.salary);
    emp_insert_row(v_emp_row1);
    DBMS_OUTPUT.PUT_LINE('Fizetes emelt:' || v_emp_row1.salary);

    
END;
/
