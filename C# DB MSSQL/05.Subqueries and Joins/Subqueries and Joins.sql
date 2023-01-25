
--1
SELECT TOP 5
	e.EmployeeID,
	e.JobTitle,
	a.AddressID,
	a.AddressText
FROM [Employees] AS e
JOIN [Addresses] AS a
ON e.AddressID = a.AddressID
ORDER BY a.AddressID ASC

--2
SELECT TOP 50
	e.FirstName,
	e.LastName,
	t.[Name],
	a.AddressText
FROM [Employees] AS e
JOIN [Addresses] AS a
ON e.AddressID = a.AddressID
JOIN [Towns] AS t
ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

--3
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.DepartmentID = d.DepartmentID
WHERE d.[Name] = 'Sales'
ORDER BY e.EmployeeID

--4
SELECT TOP 5
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS [DepartmentName]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--5
SELECT TOP 3
	e.EmployeeID,
	e.FirstName
FROM [Employees] AS e
LEFT JOIN [EmployeesProjects] AS ep
ON e.EmployeeID = ep.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY e.EmployeeID

--6
SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name] AS [DeptName]
FROM [Employees] AS e
JOIN [Departments] AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-1-1' AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

--7
SELECT TOP 5
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN [Projects] AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > 2002-08-13 AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--8
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE
	WHEN DATEPART(YEAR, p.StartDate) >= '2005' THEN NULL
	ELSE p.[Name]
	END  AS [ProjectName]
FROM [Employees] AS e
JOIN [EmployeesProjects] AS ep
ON e.EmployeeID = ep.EmployeeID
JOIN [Projects] AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

--9
SELECT 
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS ManagerName
FROM [Employees] AS e
JOIN [Employees] AS m 
ON m.EmployeeID = e.ManagerID
WHERE m.EmployeeID IN (3, 7)
ORDER BY e.EmployeeID

--10
SELECT TOP 50
	e.EmployeeID,
 	CONCAT_WS(' ' , e.FirstName, e.LastName) AS [EmployeeName],
	CONCAT_WS(' ' , m.FirstName, m.LastName) AS [ManagerName],
	d.[Name] AS DepartmentName
FROM [Employees] AS e
JOIN [Employees] AS m 
ON m.EmployeeID = e.ManagerID
JOIN [Departments] AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--11
SELECT 
	MIN(a.AverageSalary) AS MinAverageSalary
FROM (
	SELECT 
	e.DepartmentID,
	AVG(e.Salary) AS AverageSalary
	FROM [Employees] AS e
	GROUP BY e.DepartmentID
	) AS a

--12
SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc
ON c.CountryCode = mc.CountryCode
JOIN [Mountains] AS m
ON mc.MountainId = m.Id
JOIN [Peaks] AS p
ON mc.MountainId = p.MountainId
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13
SELECT 
	c.CountryCode,
	COUNT(mc.CountryCode) AS MountainRange
FROM [Countries] AS c
JOIN [MountainsCountries] AS mc
ON c.CountryCode = mc.CountryCode
WHERE c.CountryCode IN ('BG', 'US', 'RU') 
GROUP BY c.CountryCode

--14
SELECT TOP 5
	c.CountryName,
	r.RiverName
FROM [Countries] AS c
LEFT JOIN [CountriesRivers] AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN [Rivers] AS r
ON cr.RiverId = r.Id
WHERE [ContinentCode] = 'AF'
ORDER BY c.CountryName

--15


--16
SELECT 
	COUNT(c.CountryCode)
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.CountryCode = mc.CountryCode
WHERE [MountainId] IS NULL

--17
SELECT TOP 5
	c.CountryName,
	MAX(p.Elevation) AS HighestPeakElevation,
	MAX(r.[Length]) AS LongestRiverLength
FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN [Peaks] AS p
ON mc.MountainId = p.MountainId
LEFT JOIN [CountriesRivers] AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN [Rivers] AS r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, 
		 LongestRiverLength DESC,
		 c.CountryName

--18

