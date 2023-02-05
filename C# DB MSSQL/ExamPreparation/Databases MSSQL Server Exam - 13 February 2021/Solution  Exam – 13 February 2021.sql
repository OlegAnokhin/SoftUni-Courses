
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




SELECT * FROM [Repositories]
WHERE [Name] = 'Softuni-Teamwork'
