
--2
SELECT * FROM [Departments]

--3
SELECT [Name] FROM [Departments]

--4
SELECT [FirstName], [LastName], [Salary] FROM [Employees]

--5
SELECT [FirstName], [MiddleName], [LastName] FROM [Employees]

--6
SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address] FROM [Employees]

--7
SELECT DISTINCT [Salary] FROM [Employees]

--8
SELECT * FROM [Employees] WHERE [JobTitle] = 'Sales Representative'

--9
SELECT [FirstName], [LastName], [JobTitle] FROM [Employees] 
WHERE [Salary] >= 20000 AND [Salary] <= 30000

--10
SELECT [FirstName] + ' ' + [MiddleName] + ' ' + [LastName] AS [FullName] FROM [Employees]
WHERE [Salary] = 25000 OR [Salary] = 14000 OR [Salary] = 12500 OR [Salary] = 23600

--11
SELECT [FirstName], [LastName] FROM [Employees] 
WHERE [ManagerID] IS NULL

--12
SELECT [FirstName], [LastName], [Salary] FROM [Employees] 
WHERE [Salary] >= 50000
ORDER BY [Salary] DESC

--13
SELECT TOP(5) [FirstName], [LastName] FROM [Employees] 
ORDER BY [Salary] DESC

--14
SELECT [FirstName], [LastName] FROM [Employees] 
WHERE [DepartmentID] <> 4

--15
SELECT * FROM [Employees]
ORDER BY [Salary] DESC, [FirstName] ASC, [LastName] DESC, [MiddleName] ASC

--16
GO
CREATE VIEW v_EmployeesSalaries AS SELECT  [FirstName], [LastName], [Salary] FROM [Employees]
GO

--17
GO
CREATE VIEW v_EmployeeNameJobTitle AS
SELECT [FirstName] + ' ' + ISNULL([MiddleName], '') + ' ' + [LastName] 
AS [FullName], [JobTitle] 
FROM [Employees]
GO
--SELECT * FROM v_EmployeeNameJobTitle

--18
SELECT DISTINCT [JobTitle] FROM [Employees]

--19
SELECT TOP(10) * FROM [Projects] 
ORDER BY [StartDate] ASC, [Name] ASC

--20
SELECT TOP(7) [FirstName], [LastName], [HireDate] FROM [Employees]
ORDER BY [HireDate] DESC

--21
UPDATE [Employees]
SET [Salary] = [Salary] * 1.12
WHERE DepartmentID IN (1, 2, 4, 11)
SELECT [Salary] FROM Employees

--22 Geography

SELECT [PeakName] FROM [Peaks]
ORDER BY [PeakName] ASC

--23
SELECT TOP(30) [CountryName], [Population] FROM [Countries]
WHERE [ContinentCode] = 'EU'
ORDER BY [Population] DESC, [CountryName] ASC

--24
SELECT [CountryName], [CountryCode],
	CASE 
	WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
	ELSE 'Not Euro'
	END AS [Currency]
FROM [Countries]
ORDER BY [CountryName]

-- 25 Diablo
SELECT [Name] FROM [Characters]
ORDER BY [Name] ASC