
-- PASS:  mssql_exam


--Section 1. DDL (30 pts)

--01.	Table design

CREATE DATABASE Boardgames

USE Boardgames

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Addresses
(
	[Id] INT PRIMARY KEY IDENTITY,
	[StreetName] NVARCHAR(100) NOT NULL,
	[StreetNumber] INT NOT NULL,
	[Town] VARCHAR(30) NOT NULL,
	[Country] VARCHAR(50) NOT NULL,
	[ZIP] INT NOT NULL
)
CREATE TABLE Publishers
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL UNIQUE,
	[AddressId] INT NOT NULL FOREIGN KEY REFERENCES [Addresses]([Id]),
	[Website] NVARCHAR(40),
	[Phone] NVARCHAR(20) 
)
CREATE TABLE PlayersRanges
(
	[Id] INT PRIMARY KEY IDENTITY,
	[PlayersMin] INT NOT NULL,
	[PlayersMax] INT NOT NULL 
)
CREATE TABLE Boardgames
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[YearPublished] INT NOT NULL,
	[Rating] DECIMAL(18, 2) NOT NULL,
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories]([Id]),
	[PublisherId] INT NOT NULL FOREIGN KEY REFERENCES [Publishers]([Id]),
	[PlayersRangeId] INT NOT NULL FOREIGN KEY REFERENCES [PlayersRanges]([Id])
)
CREATE TABLE Creators
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(30) NOT NULL,
	[LastName] NVARCHAR(30) NOT NULL,
	[Email] NVARCHAR(30) NOT NULL
)
CREATE TABLE CreatorsBoardgames
(
	[CreatorId] INT NOT NULL FOREIGN KEY REFERENCES [Creators]([Id]),
	[BoardgameId] INT NOT NULL FOREIGN KEY REFERENCES [Boardgames]([Id]),
	PRIMARY KEY([CreatorId], [BoardgameId])
)

--Section 2. DML (10 pts)

--02.	Insert
INSERT INTO Boardgames
VALUES
('Deep Blue', 2019, 5.67, 1, 15, 7),
('Paris', 2016, 9.78, 7, 1, 5),
('Catan: Starfarers', 2021, 9.87, 7, 13, 6),
('Bleeding Kansas', 2020, 3.25, 3, 7, 4),
('One Small Step', 2019, 5.75, 5, 9, 2)

INSERT INTO Publishers
VALUES
('Agman Games', 5, 'www.agmangames.com', '+16546135542'),
('Amethyst Games', 7, 'www.amethystgames.com', '+15558889992'),
('BattleBooks', 13, 'www.battlebooks.com', '+12345678907')

--03.	Update
UPDATE PlayersRanges
SET PlayersMax = 3
WHERE PlayersMin = 2 AND PlayersMax = 2

UPDATE Boardgames 
SET [Name] = CONCAT([Name], 'V2')
WHERE YearPublished >= 2020

--04.	Delete
DELETE FROM CreatorsBoardgames
WHERE CreatorId NOT IN (5,7)

DELETE FROM Boardgames
WHERE PublisherId = 1

DELETE FROM Publishers
WHERE AddressId = 
	(
		SELECT [Id]
		FROM Addresses
		WHERE Town LIKE 'L%'	
	)
DELETE FROM Addresses
WHERE Town LIKE 'L%'

--Section 3. Querying (40 pts)

--05. Boardgames by Year of Publication
SELECT
	[Name],
	Rating
FROM Boardgames
ORDER BY YearPublished ASC, [Name] DESC

--06. Boardgames by Category
SELECT 
	b.Id,
	b.[Name],
	b.YearPublished,
	c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN Categories AS c
ON b.CategoryId = c.Id
WHERE c.[Name] = 'Strategy Games' OR c.[Name] = 'Wargames'
ORDER BY YearPublished DESC

--07. Creators without Boardgames

SELECT 
	c.Id,
	CONCAT(FirstName, ' ', LastName) AS CreatorName,
	Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
WHERE CreatorId IS NULL
ORDER BY CreatorName ASC

--08. First 5 Boardgames

SELECT TOP(5)
	b.[Name],
	b.Rating,
	c.[Name] AS CategoryName
FROM Boardgames AS b
JOIN PlayersRanges AS pr
ON b.PlayersRangeId = pr.Id
JOIN Categories AS c
ON b.CategoryId = c.Id
WHERE (Rating >= 7.00 AND b.[Name] LIKE '%a%')
	  OR (Rating > 7.50 AND pr.PlayersMin = 2 AND pr.PlayersMax = 5)
ORDER BY b.[Name] ASC, b.Rating DESC

--09. Creators with Emails

SELECT  
	CONCAT(c.[FirstName], ' ', c.[LastName]) AS FullName,
	c.Email,
	MAX(b.Rating) AS Rating
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
WHERE c.Email LIKE '%.com'
GROUP BY c.FirstName, c.LastName, c.Email
ORDER BY FullName ASC

--10. Creators by Rating

SELECT 
	c.LastName,
	CEILING(AVG(b.Rating)) AS AverageRating,
	p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb
ON c.Id = cb.CreatorId
JOIN Boardgames AS b
ON cb.BoardgameId = b.Id
JOIN Publishers AS p
ON b.PublisherId = p.Id
WHERE p.[Name] = 'Stonemaier Games'
GROUP BY c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC

--Section 4. Programmability (20 pts)

--11. Creator with Boardgames

GO
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @creatorID INT = 
		(
			SELECT [Id]
			FROM Creators
			WHERE FirstName = @name
		)
	DECLARE @count INT =
		(
			SELECT
				COUNT(*)
			FROM CreatorsBoardgames
			WHERE CreatorId = @creatorID
		)
	RETURN @count
END

GO
SELECT dbo.udf_CreatorWithBoardgames('Bruno')

--12. Search for Boardgame with Specific Category

GO
CREATE PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
BEGIN
	SELECT 
		b.[Name], 
		b.YearPublished, 
		b.Rating, 
		c.[Name] AS CategoryName, 
		p.[Name] AS PublisherName, 
		CONCAT(PlayersMin, ' people') AS MinPlayers,
		CONCAT(PlayersMax, ' people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c
	ON b.CategoryId = c.Id
	JOIN Publishers AS p
	ON b.PublisherId = p.Id
	JOIN PlayersRanges AS pr
	ON b.PlayersRangeId = pr.Id
	WHERE c.[Name] = @category
	ORDER BY p.[Name] ASC, b.YearPublished DESC
END

EXEC usp_SearchByCategory 'Wargames'