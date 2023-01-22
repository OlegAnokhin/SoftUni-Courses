
--01
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [FirstName] LIKE 'Sa%'

--02
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [LastName] LIKE '%ei%'

--03
SELECT [FirstName]
FROM [Employees]
WHERE [DepartmentID] IN (3,10)
AND YEAR (HireDate) BETWEEN 1995 AND 2005

--04
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE [JobTitle] NOT LIKE '%engineer%'

--05
SELECT [Name]
FROM [Towns]
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY [Name] ASC

--06
SELECT [TownID], [Name]
FROM [Towns]
WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%'OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
ORDER BY [Name] ASC

--07
SELECT *
FROM [Towns]
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name] ASC

--08
GO
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE YEAR(HireDate) > 2000
GO

--09
SELECT [FirstName], [LastName]
FROM [Employees]
WHERE LEN(LastName) = 5

--10
SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000
ORDER BY [Salary] DESC

--11
SELECT *
FROM 
(SELECT [EmployeeID], [FirstName], [LastName], [Salary],
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM [Employees]
WHERE [Salary] BETWEEN 10000 AND 50000)
AS Result
WHERE [Rank] = 2
ORDER BY [Salary] DESC

--12
SELECT [CountryName], [IsoCode]
FROM [Countries]
WHERE [CountryName] LIKE '%a%a%a%'
ORDER BY [IsoCode]

--13
SELECT p.PeakName, r.RiverName,
LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) -1), r.RiverName)) AS Mix
FROM Peaks AS p, Rivers AS r
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix

--14
SELECT TOP(50) [Name], FORMAT ([Start], 'yyyy-MM-dd') AS [Start]
FROM [Games]
WHERE YEAR (Start) BETWEEN 2011 AND 2012
ORDER BY [Start] ASC, [Name] ASC

--15
SELECT [Username], SUBSTRING(Email, CHARINDEX('@', Email) +1, LEN(Email))
AS [Email Provider]
FROM [Users]
ORDER BY [Email Provider], [Username]

--16
SELECT [Username], [IpAddress]
FROM [Users]
WHERE [IpAddress] LIKE '___.1%.%.___'
ORDER BY [Username]

--17
SELECT [Name],
CASE
	WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
	WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
	ELSE 'Evening'
END AS [Part of the Day],
CASE 
	WHEN Duration BETWEEN 0 AND 3 THEN 'Extra Short'
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
	WHEN Duration > 6 THEN 'Long'
	ELSE 'Extra Long'
END AS Duration
FROM [Games]
ORDER BY [Name], [Duration], [Part of the Day]

--18
SELECT ProductName, OrderDate,
	   DATEADD(DAY, 3, OrderDate ) AS [Pay Due],
	   DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders