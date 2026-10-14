-- 1 param * 12

CREATE OR REPLACE FUNCTION emp_eves_fizetes (
    p_salary IN employees.salary%type
) RETURN employees.salary%type AS 
BEGIN 
    RETURN p_salary * 12;
END;
/

SELECT name, salary, emp_eves_fizetes(salary) FROM employees;