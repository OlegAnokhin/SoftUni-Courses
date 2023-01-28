
--01
SELECT 
	COUNT(wd.[Id]) AS Count
FROM [WizzardDeposits] AS wd

--02
SELECT
	MAX(wd.[MagicWandSize]) AS LongestMagicWand
FROM [WizzardDeposits] AS wd

--03
SELECT
	wd.[DepositGroup],
	MAX(wd.[MagicWandSize]) AS LongestMagicWand
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]

--04
SELECT TOP 2 
	DepositGroup 
FROM
(SELECT 
	DepositGroup,
	AVG([MagicWandSize]) AS Average
FROM [WizzardDeposits]
GROUP BY [DepositGroup]) AS d
ORDER BY Average ASC

--05
SELECT
	wd.[DepositGroup],
	SUM(wd.[DepositAmount]) AS TotalSum
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup]

--06
SELECT 
	[DepositGroup],
	SUM([DepositAmount]) AS TotalSum
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]

--07
SELECT * FROM
(SELECT 
	[DepositGroup],
	SUM([DepositAmount]) AS TotalSum
FROM [WizzardDeposits]
WHERE [MagicWandCreator] = 'Ollivander family'
GROUP BY [DepositGroup]) AS a
WHERE [TotalSum] < 150000
ORDER BY [TotalSum] DESC

--08
SELECT
	wd.[DepositGroup],
	wd.[MagicWandCreator],
	MIN(wd.[DepositCharge]) AS MinDepositCharge
FROM [WizzardDeposits] AS wd
GROUP BY wd.[DepositGroup], wd.[MagicWandCreator]
ORDER BY [MagicWandCreator] ASC, [DepositGroup] ASC

--09
--SELECT 
--	[Age],
--	COUNT([Age]) AS WizardCount
--FROM [WizzardDeposits]
--GROUP BY [Age]

----TEST 01
--SELECT COUNT(CASE WHEN ([Age] <= 10) THEN id ELSE null END)                 AS '[0-10]',
--       COUNT(CASE WHEN ([Age] >= 11 AND [Age] <= 20) THEN id ELSE null END) AS '[11-20]',
--       COUNT(CASE WHEN ([Age] >= 21 AND [Age] <= 30) THEN id ELSE null END) AS '[21-30]',
--       COUNT(CASE WHEN ([Age] >= 31 AND [Age] <= 40) THEN id ELSE null END) AS '[31-30]',
--       COUNT(CASE WHEN ([Age] >= 41 AND [Age] <= 50) THEN id ELSE null END) AS '[41-30]',
--       COUNT(CASE WHEN ([Age] >= 51 AND [Age] <= 60) THEN id ELSE null END) AS '[51-30]',
--       COUNT(CASE WHEN ([Age] >= 61) THEN id ELSE null END)                 AS '[61+]'
--FROM [WizzardDeposits]

--TEST 02
SELECT
	[AgeGroup], COUNT(*) AS WizardCount 
FROM
( SELECT [Age],
	   CASE
			WHEN [Age] BETWEEN 0 AND 10 THEN  '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE                              '[61+]'
	   END AS [AgeGroup]
FROM [WizzardDeposits] ) AS wd
GROUP BY [AgeGroup]

--10
SELECT DISTINCT
	SUBSTRING([FirstName], 1,1) AS FirstLetter
FROM [WizzardDeposits]
WHERE [DepositGroup] = 'Troll Chest'
GROUP BY [FirstName]

--11
SELECT 
	[DepositGroup],
	[IsDepositExpired],
	AVG([DepositInterest])
FROM [WizzardDeposits]
WHERE [DepositStartDate] > '01/01/1985'
GROUP BY [DepositGroup], [IsDepositExpired]
ORDER BY [DepositGroup] DESC, [IsDepositExpired] ASC

--12


SELECT * FROM WizzardDeposits

--13
SELECT 
	[DepartmentID],
	SUM(Salary) AS TotalSalary
FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID]

--14
SELECT 
	[DepartmentID],
	MIN(Salary) AS MinimumSalary
FROM [Employees] AS e
WHERE e.[DepartmentID] IN (2, 5, 7) AND e.[HireDate] > 01/01/2000
GROUP BY [DepartmentID]

--15 NOT WORK CORRECT FOR JUDGE
SELECT * 
FROM Employees
WHERE Salary > 30000 AND [ManagerID] <> 42

UPDATE [Employees]
SET [Salary] = [Salary] + 5000
WHERE DepartmentID = 1
--SELECT [Salary] FROM Employees

SELECT
	[DepartmentID],
	AVG(Salary) AS AverageSalary
FROM [Employees]
GROUP BY [DepartmentID]

--16
SELECT 
	[DepartmentID],
	MAX(Salary) AS MaxSalary
FROM [Employees]
GROUP BY [DepartmentID]
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17
SELECT 
	COUNT(Salary) AS Count
FROM [Employees]
WHERE [ManagerID] IS NULL
GROUP BY [ManagerID]
