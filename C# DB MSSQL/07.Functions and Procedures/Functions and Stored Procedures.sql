
--01
CREATE PROCEDURE dbo.usp_GetEmployeesSalaryAbove35000
AS
SELECT 
	[FirstName], 
	[LastName]
FROM Employees
WHERE [Salary] > 35000

EXEC [dbo].[usp_GetEmployeesSalaryAbove35000]

--02
CREATE PROCEDURE dbo.usp_GetEmployeesSalaryAboveNumber
(@number DECIMAL(18,4) = 48100)
AS
SELECT 
	[FirstName], 
	[LastName]
FROM Employees
WHERE [Salary] >= @number

EXEC [dbo].[usp_GetEmployeesSalaryAboveNumber]

--03
CREATE PROCEDURE dbo.usp_GetTownsStartingWith
(@string VARCHAR(10))
AS
SELECT 
	[Name]
FROM Towns
WHERE LEFT([Name], LEN(@string)) = @string

EXEC [dbo].[usp_GetTownsStartingWith] 'b'

--04
CREATE PROCEDURE dbo.usp_GetEmployeesFromTown
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
CREATE OR ALTER FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
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
CREATE PROCEDURE dbo.usp_EmployeesBySalaryLevel
(@string VARCHAR(10))
AS
SELECT 
	[FirstName],
	[LastName]
FROM [Employees]
WHERE (SELECT dbo.ufn_GetSalaryLevel([Salary])) = @string

EXEC [dbo].[usp_EmployeesBySalaryLevel] 'High'

--07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
DECLARE @bool INT = 1
WHILE @bool <= LEN(@word)
BEGIN
	IF (CHARINDEX(SUBSTRING(@word, @bool, 1), @setOfLetters)) = 0
	RETURN 0
	SET @bool += 1
	END
	RETURN 1
END

SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised ('oistmiahf', 'halves')

--08 BONUS

--09
