
--Section 1. DDL (30 pts)

--01. DDL

CREATE DATABASE Zoo

USE Zoo

CREATE TABLE Owners
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)
CREATE TABLE AnimalTypes
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalType] VARCHAR(30) NOT NULL
)
CREATE TABLE Cages
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AnimalTypeId] INT NOT NULL FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)
CREATE TABLE Animals 
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[BirthDate] DATE NOT NULL,
	[OwnerId] INT FOREIGN KEY REFERENCES [Owners]([Id]),
	[AnimalTypeId] INT NOT NULL FOREIGN KEY REFERENCES [AnimalTypes]([Id])
)
CREATE TABLE AnimalsCages
(
	[CageId] INT NOT NULL FOREIGN KEY REFERENCES [Cages]([Id]),
	[AnimalId] INT NOT NULL FOREIGN KEY REFERENCES [Animals]([Id]),
	PRIMARY KEY([CageId], [AnimalId])
)
CREATE TABLE VolunteersDepartments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DepartmentName] VARCHAR(30) NOT NULL,
)
CREATE TABLE Volunteers
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[PhoneNumber] VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	[AnimalId] INT FOREIGN KEY REFERENCES [Animals]([Id]),
	[DepartmentId] INT NOT NULL FOREIGN KEY REFERENCES [VolunteersDepartments]([Id])
)

--02. Insert

INSERT INTO [Volunteers]([Name], [PhoneNumber], [Address], [AnimalId], [DepartmentId])
VALUES
('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', null, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', null, 31, 5)

INSERT INTO [Animals]([Name], [BirthDate], [OwnerId], [AnimalTypeId])
VALUES
('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', null, 1),
('Tuatara', '2021-06-30', 2, 4)

--03. Update

UPDATE [Animals]
SET [OwnerId] = 4
WHERE OwnerId IS NULL

--SELECT *
--FROM Owners
--WHERE [Name] = 'Kaloqn Stoqnov'

--SELECT *
--FROM Animals
--WHERE OwnerId IS NULL

--04. Delete

DELETE FROM [Volunteers]
WHERE [DepartmentId] = 
	(
		SELECT [Id]
		FROM [VolunteersDepartments]
		WHERE [DepartmentName] = 'Education program assistant'
	)

DELETE FROM [VolunteersDepartments]
WHERE [DepartmentName] = 'Education program assistant'

--Section 3. Querying (40 pts)

--05. Volunteers

SELECT 
	[Name],
	[PhoneNumber],
	[Address],
	[AnimalId],
	[DepartmentId]
FROM [Volunteers]
ORDER BY [Name] ASC, [AnimalId] ASC, [DepartmentId] ASC

--06. Animals data

SELECT 
	[a].[Name],
	[at].[AnimalType],
	FORMAT([a].[BirthDate], 'dd.MM.yyyy')
FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at]
ON [a].[AnimalTypeId] = [at].[Id]
ORDER BY a.[Name] ASC, [at].[AnimalType]

--07. Owners and Their Animals

SELECT TOP(5)
	[o].[Name] AS [Owner],
	COUNT(a.OwnerId) AS [CountOfAnimals]
FROM Animals AS a
JOIN Owners AS o
ON o.Id = a.OwnerId
GROUP BY a.OwnerId, [o].[Name]
ORDER BY COUNT(a.OwnerId) DESC, [o].[Name]

--08. Owners, Animals and Cages

SELECT
	CONCAT([o].[Name], '-', [a].[Name])  AS [OwnersAnimals],
	[o].[PhoneNumber],
	[ac].[CageId]
FROM [Owners] AS [o]
INNER JOIN [Animals] AS [a]
ON o.Id = a.OwnerId
INNER JOIN [AnimalTypes] AS [at]
ON [a].[AnimalTypeId] = [at].[Id]
INNER JOIN [AnimalsCages] AS [ac]
ON [a].Id = [ac].[AnimalId]
WHERE [at].[AnimalType] = 'Mammals'
ORDER BY [o].[Name] ASC, [a].[Name] DESC

--09. Volunteers in Sofia

SELECT
	v.[Name],
	v.[PhoneNumber],
	TRIM(REPLACE(REPLACE([v].[Address], 'Sofia', ''), ',', '')) AS [Address]
FROM [Volunteers] AS [v]
INNER JOIN [VolunteersDepartments] AS [vd]
ON [v].[DepartmentId] = [vd].[Id]
WHERE [DepartmentName] = 'Education program assistant' AND [v].[Address] LIKE '%Sofia%'
ORDER BY [v].[Name] ASC

--10. Animals for Adoption

SELECT
	[a].[Name],
	DATEPART(YEAR, [a].[BirthDate]) AS [BirthYear],
	[at].[AnimalType]
FROM [Animals] AS a
JOIN [AnimalTypes] AS [at]
ON [a].AnimalTypeId = [at].Id
WHERE [a].[OwnerId] IS NULL AND 
	  DATEDIFF(YEAR, [a].[BirthDate], '01/01/2022') < 5 AND 
	  [at].[AnimalType] <> 'Birds'
ORDER BY [a].[Name] ASC

--Section 4. Programmability (20 pts)

--11. All Volunteers in a Department

GO

CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @departID INT = 
		(
			SELECT [Id]
			FROM [VolunteersDepartments]
			WHERE [DepartmentName] = @VolunteersDepartment
		)
	DECLARE @count INT =
		(
			SELECT
				COUNT(*)
			FROM [Volunteers]
			WHERE [DepartmentId] = @departID
		)
	RETURN @count
END

GO
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')
SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

--12. Animals with Owner or Not

GO
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT 
		[a].[Name],
		ISNULL([o].[Name], 'For adoption') AS [OwnersName]
	FROM [Animals] AS a
	LEFT JOIN [Owners] AS o
	ON [a].[OwnerId] = [o].Id
	WHERE [a].[Name] = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'