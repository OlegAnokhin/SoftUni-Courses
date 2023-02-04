
--01
CREATE TABLE Logs (
 [LogId] INT PRIMARY KEY IDENTITY,
 [AccountId] INT,
 [OldSum] DECIMAL (18, 2),
 [NewSum] DECIMAL (18, 2)
)
--DROP TABLE Logs
SELECT * FROM [Logs]

GO
CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON [Accounts] INSTEAD OF UPDATE
AS
INSERT INTO Logs(AccountId, OldSum, NewSum)
SELECT 
	i.Id,
	i.Balance,
	d.Balance
FROM inserted AS i
JOIN deleted AS d
ON i.Id = d.Id
WHERE i.Balance <> d.Balance

GO

BEGIN TRANSACTION
UPDATE [Accounts]
SET [Balance] = [Balance] - 10
WHERE Id = 1
IF @@ROWCOUNT <> 1 
	BEGIN 
		ROLLBACK
		RETURN
	END
COMMIT

--02

CREATE TABLE NotificationEmails 
(
 [Id] INT PRIMARY KEY IDENTITY,
 [Recipient] INT,
 [Subject] VARCHAR (200),
 [Body] NVARCHAR(200)
 )
 DROP TABLE NotificationEmails 
 GO

 CREATE TRIGGER tr_NewEmailInsert
 ON [Logs] FOR INSERT
 AS
 INSERT INTO [NotificationEmails]
 SELECT
	i.[AccountId],
	CONCAT('Balance change for account:', i.[AccountId]) AS [Subject],
	CONCAT('On', GETDATE(), 'your balance was changed from', i.[OldSum], 'to', i.[NewSum], '.') AS [Body]
FROM inserted AS i

GO

SELECT * FROM [NotificationEmails]

BEGIN TRANSACTION
UPDATE [Logs]
SET [NewSum] = [OldSum] - 10
WHERE [AccountId] = 1
IF @@ROWCOUNT <> 1 
	BEGIN 
		ROLLBACK
		RETURN
	END
COMMIT


--03
GO
CREATE PROCEDURE usp_DepositMoney
(@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE [Accounts]
		SET [Balance] = [Balance] + @MoneyAmount
		WHERE [Id] = @AccountId
		IF @@ROWCOUNT <> 1
		BEGIN
			ROLLBACK
			RETURN
		END
		IF @MoneyAmount < 0
		BEGIN
			ROLLBACK
			RETURN
		END
	COMMIT
END
GO

EXEC usp_DepositMoney 1, 10.0000

--04
GO
CREATE PROCEDURE usp_WithdrawMoney
(@AccountId INT, @MoneyAmount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
		UPDATE [Accounts]
		SET [Balance] = [Balance] - @MoneyAmount
		WHERE [Id] = @AccountId
		IF @@ROWCOUNT <> 1
		BEGIN
			ROLLBACK
			RETURN
		END
		IF @MoneyAmount < 0
		BEGIN
			ROLLBACK
			RETURN
		END
		--IF [Balance] < @MoneyAmount
		--BEGIN
		--	ROLLBACK
		--	RETURN
		--END
	COMMIT
END
GO

EXEC usp_WithdrawMoney 5, 25

--05
GO
CREATE PROCEDURE usp_TransferMoney
(@SenderId INT, @ReceiverId INT, @Amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION
		IF @Amount < 0
		BEGIN
			ROLLBACK
			RETURN
		END
		EXEC usp_WithdrawMoney @SenderId, @Amount
		EXEC usp_DepositMoney @ReceiverId, @Amount
	COMMIT
END
GO

EXEC usp_TransferMoney 5, 1, 5000

--06 TRANSFER NO JUDGE CHECK

--07 BONUS

--08
GO
CREATE PROCEDURE usp_AssignProject
(@emloyeeId INT, @projectID INT)
AS
BEGIN
	BEGIN TRANSACTION
	DECLARE @ProjectCount INT
	SET @ProjectCount =
		(SELECT COUNT(ep.ProjectID)
		FROM [EmployeesProjects] AS ep
		WHERE ep.EmployeeID = @emloyeeId)
		IF @ProjectCount > 3
		BEGIN
		RAISERROR ('The employee has too many projects!', 16, 1)
			ROLLBACK
			RETURN
		END
	INSERT INTO EmployeesProjects
	VALUES (@emloyeeId, @projectID)
	COMMIT
END
GO

--09

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY IDENTITY, 
	FirstName VARCHAR(50), 
	LastName VARCHAR(50), 
	MiddleName VARCHAR(50), 
	JobTitle VARCHAR(50), 
	DepartmentId INT, 
	Salary MONEY
)

CREATE TRIGGER tr_AddToDeletedEmployees
ON [Employees] FOR DELETE
AS
INSERT INTO [Deleted_Employees]
SELECT 
	FirstName, 
	LastName, 
	MiddleName, 
	JobTitle, 
	DepartmentId, 
	Salary
FROM deleted


-- SELECT

SELECT * FROM [AccountHolders]
SELECT * FROM [Accounts]
WHERE [Id] IN (1, 5)

SELECT * FROM [EmployeesProjects]