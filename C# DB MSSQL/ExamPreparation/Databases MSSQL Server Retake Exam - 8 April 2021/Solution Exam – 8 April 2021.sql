
--Section 1. DDL (30 pts)

--01.	Table design

CREATE DATABASE Service

USE Service

CREATE TABLE [Users]
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL UNIQUE,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT CHECK([Age] BETWEEN 14 AND 110),
	Email VARCHAR(50) NOT NULL
)
CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)
CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25),
	[LastName] VARCHAR(25),
	[Birthdate] DATETIME,
	[Age] INT CHECK([Age] BETWEEN 18 AND 110),
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id)
)
CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES Departments(Id)
)
CREATE TABLE [Status]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(20) NOT NULL
)
CREATE TABLE [Reports]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES Categories(Id),
	[StatusId] INT NOT NULL FOREIGN KEY REFERENCES [Status](Id),
	[OpenDate] DATETIME NOT NULL,
	[CloseDate] DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES Users(Id),
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id)
)

--Section 2. DML (10 pts)

--02. Insert
SELECT * FROM Employees

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5)

INSERT INTO Reports
VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

--03. Update

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--04. Delete

DELETE FROM Reports
WHERE StatusId = 4

--Section 3. Querying (40 pts)

--05. Unassigned Reports

SELECT 
	[Description],
	FORMAT(OpenDate, 'dd-MM-yyyy')
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC, [Description] ASC

--06. Reports & Categories

SELECT 
	r.[Description],
	c.[Name]
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId = c.Id
ORDER BY r.[Description] ASC, c.[Name] ASC

--07. Most Reported Category

SELECT TOP 5
	c.[Name] AS CategoryName,
	COUNT(r.Id) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c
ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC, c.[Name] ASC

--08. Birthday Report

SELECT 
	u.Username,
	c.[Name] AS CategoryName
FROM [Users] AS u
JOIN Reports AS r
ON u.Id = r.UserId
JOIN Categories AS c
ON r.CategoryId = c.Id
WHERE DAY(u.Birthdate) = DAY(r.OpenDate)
ORDER BY u.Username ASC, CategoryName ASC

--09. User per Employee

SELECT 
	CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
	COUNT(r.UserId) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports AS r
ON r.EmployeeId = e.Id
LEFT JOIN Users AS u
ON r.UserId = u.Id
GROUP BY r.EmployeeId, e.FirstName, e.LastName
ORDER BY UsersCount DESC, FullName ASC

--10. Full Info

SELECT
	CASE
		WHEN e.Id IS NULL THEN 'None'
		ELSE CONCAT(e.FirstName, ' ', e.LastName)
	END AS Employee,
	COALESCE(d.[Name], 'None') AS Department,
	c.[Name] AS Category,
	r.[Description],
	FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
	s.[Label] AS [Status],
	u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Employees AS e
ON r.EmployeeId = e.Id
LEFT JOIN Departments AS d
ON e.DepartmentId = d.Id
LEFT JOIN Categories AS c
ON c.Id = r.CategoryId
LEFT JOIN Users AS u
ON r.UserId = u.Id
LEFT JOIN Status AS s
ON s.Id = r.StatusId
ORDER BY e.FirstName DESC, e.LastName DESC, d.[Name] ASC, c.[Name] ASC, r.[Description] ASC,
		 r.OpenDate ASC, s.[Label] ASC, u.[Name] ASC


--Section 4. Programmability (20 pts)

--11. Hours to Complete

GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF @StartDate IS NULL OR @EndDate IS NULL
	RETURN 0
	ELSE
	DECLARE @totalHours INT =
		DATEDIFF(HOUR, @StartDate, @EndDate)
	RETURN @totalHours
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports

--12. Assign Employee

GO
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS
BEGIN
	DECLARE @EmployeeDepId INT =
		(
			SELECT 
				DepartmentId
			FROM Employees
			WHERE Id = @EmployeeId
		)
	DECLARE @CategoryDepId INT =
		(
			SELECT
				c.DepartmentId
			FROM Reports AS r
			JOIN Categories AS c
			ON r.CategoryId = c.Id
			WHERE r.Id = @ReportId
		)
	IF @EmployeeDepId = @CategoryDepId
		UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
	ELSE 
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;
END


EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2