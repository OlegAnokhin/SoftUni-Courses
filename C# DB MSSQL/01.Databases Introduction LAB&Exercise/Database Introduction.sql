--1
CREATE DATABASE [Minions]
USE [Minions]

--2
CREATE TABLE Minions (
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(100),
	[Age] INT
)

CREATE TABLE Towns(
	[Id] INT PRIMARY KEY,
	[Name] NVARCHAR(100)
)

--3
ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES Towns(Id);

--4
INSERT INTO Towns
VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions
VALUES
(1,'Kevin', 22, 1),
(2,'Bob', 15, 3),
(3,'Steward', null, 2)

-- 5
TRUNCATE TABLE [Minions]
--SELECT * FROM Minions to check data inside

--6
DROP TABLE [Minions]

--7


--8 
CREATE TABLE [Users]( 
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) CHECK(LEN(ProfilePicture) >=900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT
);
INSERT INTO Users
VALUES
('Petar', '1234567', null, '10-20-2022', 0),
('Gosho', 'a1234567', null, '9-20-2022', 1),
('Ivan', 'b1234567', null, '8-20-2022', 0),
('Oleg', 'c1234567', null, '7-20-2022', 1),
('Ivo', 'd1234567', null, '6-20-2022', 0)

--9
ALTER TABLE [Users] DROP CONSTRAINT PK__Users__3214EC07B0000D7E;
ALTER TABLE [Users] ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username);

--10
ALTER TABLE [Users] ADD CONSTRAINT CHK_PasswordMinLen CHECK(LEN(Password) >=5);

--11
ALTER TABLE [Users] ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime];

--12
ALTER TABLE [Users] DROP CONSTRAINT PK_IdUsername
ALTER TABLE [Users] ADD CONSTRAINT PK_Id PRIMARY KEY (Id)
ALTER TABLE [Users] ADD CONSTRAINT UC_Username UNIQUE (Username);
ALTER TABLE [Users] ADD CONSTRAINT CHK_UsernameLen CHECK(LEN(Username) >=3);

--select * from Users

--13

--14

--15
CREATE DATABASE [Hotel]
USE [Hotel]

CREATE TABLE Employees (
	Id INT PRIMARY KEY, 
	FirstName NVARCHAR(100) NOT NULL, 
	LastName NVARCHAR(100) NOT NULL, 
	Title NVARCHAR(50), 
	Notes NVARCHAR(MAX)
)
INSERT INTO Employees (Id, FirstName, LastName)
VALUES
(1, 'Oleg', 'Anokhin'),
(2, 'Oleg', 'Anokh'),
(3, 'Oleg', 'Ann')

CREATE TABLE Customers (
	AccountNumber INT PRIMARY KEY, 
	FirstName NVARCHAR(100) NOT NULL, 
	LastName NVARCHAR(100) NOT NULL, 
	PhoneNumber CHAR(10) NOT NULL, 
	EmergencyName NVARCHAR(100) NOT NULL,
	EmergencyNumber CHAR(10),
	Notes NVARCHAR(MAX)
)
INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName,Notes)
VALUES
(1, 'Oleg', 'Anokhin', '67867868', 'OLEG', '44444', 'nqma'),
(2, 'Oleg', 'Anokh', '67867868', 'OLEG', '44444', 'nqma'),
(3, 'Oleg', 'Ann', '67867868', 'OLEG', '44444', 'nqma')
CREATE TABLE RoomStatus (
	RoomStatus NVARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)
CREATE TABLE RoomTypes (
	RoomType NVARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)
CREATE TABLE BedTypes (
	BedType NVARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)
CREATE TABLE Rooms (
	RoomNumber INT PRIMARY KEY, 
	RoomType NVARCHAR(10) NOT NULL, 
	BedType NVARCHAR(10) NOT NULL, 
	Rate TINYINT NOT NULL, 
	RoomStatus NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)
)
CREATE TABLE Payments (
	Id INT PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	PaymentDate DATETIME2, 
	AccountNumber INT, 
	FirstDateOccupied DATETIME2 NOT NULL,
	LastDateOccupied DATETIME2 NOT NULL,
	TotalDays TINYINT,
	AmountCharged DECIMAL (15,2),
	TaxRate INT,
	TaxAmount DECIMAL (15,2),
	PaymentTotal DECIMAL (15,2),
	Notes NVARCHAR(MAX)
)
CREATE TABLE Occupancies (
	Id INT PRIMARY KEY, 
	EmployeeId INT NOT NULL, 
	DateOccupied DATETIME2 NOT NULL, 
	AccountNumber INT, 
	RoomNumber INT, 
	RateApplied INT, 
	PhoneCharge DECIMAL, 
	Notes NVARCHAR(MAX)
)

-- SELECT Id FROM [Employees]
-- ORDER BY FirstName