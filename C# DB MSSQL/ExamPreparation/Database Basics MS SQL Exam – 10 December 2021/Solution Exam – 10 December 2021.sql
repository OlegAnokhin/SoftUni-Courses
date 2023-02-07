
--Section 1. DDL (30 pts)

--01. DDL

CREATE DATABASE Airport

USE Airport

CREATE TABLE Passengers
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FullName] VARCHAR(100) NOT NULL UNIQUE,
	[Email] VARCHAR(50) NOT NULL UNIQUE
)
CREATE TABLE Pilots
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(30) NOT NULL UNIQUE,
	[LastName] VARCHAR(30) NOT NULL UNIQUE,
	[Age] TINYINT NOT NULL CHECK([Age] BETWEEN 21 AND 62),
	[Rating] FLOAT CHECK([Rating] BETWEEN 0.0 AND 10.0)
)
CREATE TABLE AircraftTypes
(
	[Id] INT PRIMARY KEY IDENTITY,
	[TypeName] VARCHAR(30) NOT NULL UNIQUE
)
CREATE TABLE Aircraft
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Manufacturer] VARCHAR(25) NOT NULL,
	[Model] VARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	[FlightHours] INT,
	[Condition] CHAR NOT NULL,
	[TypeId] INT NOT NULL FOREIGN KEY REFERENCES [AircraftTypes]([Id])
)
CREATE TABLE PilotsAircraft
(
	[AircraftId] INT NOT NULL FOREIGN KEY REFERENCES [Aircraft]([Id]),
	[PilotId] INT NOT NULL FOREIGN KEY REFERENCES [Pilots]([Id]),
	PRIMARY KEY([AircraftId], [PilotId])
)
CREATE TABLE Airports
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportName] VARCHAR(70) NOT NULL UNIQUE,
	[Country] VARCHAR(100) NOT NULL UNIQUE
)
CREATE TABLE FlightDestinations
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AirportId] INT NOT NULL FOREIGN KEY REFERENCES [Airports]([Id]),
	[Start] DATETIME NOT NULL,
	[AircraftId] INT NOT NULL FOREIGN KEY REFERENCES [Aircraft]([Id]),
	[PassengerId] INT NOT NULL FOREIGN KEY REFERENCES [Passengers]([Id]),
	[TicketPrice] DECIMAL(18, 2) DEFAULT 15 NOT NULL
)

--Section 2. DML (10 pts)

--02. Insert

INSERT INTO [Passengers](FullName, Email)
SELECT 
	CONCAT(FirstName, ' ', LastName), 
	CONCAT(FirstName, LastName, '@gmail.com')
FROM Pilots 
WHERE Id BETWEEN 5 AND 15

--03. Update

UPDATE Aircraft
SET [Condition] = 'A'
WHERE (Condition = 'C' OR Condition = 'B') AND
	  (FlightHours IS NULL OR FlightHours <= 100) AND
	  [Year] >= 2013


--04. Delete

DELETE FROM Passengers
WHERE LEN(FullName) <= 10

--Section 3. Querying (40 pts)

--05. Aircraft

SELECT 
	Manufacturer,
	Model,
	FlightHours,
	Condition
FROM Aircraft
ORDER BY FlightHours DESC

--06. Pilots and Aircraft

SELECT 
	p.FirstName,
	p.LastName,
	a.Manufacturer,
	a.Model,
	a.FlightHours
FROM Pilots AS p
INNER JOIN PilotsAircraft AS pa
ON p.Id = pa.PilotId
INNER JOIN Aircraft AS a
ON pa.AircraftId = a.Id
WHERE FlightHours <= 304 AND FlightHours IS NOT NULL
ORDER BY FlightHours DESC, FirstName ASC

--07. Top 20 Flight Destinations

SELECT TOP(20)
	fd.Id AS DestinationId,
	fd.[Start],
	p.FullName, 
	a.AirportName,
	fd.TicketPrice
FROM FlightDestinations AS fd
JOIN Passengers AS p
ON fd.PassengerId = p.Id
JOIN Airports AS a
ON fd.AirportId = a.Id
WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName ASC

--08. Number of Flights for Each Aircraft

SELECT 
	a.Id AS AircraftId,
	a.Manufacturer,
	a.FlightHours,
	COUNT(fd.Id) AS FlightDestinationsCount,
	ROUND(AVG(fd.TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
JOIN FlightDestinations AS fd
ON a.Id = fd.AircraftId
GROUP BY a.Id, a.Manufacturer, a.FlightHours
HAVING COUNT(fd.Id) >= 2
ORDER BY 4 DESC, 1 ASC

--09. Regular Passengers

SELECT 
	p.FullName,
	COUNT(a.Id) AS CountOfAircraft,
	SUM(fd.TicketPrice) AS TotalPayed
FROM Passengers AS p
JOIN FlightDestinations AS fd
ON p.Id = fd.PassengerId
JOIN Aircraft AS a
ON fd.AircraftId = a.Id
WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
GROUP BY p.Id, p.FullName
HAVING COUNT(a.Id) > 1
ORDER BY FullName ASC

--10. Full Info for Flight Destinations

SELECT 
	ap.AirportName,
	fd.[Start] AS DayTime,
	fd.TicketPrice,
	p.FullName,
	a.Manufacturer,
	a.Model
FROM FlightDestinations AS fd
JOIN Passengers AS p
ON fd.PassengerId = p.Id
JOIN Aircraft AS a
ON a.Id = fd.AircraftId
JOIN Airports AS ap
ON fd.AirportId = ap.Id
WHERE DATEPART(HOUR, [Start]) BETWEEN 6 AND 20 AND
	  fd.TicketPrice >= 2500
--WHERE CAST(fd.[Start] AS TIME) BETWEEN '06:00' AND '20:00'  Правилния начин заради минутите
ORDER BY a.Model ASC

--Section 4. Programmability (20 pts)

--11. Find all Destinations by Email Address

GO
CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @passangerID INT = 
		(
			SELECT [Id]
			FROM [Passengers]
			WHERE [Email] = @email
		)
	DECLARE @count INT =
		(
			SELECT
				COUNT(*)
			FROM [FlightDestinations]
			WHERE [PassengerId] = @passangerID
		)
	RETURN @count
END

GO
SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')
SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')

--12. Full Info for Airports

GO
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
	SELECT 
		a.AirportName,
		p.FullName,
		CASE 
			WHEN fd.TicketPrice <=400 THEN 'Low'
			WHEN fd.TicketPrice BETWEEN 401 AND 1500 THEN 'Medium' 
			WHEN fd.TicketPrice > 1501 THEN 'High'
			END AS LevelOfTickerPrice,
		ac.Manufacturer,
		ac.Condition,
		aci.TypeName
	FROM Airports AS a
	JOIN FlightDestinations AS fd
	ON fd.AirportId = a.Id
	JOIN Passengers AS p
	ON p.Id = fd.PassengerId
	JOIN Aircraft AS ac
	ON fd.AircraftId = ac.Id
	JOIN AircraftTypes AS aci
	ON aci.Id = ac.TypeId
	WHERE a.AirportName = @airportName
	ORDER BY ac.Manufacturer ASC, p.FullName ASC
END

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'