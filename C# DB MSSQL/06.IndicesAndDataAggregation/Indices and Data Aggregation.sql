
--01
SELECT 
	COUNT(wd.Id) AS Count
FROM [WizzardDeposits] AS wd

--02
SELECT
	MAX(wd.[MagicWandSize]) AS LongestMagicWand
FROM [WizzardDeposits] AS wd