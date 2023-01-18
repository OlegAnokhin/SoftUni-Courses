CREATE DATABASE [TableRelations]
USE [TableRelations]

--1
CREATE TABLE [Passports](
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(10)
)
INSERT INTO [Passports]
VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

CREATE TABLE [Persons] (
	PersonID INT PRIMARY KEY,
	FirstName VARCHAR(30) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT UNIQUE,
	CONSTRAINT FK_Persons_Passports FOREIGN KEY
	(PassportID) REFERENCES [Passports](PassportID)
)
INSERT INTO [Persons]
VALUES
(1, 'Roberto', 43300.00, 102),
(2, 'Tom', 56100.00, 103),
(3, 'Yana', 60200.00, 101)

--2
CREATE TABLE [Manufacturers](
	[ManufacturerID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	[EstablishedOn] DATETIME2 NOT NULL
)
INSERT INTO [Manufacturers]
VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

CREATE TABLE [Models](
	[ModelID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	[ManufacturerID] INT,
	CONSTRAINT FK_Models_Manufacturers 
	FOREIGN KEY	(ManufacturerID) 
	REFERENCES [Manufacturers](ManufacturerID)
)
INSERT INTO [Models]
VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)

--3
CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)
INSERT INTO [Students]
VALUES
(1, 'Mila'),
(2, 'Tony'),
(3, 'Ron')

CREATE TABLE [Exams](
	[ExamID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)
INSERT INTO [Exams]
VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

CREATE TABLE [StudentsExams](
	[StudentID] INT,
	[ExamID] INT,
	CONSTRAINT PK_StudentsExams	PRIMARY KEY(StudentID, ExamID),
	CONSTRAINT FK_StudentsExams_Students FOREIGN KEY (StudentID) REFERENCES [Students](StudentID),
	CONSTRAINT FK_StudentsExams_Exams FOREIGN KEY (ExamID) REFERENCES [Exams](ExamID)
)
INSERT INTO [StudentsExams]
VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

--4
CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	[ManagerID] INT REFERENCES [Teachers](TeacherID)
)
INSERT INTO [Teachers]
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

--5
GO
CREATE DATABASE [OnlineStore]
GO
USE [OnlineStore]

CREATE TABLE [Cities](
	[CityID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)
CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	[Birthday] DATETIME2,
	[CityID] INT REFERENCES [Cities](CityID)
)
CREATE TABLE [Orders](
	[OrderID] INT PRIMARY KEY,
	[CustomerID] INT REFERENCES [Customers](CustomerID)
)
CREATE TABLE [ItemTypes](
	[ItemTypeID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)
CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	[ItemTypeID] INT REFERENCES [ItemTypes](ItemTypeID)
)
CREATE TABLE [OrderItems](
	[OrderID] INT REFERENCES [Orders](OrderID),
	[ItemID] INT REFERENCES [Items](ItemID),
	PRIMARY KEY (OrderID, ItemID)
)

--6
GO
CREATE DATABASE [University]
GO
USE [University]

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY,
	[SubjectName] VARCHAR(30) NOT NULL
)
CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL
)
CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY,
	[StudentNumber] INT NOT NULL,
	[StudentName] VARCHAR(30) NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors](MajorID)
)
CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects](SubjectID),
	PRIMARY KEY (StudentID, SubjectID)
)
CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATETIME2 NOT NULL,
	[PaymentAmount] DECIMAL(15,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students](StudentID)
)
