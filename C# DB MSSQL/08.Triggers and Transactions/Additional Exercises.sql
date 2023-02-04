
--01
SELECT 
	SUBSTRING(Email, CHARINDEX('@', Email) +1, LEN(Email)) AS [Email Provider],
	COUNT([u].Email) AS [Number Of Users]
	FROM [Users] AS u
GROUP BY SUBSTRING(Email, CHARINDEX('@', Email) +1, LEN(Email))
ORDER BY [Number Of Users] DESC, [Email Provider] ASC

--02
SELECT 
	g.[Name] AS [Game],
	gt.[Name] AS [Game Type],
	u.[Username] AS [Username],
	ug.[Level] AS [Level],
	ug.[Cash] AS [Cash],
	c.[Name] AS [Character]
FROM [Games] AS g
INNER JOIN [UsersGames] AS ug
ON ug.[GameId] = g.[Id]
INNER JOIN [GameTypes] AS gt
ON g.[GameTypeId] = gt.[Id]
INNER JOIN [Users] AS u
ON ug.[UserId] = u.[Id]
INNER JOIN [Characters] AS c
ON ug.CharacterId = c.[Id]
ORDER BY ug.[Level] DESC, u.[Username] ASC, g.[Name] ASC

--03
SELECT 
	u.Username AS [Username],
	g.[Name] AS [Game],
	COUNT([ugi].[ItemId]) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM [Games] AS g
INNER JOIN [UsersGames] AS ug
ON g.[Id] = ug.[GameId]
INNER JOIN [UserGameItems] AS ugi
ON ugi.[UserGameId] = ug.[Id]
INNER JOIN [Items] AS i
ON ugi.[ItemId] = i.[Id]
INNER JOIN [Users] AS u
ON ug.[UserId] = u.[Id]
GROUP BY g.[Name], u.[Username]
HAVING COUNT([ugi].[ItemId]) >= 10
ORDER BY COUNT([ugi].[ItemId]) DESC, SUM(i.[Price])DESC, u.[Username]

--04 BONUS
--select 
--	u.user_name, 
--	g.name as game, 
--	MAX(c.name) as ch,
--	SUM(its.strength) + MAX(gts.strength) + MAX(cs.strength) as strength,
--	SUM(its.defence) + MAX(gts.defence) + MAX(cs.defence) as defence,
--	SUM(its.speed) + MAX(gts.speed) + MAX(cs.speed) as speed,
--	SUM(its.mind) + MAX(gts.mind) + MAX(cs.mind) as mind,
--	SUM(its.luck) + MAX(gts.luck) + MAX(cs.luck) as luck
--from users u
--join users_games ug on ug.user_id = u.id
--join games g on ug.game_id = g.id
--join game_types gt on gt.id = g.game_type_id
--join statistics gts on gts.id = gt.bonus_stats_id
--join characters c on ug.character_id = c.id
--join statistics cs on cs.id = c.statistics_id
--join user_game_items ugi on ugi.user_game_id = ug.id
--join items i on i.id = ugi.item_id
--join statistics its on its.id = i.statistics_id
--group by u.user_name, g.name
--order by strength desc, defence desc, speed desc, mind desc, luck desc

--05
SELECT 
	i.[Name],
	i.[Price],
	i.[MinLevel],
	s.[Strength],
	s.[Defence],
	s.[Speed],
	s.[Luck],
	s.[Mind] 
FROM [Items] AS i
JOIN [Statistics] AS s
ON i.StatisticId = s.Id
WHERE s.Mind > 9 AND s.Luck > 9 AND s.Speed > 9
ORDER BY i.[Name]ASC


--06
SELECT 
	i.[Name] AS [Item],
	i.[Price] AS [Price],
	i.[MinLevel] AS [MinLevel],
	gt.[Name] AS [Forbidden Game Type]
FROM [Items] AS i
INNER JOIN [GameTypeForbiddenItems] AS gtfi
ON i.Id = gtfi.ItemId
INNER JOIN [GameTypes] AS gt
ON gt.Id = gtfi.GameTypeId
ORDER BY gt.[Name] DESC, i.[Name] ASC


--SELECT

SELECT * 
FROM [Statistics]

SELECT 
	*
FROM [Items] AS i
JOIN [GameTypeForbiddenItems] AS gtfi
ON i.Id = gtfi.ItemId
JOIN [GameTypes] AS gt
ON gt.Id = gtfi.GameTypeId





