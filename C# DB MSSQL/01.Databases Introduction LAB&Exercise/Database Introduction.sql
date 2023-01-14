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
--DROP TABLE [People]

CREATE TABLE [People]( 
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(15, 2),
	[Weight] DECIMAL(15, 2),
	[Gender] CHAR(1)NOT NULL CHECK (Gender IN ('m', 'f')),
	[Birthdate] DATETIME2 NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO People ([Name], Height, [Weight], Gender, Birthdate, Biography)
VALUES
('Petar', 1.86, 95.55, 'm', '10-20-1985', 'blabla'),
('Gosho', 1.66, 65.55, 'm', '10-20-1986', 'blabla'),
('Ivan', 1.76, 95.55, 'm', '10-20-1945', 'blabla'),
('Oleg', 1.56, 75.55, 'm', '10-20-1955', 'blabla'),
('Ivana', 1.46, 85.55, 'f', '10-20-1915', 'blabla')

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
CREATE DATABASE Movies
USE Movies

CREATE TABLE Directors(
	[Id] INT PRIMARY KEY, 
	[DirectorName] NVARCHAR(100) NOT NULL,  
	[Notes] NVARCHAR(MAX)
)
INSERT INTO Directors 
VALUES
(1, 'Petar', 'blabla'),
(2, 'Gosho', 'blabla'),
(3, 'Ivan', 'blabla'),
(4, 'Oleg', 'blabla'),
(5, 'Ivana', 'blabla')

CREATE TABLE Genres(
	[Id] INT PRIMARY KEY,
	[GenreName] NVARCHAR(100) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
INSERT INTO Genres  
VALUES
(1, 'Action', 'blabla'),
(2, 'Drama', 'blabla'),
(3, 'Comedy', 'blabla'),
(4, 'Animation', 'blabla'),
(5, 'Horror', 'blabla')

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY,
	[CategoryName] NVARCHAR(100) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
INSERT INTO Categories  
VALUES
(1, 'Action', 'again'),
(2, 'Drama', 'again'),
(3, 'Comedy', 'again'),
(4, 'Animation', 'again'),
(5, 'Horror', 'again')

CREATE TABLE Movies(
	[Id] INT PRIMARY KEY,
	[Title] NVARCHAR(100) NOT NULL,
	[DirectorId] INT, 
	[CopyrightYear] DATETIME2, 
	[Length] CHAR(10), 
	[GenreId] INT, 
	[CategoryId] INT, 
	[Rating] TINYINT,
	[Notes] NVARCHAR(MAX)
)
INSERT INTO Movies  
VALUES
(1, 'Action', 1, '11-11-2022', '02:33:12', 1, 1, 5, 'BLA-BLA'),
(2, 'Drama',  2, '10-10-2022', '02:22:12', 2, 2, 5, 'BLA-BLA'),
(3, 'Comedy', 3, '9-9-2022', '02:11:12', 3, 3, 5, 'BLA-BLA'),
(4, 'Animation', 4, '8-8-2022', '02:44:12', 4, 4, 5, 'BLA-BLA'),
(5, 'Horror', 5, '7-7-2022', '02:55:12', 5, 5, 5, 'BLA-BLA')

--14
CREATE DATABASE [CarRental]
USE [CarRental]

CREATE TABLE [Categories] (
	[Id] INT PRIMARY KEY, 
	[CategoryName] NVARCHAR(30) NOT NULL, 
	[DailyRate] TINYINT NOT NULL, 
	[WeeklyRate] TINYINT NOT NULL, 
	[MonthlyRate] TINYINT NOT NULL,
	[WeekendRate] TINYINT NOT NULL
)
INSERT INTO [Categories]
VALUES
(1, 'Sedan', 0, 10, 15, 20),
(2, 'Coupe', 0, 10, 15, 20),
(3, 'Crossover', 0, 10, 15, 20)

CREATE TABLE [Cars] (
	[Id] INT PRIMARY KEY, 
	[PlateNumber] CHAR(10) NOT NULL,
	[Manufacturer] VARCHAR(30) NOT NULL, 
	[Model] VARCHAR(30) NOT NULL,
	[CarYear] CHAR(10) NOT NULL, 
	[CategoryId] TINYINT NOT NULL, 
	[Doors] TINYINT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(30),
	[Available] VARCHAR(10)
)
INSERT INTO [Cars]
VALUES
(1, 'B1111BB', 'BMW', '550 M', '2020', 1, 4, null, 'perfect', 'yes'),
(2, 'B2222BB', 'Porsche', 'Taycan', '2020', 2, 2, null, 'perfect', 'yes'),
(3, 'B3333BB', 'Toyota', '', 'FJ', 3, 4, null, 'perfect', 'yes')

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY, 
	[FirstName] VARCHAR(30) NOT NULL, 
	[LastName] VARCHAR(30) NOT NULL, 
	[Title] VARCHAR(50), 
	[Notes] VARCHAR(MAX)
)
INSERT INTO [Employees]
VALUES
(1, 'Ivan', 'Ivanov', 'Driver', 'nqma'),
(2, 'Georgi', 'Petrov', 'Manager', 'nqma'),
(3, 'Siana', 'Dimitrova', 'Saler', 'nqma')

CREATE TABLE [Customers] (
	[Id] INT PRIMARY KEY, 
	[DriverLicenceNumber] VARCHAR(30) NOT NULL, 
	[FullName] VARCHAR(50) NOT NULL, 
	[Address] VARCHAR(100) NOT NULL, 
	[City] VARCHAR(30) NOT NULL,
	[ZIPCode] INT NOT NULL,
	[Notes] VARCHAR(MAX)
)
INSERT INTO [Customers]
VALUES
(1, '12346789', 'Oleg Anokhin', 'str. bla 11', 'Varna', 9000, 'nqma'),
(2, '987654321', 'Georgi Petrov', 'str. bla 20', 'Sofia', 1000, 'nqma'),
(3, '432156789', 'Petya Mitkova', 'str. bla 50', 'Varna', 9000, 'nqma')

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,
	[CarId] INT NOT NULL,
	[TankLevel] CHAR(10) NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATETIME2 NOT NULL,
	[EndDate]DATETIME2 NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApplied] VARCHAR(30) NOT NULL,
	[TaxRate] TINYINT NOT NULL,
	[OrderStatus] CHAR(10) NOT NULL,
	[Note] VARCHAR(MAX)
)
INSERT INTO [RentalOrders]
VALUES
(1, 3, 1, 1, 'FULL', 1000, 1200, 200, '01-01-2020', '01-10-2020', 10, 'WeeklyRate', 10, 'FREE', 'nqma'),
(2, 3, 2, 2, 'FULL', 10000, 10200, 200, '01-01-2020', '01-10-2020', 10, 'WeeklyRate', 10, 'FREE', 'nqma'),
(3, 3, 3, 3, 'FULL', 15000, 15200, 200, '01-01-2020', '01-10-2020', 10, 'WeeklyRate', 10, 'FREE', 'nqma')


--15
--DROP DATABASE [Hotel]

CREATE DATABASE [Hotel]
USE [Hotel]

CREATE TABLE [Employees] (
	[Id] INT PRIMARY KEY, 
	[FirstName] NVARCHAR(100) NOT NULL, 
	[LastName] NVARCHAR(100) NOT NULL, 
	[Title] NVARCHAR(50), 
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Employees]
VALUES
(1, 'Oleg', 'Anokhin', 'mr', 'nqma'),
(2, 'Oleg', 'Anokh', 'mr', 'nqma'),
(3, 'Oleg', 'Ann', 'mr', 'nqma')

CREATE TABLE [Customers] (
	[AccountNumber] INT PRIMARY KEY, 
	[FirstName] NVARCHAR(100) NOT NULL, 
	[LastName] NVARCHAR(100) NOT NULL, 
	[PhoneNumber] CHAR(10) NOT NULL, 
	[EmergencyName] NVARCHAR(100) NOT NULL,
	[EmergencyNumber] CHAR(10),
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Customers]
VALUES
(1, 'Oleg', 'Anokhin', '67867868', 'OLEG', '44444', 'nqma'),
(2, 'Oleg', 'Anokh', '67867868', 'OLEG', '44444', 'nqma'),
(3, 'Oleg', 'Ann', '67867868', 'OLEG', '44444', 'nqma')

CREATE TABLE [RoomStatus] (
	[RoomStatus] NVARCHAR(10) PRIMARY KEY, 
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [RoomStatus]
VALUES
('free', 'Welcome'),
('repair', 'repair'),
('closed', 'Welcome')

CREATE TABLE [RoomTypes] (
	[RoomType] NVARCHAR(10) PRIMARY KEY, 
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [RoomTypes]
VALUES
('room', '1 bed'),
('stuio', '3 beds'),
('appartment', '5 beds')

CREATE TABLE [BedTypes] (
	[BedType] NVARCHAR(10) PRIMARY KEY, 
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [BedTypes]
VALUES
('single', '1 bed'),
('master', '3 beds'),
('kingsize', '5 beds')

CREATE TABLE [Rooms] (
	[RoomNumber] INT PRIMARY KEY, 
	[RoomType] NVARCHAR(10) NOT NULL, 
	[BedType] NVARCHAR(10) NOT NULL, 
	[Rate] TINYINT NOT NULL, 
	[RoomStatus] NVARCHAR(10) NOT NULL,
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Rooms]
VALUES
(1, 'room', 'single', 5, 'free', 'nqma'),
(2, 'stuio', 'master', 5, 'free', 'nqma'),
(3, 'appartment', 'kingsize', 5, 'free', 'nqma')

CREATE TABLE [Payments] (
	[Id] INT PRIMARY KEY, 
	[EmployeeId] INT NOT NULL, 
	[PaymentDate] DATETIME2, 
	[AccountNumber] INT, 
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] TINYINT,
	[AmountCharged] DECIMAL (15,2),
	[TaxRate] INT,
	[TaxAmount] DECIMAL (15,2),
	[PaymentTotal] DECIMAL (15,2),
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Payments]
VALUES
(1, 1234, '10-10-2022', 4321, '11-11-2022','11-12-2022', 1, 100, 5, 105,105, 'nqma'),
(2, 4321, '09-09-2022', 4321, '11-11-2022','11-12-2022', 1, 100, 5, 105,105, 'nqma'),
(3, 7890, '08-08-2022', 4321, '11-11-2022','11-12-2022', 1, 100, 5, 105,105, 'nqma')

CREATE TABLE [Occupancies] (
	[Id] INT PRIMARY KEY, 
	[EmployeeId] INT NOT NULL, 
	[DateOccupied] DATETIME2 NOT NULL, 
	[AccountNumber] INT, 
	[RoomNumber] INT, 
	[RateApplied] INT, 
	[PhoneCharge] INT, 
	[Notes] NVARCHAR(MAX)
)
INSERT INTO [Occupancies]
VALUES
(1, 1, '10-10-2022', 4321, 1, 5, 088421145, 'nqma'),
(2, 2, '10-10-2022', 4321, 2, 5, 088421165, 'nqma'),
(3, 3, '10-10-2022', 4321, 3, 5, 088421456, 'nqma')

--19

SELECT * FROM [Towns];

SELECT * FROM [Departments];

SELECT * FROM [Employees];

--20

SELECT * FROM [Towns] ORDER BY [Name]

SELECT * FROM [Departments] ORDER BY [Name]

SELECT * FROM [Employees] ORDER BY [Salary]  DESC

--21

SELECT [Name] FROM [Towns] ORDER BY [Name];

SELECT [Name] FROM [Departments] ORDER BY [Name];

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees] ORDER BY [Salary]  DESC;

--22

UPDATE [Employees]

SET [Salary] = [Salary] * 1.1

SELECT [Salary] FROM [Employees]

--23

UPDATE [Payments]

SET [TaxRate] = [TaxRate] * 0.97

SELECT [TaxRate] FROM [Payments]

-- 24

TRUNCATE TABLE [Occupancies]