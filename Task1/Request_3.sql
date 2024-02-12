SELECT DEPARTMENT.ID, DEPARTMENT.NAME, SUM(EMPLOYEE.SALARY) AS TotalSalary
FROM DEPARTMENT
JOIN Employee 
ON DEPARTMENT.ID = DEPARTMENT.DEPARTMENT_ID
GROUP BY DEPARTMENT.ID, DEPARTMENT.NAME
ORDER BY TotalSalary DESC
LIMIT 1;