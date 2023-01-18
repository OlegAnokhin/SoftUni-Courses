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