WITH RECURSIVE ManagerChain AS (
    SELECT ID, CHIEF_ID, 1 AS ChainLength
    FROM EMPLOYEE
    WHERE CHIEF_ID IS NULL

    UNION ALL

    SELECT e.ID, e.CHIEF_ID, mc.ChainLength + 1
    FROM EMPLOYEE e
    JOIN ManagerChain mc 
    ON e.CHIEF_ID = mc.ID
    WHERE mc IS NOT NULL
)

SELECT MAX(ChainLength) AS MaxChainLength
FROM ManagerChain;
