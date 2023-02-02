
--01
CREATE PROCEDURE [dbo].[usp_GetEmployeesSalaryAbove35000]
AS
SELECT 
	[FirstName], 
	[LastName]
FROM Employees
WHERE [Salary] > 35000

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

--02
CREATE PROCEDURE [dbo].[usp_GetEmployeesSalaryAboveNumber]
(@number DECIMAL(18,4))
AS
SELECT 
	[FirstName], 
	[LastName]
FROM Employees
WHERE [Salary] >= @number

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber] 48100

--03
CREATE PROCEDURE [dbo].[usp_GetTownsStartingWith]
(@string VARCHAR(10))
AS
SELECT 
	[Name]
FROM Towns
WHERE LEFT([Name], LEN(@string)) = @string

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

--04
CREATE PROCEDURE [dbo].[usp_GetEmployeesFromTown]
(@TownName VARCHAR(50))
AS
SELECT 
	[FirstName], 
	[LastName]
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON t.TownID = a.TownID
WHERE t.Name = @TownName

EXEC [dbo].[usp_GetEmployeesFromTown] 'Sofia'

--05
CREATE OR ALTER FUNCTION [ufn_GetSalaryLevel](@salary DECIMAL(18,4))
RETURNS VARCHAR(10)
AS
BEGIN
DECLARE @salaryLevel VARCHAR(10)
	IF (@salary < 30000)
		SET @salaryLevel = 'Low'
	ELSE IF (@salary <= 50000)
		SET @salaryLevel = 'Average'
	ELSE
		SET @salaryLevel = 'High'
RETURN @salaryLevel
END;

SELECT
	[Salary],
	[dbo].[ufn_GetSalaryLevel]([Salary]) AS [Salary Level]
FROM [Employees]

--06
CREATE PROCEDURE [dbo].[usp_EmployeesBySalaryLevel]
(@string VARCHAR(10))
AS
SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
WHERE [dbo].[ufn_GetSalaryLevel]([Salary]) = @string

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'

--07
CREATE FUNCTION [ufn_IsWordComprised]
(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
DECLARE @index INT = 1
WHILE @index <= LEN(@word)
BEGIN
	IF (CHARINDEX(SUBSTRING(@word, @index, 1), @setOfLetters)) = 0
	RETURN 0
	SET @index += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')

--08 BONUS
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment @departmentId INT
AS
BEGIN
	DECLARE @emploeesToDelete TABLE ([Id] INT)
	INSERT INTO @emploeesToDelete
		SELECT [EmployeeID]
		FROM [Employees]
		WHERE [DepartmentID] = @departmentId

	DELETE
	FROM [EmployeesProjects]
	WHERE [EmployeeID] IN (SELECT * FROM @emploeesToDelete)

	ALTER TABLE [Departments]
	ALTER COLUMN [ManagerID] INT

	UPDATE [Departments]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @emploeesToDelete)

	UPDATE [Employees]
	SET [ManagerID] = NULL
	WHERE [ManagerID] IN (SELECT * FROM @emploeesToDelete)

	DELETE
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId

	DELETE
	FROM [Departments]
	WHERE [DepartmentID] = @departmentId

	SELECT COUNT (*)
	FROM [Employees]
	WHERE [DepartmentID] = @departmentId
END

EXEC [dbo].[usp_DeleteEmployeesFromDepartment] 7
 
SELECT *
 FROM [Employees]
 WHERE [DepartmentID] = 7

--09
CREATE PROCEDURE [dbo].[usp_GetHoldersFullName]
AS 
SELECT 
CONCAT([FirstName], ' ', [LastName]) AS [Full Name]
FROM [AccountHolders]

EXEC dbo.usp_GetHoldersFullName

--10
CREATE PROCEDURE [dbo].[usp_GetHoldersWithBalanceHigherThan]
(@number DECIMAL(18,4))
AS
SELECT 
	[FirstName],
	[LastName]
FROM [AccountHolders] AS ah
JOIN [Accounts] AS a
ON ah.Id = a.AccountHolderId
GROUP BY [FirstName], [LastName]
HAVING SUM(Balance) > @number
ORDER BY FirstName, LastName

EXEC [dbo].[usp_GetHoldersWithBalanceHigherThan] 30000

--11
CREATE FUNCTION ufn_CalculateFutureValue
(@sum DECIMAL(18, 4), @earlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @FutureValue DECIMAL(18, 4)
	SET @FutureValue = @sum * POWER((1 + @earlyInterestRate), @numberOfYears)
RETURN @FutureValue
END

SELECT dbo.ufn_CalculateFutureValue (1000, 0.1, 5)

--12
CREATE PROCEDURE [dbo].[usp_CalculateFutureValueForAccount]
(@accountId INT , @rate FLOAT)
AS
SELECT 
	[a].[Id] AS [Account Id],
	[ah].[FirstName] AS [First Name],
	[ah].[LastName] AS [Last Name],
	[a].[Balance] AS [Current Balance],
	(SELECT dbo.ufn_CalculateFutureValue ([a].[Balance], @rate, 5)) AS [Balance in 5 years]
FROM [Accounts] AS [a]
JOIN [AccountHolders] AS [ah]
ON [ah].[Id] = [a].[AccountHolderId]
WHERE [a].[Id] = @accountId

EXEC [dbo].[usp_CalculateFutureValueForAccount] 1, 0.1

SELECT * FROM Accounts
SELECT * FROM AccountHolders

--13 BONUS
CREATE FUNCTION ufn_CashInUsersGames
(@gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN
	(
	SELECT SUM ([Cash])
	AS [SumCash]
	FROM 
	(
		SELECT 
		[g].[Name],
		[ug].[Cash],
		ROW_NUMBER() OVER (ORDER BY [ug].[Cash] DESC)
		AS [RowNumber]
		FROM [UsersGames] AS [ug]
		JOIN [Games] AS [g]
		ON [ug].[GameId] = [g].[Id]
		WHERE [g].[Name] = @gameName
	)
	AS [RankingSubQuery]
	WHERE [RowNumber] % 2 <> 0
	)

SELECT * FROM [dbo].[ufn_CashInUsersGames]('Love in a mist')