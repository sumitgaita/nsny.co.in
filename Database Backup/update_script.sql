SELECT id, code,LEN(id) AS bcode, CASE 
        WHEN LEN(id) = 1 THEN 'NSWB00' + CAST(id AS VARCHAR(10))
        ELSE 'NSWB0' + CAST(id AS VARCHAR(10))
    END AS dd
--update BranchDetails set code=CASE 
--       WHEN LEN(id) = 1 THEN 'NSWB00' + CAST(id AS VARCHAR(10))
--        ELSE 'NSWB0' + CAST(id AS VARCHAR(10))
--    END
FROM BranchDetails;