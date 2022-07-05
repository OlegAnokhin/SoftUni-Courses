using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGeneratorBONUS
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command
                        .Split(';', StringSplitOptions.RemoveEmptyEntries);

                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        static void ProcessInput(List<Team> teams, string[] cmdArgs)
        {
            string cmdType = cmdArgs[0];
            string teamName = cmdArgs[1];

            if (cmdType == "Team")
            {
                Team team = new Team(teamName);
                teams.Add(team);
            }
            else if (cmdType == "Add")
            {
                string playerName = cmdArgs[2];
                Team team = teams.FirstOrDefault(t => t.Name == teamName);
                if (team == null)
                {
                    throw new InvalidOperationException(ErrorMessages.TeamNotExist);
                }
                Stats playerStats = GeneratePlayersStats(cmdArgs.Skip(3).ToArray());
                Player player = new Player(playerName, playerStats);
                team.AddPlayer(player);
            }
            else if (cmdType == "Remove")
            {
                string playerName = cmdArgs[2];
                Team team = teams
                    .FirstOrDefault(t => t.Name == teamName);
                if (team == null)
                {
                    throw new InvalidOperationException(ErrorMessages.TeamNotExist);
                }
                team.RemovePlayer(playerName);
            }
            else if (cmdType == "Rating")
            {
                Team team = teams
                    .FirstOrDefault(t => t.Name == teamName);
                if (team == null)
                {
                    throw new InvalidOperationException(ErrorMessages.TeamNotExist);
                }
                Console.WriteLine(team);
            }
        }
        static Stats GeneratePlayersStats(string[] stats)
        {
            int endurance = int.Parse(stats[0]);
            int sprint = int.Parse(stats[1]);
            int dribble = int.Parse(stats[2]);
            int passing = int.Parse(stats[3]);
            int shooting = int.Parse(stats[4]);
            Stats generatedStats = new Stats(endurance, sprint, dribble, passing, shooting);
            return generatedStats;
        }
    }
}
