using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Teamwork_Projects
{
    public class Team
    {
        public Team(string teamName, string creatorName)
        {
            this.Name = teamName;
            this.Creator = creatorName;
            this.Members = new List<string>();
        }

        public string Name { get; set; }

        public string Creator { get; set; }

        public List<string> Members { get; set; }

        public void AddMember(string member)
        {
            this.Members.Add(member);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            int n = int.Parse(Console.ReadLine());
            RegisterTeeams(teams, n);

            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] joinArgs = command
                    .Split("->", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string memberName = joinArgs[0];
                string teamName = joinArgs[1];

                Team searchedTeam = teams.FirstOrDefault(t => t.Name == teamName);

                if (searchedTeam == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }
                if (teams.Any(t => t.Members.Contains(memberName)))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }
                //if (IsAlredyMemberTeam(teams, memberName))
                //{
                //    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                //    continue;
                //}
                if (teams.Any(t => t.Creator == memberName))
                {
                    Console.WriteLine($"Member {memberName} cannot join team {teamName}!");
                    continue;
                }
                searchedTeam.AddMember(memberName);

            }

            List<Team> teamsWithMembers = teams
                .Where(t => t.Members.Count > 0)
                .OrderByDescending(t => t.Members.Count)
                .ThenBy(t => t.Name)
                .ToList();
            List<Team> teamsToDisband = teams
                .Where(t => t.Members.Count == 0)
                .OrderBy(t => t.Name)
                .ToList();
            PrintValidTeams(teamsWithMembers);
            PrintInvalidTeams(teamsToDisband);
        }

        static void RegisterTeeams(List<Team> teams, int n)
        {
            for (int i = 0; i < n; i++)
            {
                string[] teamArgs = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string creatorName = teamArgs[0];
                string teamName = teamArgs[1];

                if (teams.Any(t => t.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }
                if (teams.Any(t => t.Creator == creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                    continue;
                }
                Team newTeam = new Team(teamName, creatorName);
                teams.Add(newTeam);
                Console.WriteLine($"Team {teamName} has been created by {creatorName}!");
            }
        }

        static void PrintValidTeams(List<Team> validTeams)
        {
            foreach (Team validTeam in validTeams)
            {
                Console.WriteLine($"{validTeam.Name}");
                Console.WriteLine($"- {validTeam.Creator}");

                foreach (string currmember in validTeam.Members.OrderBy(m => m))
                {
                    Console.WriteLine($"-- {currmember}");
                }
            }

        }
        static void PrintInvalidTeams(List<Team> invalidTeams)
        {
            Console.WriteLine("Teams to disband:");
            foreach (Team invalidTeam in invalidTeams)
            {
                Console.WriteLine($"{invalidTeam.Name}");
            }

        }


        //static bool IsAlredyMemberTeam(List<Team> teams, string memberName)
        //{
        //    foreach (Team team in teams)
        //    {
        //        if (team.Members.Contains(memberName))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }
}
