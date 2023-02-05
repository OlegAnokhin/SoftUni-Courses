
--Section 1. DDL (30 pts)
CREATE DATABASE [Bitbucket]

-- 01. DDL

CREATE TABLE Users
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	[RepositoryId] INT NOT NULL FOREIGN KEY REFERENCES [Repositories]([Id]),
	[ContributorId] INT NOT NULL FOREIGN KEY REFERENCES [Users]([Id]),
	PRIMARY KEY([RepositoryId], [ContributorId])
)

CREATE TABLE Issues
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Title] VARCHAR(255) NOT NULL,
	[IssueStatus] VARCHAR(6) NOT NULL,
	[RepositoryId] INT NOT NULL FOREIGN KEY REFERENCES [Repositories]([Id]),
	[AssigneeId] INT NOT NULL FOREIGN KEY REFERENCES [Users]([Id])
)

CREATE TABLE Commits
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Message] VARCHAR(255) NOT NULL,
	[IssueId] INT FOREIGN KEY REFERENCES [Issues]([Id]),
	[RepositoryId] INT NOT NULL FOREIGN KEY REFERENCES [Repositories]([Id]),
	[ContributorId] INT NOT NULL FOREIGN KEY REFERENCES [Users]([Id])
)

CREATE TABLE Files
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[Size] DECIMAL(18, 2) NOT NULL,
	[ParentId] INT FOREIGN KEY REFERENCES [Files]([Id]),
	[CommitId] INT NOT NULL FOREIGN KEY REFERENCES [Commits]([Id])
)
GO

--Section 2. DML (10 pts)

--02. Insert

INSERT INTO [Files]([Name], [Size], [ParentId], [CommitId])
VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15,	4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix',	7662.92, 7, 7)

INSERT INTO [Issues]([Title], [IssueStatus], [RepositoryId], [AssigneeId])
VALUES
('Critical Problem with HomeController.cs file', 'open', 1, 4),
('Typo fix in Judge.html', 'open', 4, 3),	
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

--03. Update

UPDATE [Issues]
SET [IssueStatus] = 'closed'
WHERE [AssigneeId] = 6

--04. Delete

DELETE FROM [RepositoriesContributors]
WHERE [RepositoryId] = 
	(
		SELECT [Id]
		FROM [Repositories]
		WHERE [Name] = 'Softuni-Teamwork'
	)
DELETE FROM [Commits]
WHERE [IssueId] IN 
		(
			SELECT [Id]
			FROM [Issues]
			WHERE [RepositoryId] =
				(
					SELECT [Id]
					FROM [Repositories]
					WHERE [Name] = 'Softuni-Teamwork'
				)
		)
DELETE FROM [Issues]
WHERE [RepositoryId] =
				(
					SELECT [Id]
					FROM [Repositories]
					WHERE [Name] = 'Softuni-Teamwork'
				)


--Section 3. Querying (40 pts)

--05. Commits

SELECT 
	[Id],
	[Message],
	[RepositoryId],
	[ContributorId]
FROM [Commits]
ORDER BY [Id] ASC, [Message] ASC, [RepositoryId] ASC, [ContributorId] ASC

--06. Front-end

SELECT 
	[Id],
	[Name],
	[Size]
FROM [Files]
WHERE [Size] > 1000 AND [Name] LIKE '%html%'
ORDER BY [Size] DESC, [Id] ASC, [Name] ASC

--07. Issue Assignment

SELECT
	i.[Id],
	CONCAT(u.[Username], ' : ', i.[Title]) AS [IssueAssignee]
FROM [Issues] AS i
LEFT JOIN [Users] AS u
ON i.[AssigneeId] = u.[Id]
ORDER BY i.[Id] DESC, [IssueAssignee]

--08. Single Files

SELECT
	pf.[Id],
	pf.[Name],
	CONCAT(pf.[Size], 'KB')
FROM [Files] AS f
FULL OUTER JOIN [Files] AS pf
ON f.[ParentId] = pf.[Id]
WHERE f.[Id] IS NULL
ORDER BY pf.[Id] ASC, pf.[Name] ASC, pf.[Size] DESC

--09. Commits in Repositories

SELECT TOP(5) 
	r.[Id],
	r.[Name],
	COUNT(c.[Id]) AS [Commits]
FROM [Repositories] AS r
JOIN [Commits] AS c
ON c.RepositoryId = r.Id
JOIN [RepositoriesContributors] AS rc
ON rc.[RepositoryId] = r.[Id]
GROUP BY r.[Id], r.[Name]
ORDER BY [Commits] DESC, r.[Id] ASC, r.[Name] ASC 

--10. Average Size

SELECT
	u.[Username],
	AVG(f.[Size]) AS [Size]
FROM [Users] AS u
INNER JOIN [Commits] AS c
ON c.[ContributorId] = u.[Id]
INNER JOIN [Files] AS f
ON f.[CommitId] = c.[Id]
GROUP BY u.[Username]
ORDER BY [Size] DESC, u.[Username] ASC

--Section 4. Programmability (20 pts)

--11. All User Commits

GO
CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30)) 
RETURNS INT
AS
BEGIN
	DECLARE @userID INT = 
		(
			SELECT [Id]
			FROM [Users]
			WHERE [Username] = @username
		)
	DECLARE @commitsCount INT = 
		(
			SELECT 
				COUNT([Id])
			FROM [Commits]
			WHERE [ContributorId] = @userID
		)
	RETURN @commitsCount
END

GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')

--12. Search for Files
GO

CREATE PROCEDURE usp_SearchForFiles @fileExtension VARCHAR (100)
AS
BEGIN
	SELECT 
		f.[Id],
		f.[Name],
		CONCAT(f.[Size], 'KB') AS [Size]
	FROM [Files] AS f
	WHERE [Name] LIKE CONCAT('%.', @fileExtension)
	ORDER BY [Id] ASC, [Name] ASC, f.[Size] DESC 
END

EXEC usp_SearchForFiles 'txt'