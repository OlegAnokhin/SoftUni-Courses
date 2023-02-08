
--Section 1. DDL (30 pts)

--01. DDL

CREATE DATABASE NationalTouristSitesOfBulgaria
USE NationalTouristSitesOfBulgaria

CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE Locations
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)
CREATE TABLE Sites
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT NOT NULL FOREIGN KEY REFERENCES [Locations]([Id]),
	[CategoryId] INT NOT NULL FOREIGN KEY REFERENCES [Categories]([Id]),
	[Establishment] VARCHAR(15)
)
CREATE TABLE Tourists
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL CHECK([Age] BETWEEN 0 AND 120),
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)
CREATE TABLE SitesTourists
(
	[TouristId] INT NOT NULL FOREIGN KEY REFERENCES [Tourists]([Id]),
	[SiteId] INT NOT NULL FOREIGN KEY REFERENCES [Sites]([Id]),
	PRIMARY KEY([TouristId], [SiteId])
)
CREATE TABLE BonusPrizes
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)
CREATE TABLE TouristsBonusPrizes
(
	[TouristId] INT NOT NULL FOREIGN KEY REFERENCES [Tourists]([Id]),
	[BonusPrizeId] INT NOT NULL FOREIGN KEY REFERENCES [BonusPrizes]([Id]),
	PRIMARY KEY([TouristId], [BonusPrizeId])
)

--02. Insert

INSERT INTO Tourists
VALUES
('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
('Peter Bosh', 48, '+447911844141', 'UK', NULL),
('Martin Smith', 29, '+353863818592', 'Ireland', 'Bronze badge'),
('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)

INSERT INTO Sites
VALUES
('Ustra fortress', 90, 7, 'X'),
('Karlanovo Pyramids', 65, 7, NULL),
('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
('Sinite Kamani Natural Park', 17, 1, NULL),
('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

--03. Update

UPDATE [Sites]
SET [Establishment] = '(not defined)'
WHERE [Establishment] IS NULL

--04. Delete

DELETE FROM [TouristsBonusPrizes]
WHERE [BonusPrizeId] = 
	(
		SELECT [Id]
		FROM BonusPrizes
		WHERE [Name] = 'Sleeping bag'	
	)

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'


--Section 3. Querying (40 pts)

--05. Tourists

SELECT
	[Name],
	Age,
	PhoneNumber,
	Nationality
FROM Tourists
ORDER BY Nationality ASC, Age DESC, [Name] ASC

--06. Sites with Their Location and Category

SELECT
	s.[Name] AS [Site],
	l.[Name] AS [Location],
	s.[Establishment],
	c.[Name] AS [Category]
FROM Sites AS s
JOIN Locations AS l
ON s.LocationId = l.Id
JOIN Categories AS c
ON s.CategoryId = c.Id
ORDER BY c.[Name] DESC, l.[Name] ASC, s.[Name] ASC

--07. Count of Sites in Sofia Province

SELECT 
	l.Province,
	l.Municipality,
	l.[Name] AS [Location],
	COUNT(s.[Name]) AS CountOfSites
FROM Locations AS l
JOIN Sites AS s
ON l.Id = s.LocationId
WHERE Province = 'Sofia'
GROUP BY l.Province, l.Municipality, l.[Name]
--GROUP BY l.Name, l.Municipality, l.Province
ORDER BY CountOfSites DESC, l.[Name]

--08. Tourist Sites established BC

SELECT 
	s.[Name] AS [Site],
	l.[Name] AS [Location],
	l.Municipality,
	l.Province,
	s.Establishment
FROM Locations AS l
INNER JOIN Sites AS s
ON s.LocationId = l.Id
INNER JOIN Categories AS c
ON c.Id = s.CategoryId
WHERE l.[Name] NOT LIKE 'B%' 
	  AND l.[Name] NOT LIKE 'M%' 
	  AND l.[Name] NOT LIKE 'D%' 
	  AND s.Establishment LIKE '%BC'
--WHERE LEFT(l.Name, 1) NOT LIKE '[B,M,D]'
ORDER BY s.[Name] ASC

--09. Tourists with their Bonus Prizes

SELECT
	t.[Name],
	t.Age,
	t.PhoneNumber,
	t.Nationality,
	CASE
		WHEN bp.[Name] IS NULL THEN '(no bonus prize)'
		ELSE bp.[Name]
	END AS Reward
FROM Tourists AS t
LEFT JOIN TouristsBonusPrizes AS tbp
ON t.Id = tbp.TouristId
LEFT JOIN BonusPrizes AS bp
ON tbp.BonusPrizeId = bp.Id
ORDER BY t.[Name] ASC

--10. Tourists visiting History & Archaeology sites

SELECT DISTINCT
	SUBSTRING(t.[Name], CHARINDEX(' ', t.[Name]) +1, LEN(t.[Name])) AS LastName,
	t.Nationality,
	t.Age,
	t.PhoneNumber
FROM Tourists AS t
JOIN SitesTourists AS st
ON t.Id = st.TouristId
JOIN Sites AS s
ON st.SiteId = s.Id
JOIN Categories AS c
ON s.CategoryId = c.Id
WHERE c.[Name] = 'History and archaeology'
ORDER BY LastName ASC

--Section 4. Programmability (20 pts)

--11. Tourists Count on a Tourist Site

GO
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100)) 
RETURNS INT
AS
BEGIN
	DECLARE @ID INT = 
		(
			SELECT [Id]
			FROM [Sites]
			WHERE [Name] =  @Site
		)
	DECLARE @count INT =
		(
			SELECT
				COUNT(*)
			FROM [SitesTourists]
			WHERE [SiteId] = @ID
		)
	RETURN @count
END
GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')
SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')

--12. Annual Reward Lottery

GO
CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
	SELECT 
		t.[Name],
		CASE
			WHEN COUNT(st.SiteId) >= 100 THEN 'Gold badge'
			WHEN COUNT(st.SiteId) >= 50 THEN 'Silver badge'
			WHEN COUNT(st.SiteId) >= 25 THEN 'Bronze badge'
			ELSE NULL
			END AS Reward
	FROM Tourists AS t
	JOIN SitesTourists AS st
	ON t.Id = st.TouristId
	WHERE t.[Name] = @TouristName
	GROUP BY t.[Name]
END

GO
EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'
EXEC usp_AnnualRewardLottery 'Teodor Petrov'
EXEC usp_AnnualRewardLottery 'Zac Walsh'
EXEC usp_AnnualRewardLottery 'Brus Brown'