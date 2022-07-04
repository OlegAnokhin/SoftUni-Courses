using System;
using System.Text;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }
        public IReadOnlyCollection<Person> FirstTeam 
        { 
            get
            { return this.firstTeam.AsReadOnly(); }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
        public int CountFirst { get { return firstTeam.Count; } }
        public int CountReserve { get { return reserveTeam.Count; } }
        public override string ToString()
        {
            return $"First team has {FirstTeam.Count} players.";
            return $"Reserve team has {ReserveTeam.Count} players.";
        }

    }
}
