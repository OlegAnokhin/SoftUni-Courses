
--Section 1. DDL (30 pts)

--01 1. Database design

CREATE DATABASE TripService

USE TripService

CREATE TABLE Cities
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	[CountryCode] VARCHAR(2) NOT NULL
)
CREATE TABLE Hotels
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	[CityId] INT NOT NULL FOREIGN KEY REFERENCES [Cities]([Id]),
	[EmployeeCount] INT NOT NULL,
	[BaseRate] DECIMAL(18, 2)
)
CREATE TABLE Rooms
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Price] DECIMAL(18, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	[Beds] INT NOT NULL,
	[HotelId] INT NOT NULL FOREIGN KEY REFERENCES [Hotels]([Id])
)
CREATE TABLE Trips
(
	[Id] INT PRIMARY KEY IDENTITY,
	[RoomId] INT NOT NULL FOREIGN KEY REFERENCES [Rooms]([Id]),
	[BookDate] DATE NOT NULL,
	[ArrivalDate] DATE NOT NULL,
	[ReturnDate] DATE NOT NULL,
	[CancelDate] DATE,
	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate)
)
CREATE TABLE Accounts
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[MiddleName] NVARCHAR(20),
	[LastName] NVARCHAR(50) NOT NULL,
	[CityId] INT NOT NULL FOREIGN KEY REFERENCES [Cities]([Id]),
	[BirthDate] DATE NOT NULL,
	[Email] VARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE AccountsTrips
(
	[AccountId] INT NOT NULL FOREIGN KEY REFERENCES [Accounts]([Id]),
	[TripId] INT NOT NULL FOREIGN KEY REFERENCES [Trips]([Id]),
	[Luggage] INT NOT NULL CHECK([Luggage] >= 0),
	PRIMARY KEY([AccountId], [TripId])
)

--Section 2. DML (10 pts)

--02. Insert

INSERT INTO Accounts
VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips
VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03. Update

UPDATE [Rooms]
SET [Price] = [Price] * 1.14
WHERE [HotelId] IN (5, 7, 9)

--04. Delete

DELETE 
FROM [AccountsTrips]
WHERE [AccountId] = 47

--Section 3. Querying (40 pts)

--05. EEE-Mails

SELECT 
	a.[FirstName],
	a.[LastName],
	FORMAT(a.[BirthDate], 'MM-dd-yyyy'),
	c.[Name],
	a.[Email]
FROM [Accounts] AS a
JOIN [Cities] AS c
ON a.CityId = c.Id
WHERE [Email] LIKE 'e%'
ORDER BY c.[Name] ASC

--06. City Statistics

SELECT
	c.[Name],
	COUNT(h.[CityId]) AS Hotels
FROM [Cities] AS c
JOIN [Hotels] AS h
ON c.[Id] = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC, c.[Name] ASC

--07. Longest and Shortest Trips

SELECT
	info.[AccountId],
	CONCAT(a.[FirstName], ' ', a.[LastName]) AS [FullName],
	info.LongestTrip,
	info.ShortestTrip
FROM
(
	SELECT 
	    at.[AccountId],
		MAX(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS LongestTrip,
		MIN(DATEDIFF(DAY, t.[ArrivalDate], t.[ReturnDate])) AS ShortestTrip
	FROM [AccountsTrips] AS at
	JOIN [Trips] AS t 
	ON at.[TripId] = t.[Id]
	WHERE t.[CancelDate] IS NULL
	GROUP BY at.[AccountId]
) AS info
JOIN [Accounts] AS a 
ON	a.[Id] = info.[AccountId]
WHERE a.[MiddleName] IS NULL
ORDER BY info.LongestTrip DESC, info.ShortestTrip;

--08. Metropolis

SELECT TOP 10
	c.Id,
	c.[Name] AS City,
	c.[CountryCode] AS Country,
	info.Accounts
FROM
(
	SELECT
		CityId,
		COUNT(*) AS Accounts
	FROM [Accounts]
	GROUP BY CityId
) AS info
JOIN [Cities] AS c
ON c.Id = info.[CityId]
ORDER BY info.Accounts DESC

--09. Romantic Getaways

SELECT
	 a.[Id],
	 a.[Email],
	 c.[Name] AS City,
	 COUNT(at.[TripId]) AS Trips
FROM [Accounts] AS a
JOIN [AccountsTrips] AS at
ON a.[Id] = at.[AccountId]
JOIN [Trips] AS t
ON t.[Id] = at.[TripId]
JOIN [Rooms] AS r
ON r.Id = t.[RoomId]
JOIN [Hotels] AS h
ON h.[CityId] = a.[CityId] AND h.[Id] = r.[HotelId]
JOIN [Cities] AS c
ON c.[Id] = a.[CityId]
GROUP BY a.[Id], a.[Email], c.[Name]
ORDER BY Trips DESC, a.[Id] ASC

--10. GDPR Violation

SELECT 
	t.[Id],
	CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) AS [Full Name],
	c.[Name] AS [From],
	ch.[Name] AS [To],
	CASE
		WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' days')
		ELSE 'Canceled'
		END AS Duration
FROM [Trips] t
JOIN [AccountsTrips] AS at 
ON at.[TripId] = t.[Id]
JOIN [Accounts] AS a 
ON a.[Id] = at.[AccountId]
JOIN [Cities] AS c 
ON c.[Id] = a.[CityId]
JOIN [Rooms] AS r 
ON r.[Id] = t.[RoomId]
JOIN [Hotels] AS h 
ON h.[Id] = r.[HotelId]
JOIN [Cities] AS ch 
ON ch.[Id] = h.[CityId]
ORDER BY [Full Name]ASC, t.[Id] ASC

--Section 4. Programmability (14 pts)

--11. Available Room

GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @roomId INT = 
		(
			SELECT TOP 1
				r.[Id]
			FROM [Trips] AS t
			JOIN [Rooms] AS r
			ON t.[RoomId] = r.[Id]
			JOIN [Hotels] AS h
			ON h.[Id] = r.[HotelId]
			WHERE h.[Id] = @HotelId
				  AND @Date NOT BETWEEN t.[ArrivalDate] AND t.[ReturnDate]
				  AND t.[CancelDate] IS NULL
				  AND r.[Beds] >= @People
				  AND YEAR(@Date) = YEAR(t.[ArrivalDate])
			ORDER BY r.[Price] DESC
		)
	IF @roomId IS NULL
	RETURN 'No rooms available'
	DECLARE @roomType NVARCHAR(20) =
		(
			SELECT 
				[Type]
			FROM [Rooms]
			WHERE [Id] = @roomId
		)
	DECLARE @beds INT = 
		(
			SELECT
				[Beds]
			FROM [Rooms]
			WHERE [Id] = @roomId
		)
	DECLARE @roomPrice DECIMAL(18, 2) =
		(
			SELECT
				[Price]
			FROM [Rooms]
			WHERE [Id] = @roomId
		)
	DECLARE @hotelBaseRate  DECIMAL(18, 2) =
		(
			SELECT
				[BaseRate]
			FROM [Hotels]
			WHERE [Id] = @HotelId
		)
	DECLARE @totalPrice DECIMAL(18, 2) =
		(@hotelBaseRate + @roomPrice) * @People
	RETURN CONCAT('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds) - $', @totalPrice)
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

-- 12. Switch Room

GO
CREATE OR ALTER PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @hotelRoomId INT = 
		(
			SELECT
				h.Id
			FROM Hotels h
			JOIN Rooms r 
			ON h.Id = r.HotelId
			WHERE r.Id = @TargetRoomId
		)
	DECLARE @hotelTripId INT = 
		(
			SELECT 
				h2.Id
			FROM Trips t
			JOIN Rooms r2 
			ON r2.Id = t.RoomId
			JOIN Hotels h2 
			ON r2.HotelId = h2.Id
			WHERE t.Id = @TripId
		)
	DECLARE @availableBeds INT = 
		(
			SELECT
				Beds
			FROM Rooms r3
			WHERE Id = @TargetRoomId
		)
	DECLARE @neededBeds INT = 
		(
			SELECT
				COUNT(AccountId)
			FROM AccountsTrips at2
			WHERE TripId = @TripId
		)
	IF @hotelRoomId <> @hotelTripId
		THROW 50001, 'Target room is in another hotel!', 1;
	IF @availableBeds < @neededBeds
		THROW 50002, 'Not enough beds in target room!', 1;
	UPDATE Trips
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId;
END

EXEC usp_SwitchRoom 10, 11;

SELECT RoomId FROM Trips WHERE Id = 10;

EXEC usp_SwitchRoom 10, 7;

EXEC usp_SwitchRoom 10, 8;