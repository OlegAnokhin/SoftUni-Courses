using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                var cmdArgs = Console.ReadLine().Split();
                var person = new Person(cmdArgs[0],
                                        cmdArgs[1],
                                        int.Parse(cmdArgs[2]),
                                        decimal.Parse(cmdArgs[3]));

                Team team = new Team("SoftUni");
                foreach (Person perso in persons)
                {
                    team.AddPlayer(person);
                }
            }



            // как се печата това съобщение????????

            //Console.WriteLine($"First team has {CountFirst} players.");

            //int firrs = Team.;

            //return $"First team has {FirstTeam.Count} players.";
            //return $"Reserve team has {ReserveTeam.Count} players.";

        }
    }
}
