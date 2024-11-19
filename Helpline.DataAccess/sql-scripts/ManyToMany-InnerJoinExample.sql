USE RvHelpline

SELECT 
    scc.Id,        -- Columns from ServiceCaseCalls
    scc.Caller,                -- Example column from ServiceCaseCalls
    sc.Id,
    sc.ServiceType                 -- Example column from ServiceClasses
FROM 
    ServiceCaseCalls scc
INNER JOIN 
    ServiceCaseCallServiceClasses sccsc 
    ON scc.Id = sccsc.ServiceCaseCallId
INNER JOIN 
    ServiceClasses sc 
    ON sccsc.ServiceClassId = sc.Id
WHERE 
    sc.Id = sccsc.ServiceClassId AND scc.Id = sccsc.ServiceCaseCallId;  -- Add conditions as needed
