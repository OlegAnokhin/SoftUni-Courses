namespace _05.FootballTeamGeneratorBONUS
{
    using System;
    using System.Text;
    using System.Collections.Generic;

    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NameNullMessage);
                }
                this.name = value;
            }
        }
        public Stats Stats { get; private set; }

    }
}
