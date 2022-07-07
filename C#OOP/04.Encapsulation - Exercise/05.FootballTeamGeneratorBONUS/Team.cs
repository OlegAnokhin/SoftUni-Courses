namespace _05.FootballTeamGeneratorBONUS
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Team
    {
        private string name;
        private readonly List<Player> players;
        private Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name)
            : this()
        {
            this.Name = name;

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
        public int Rating
        {
            get
            {
                if (this.players.Any())
                {
                   return (int)Math.Round(this.players.Average(p => p.Stats.GetOverallStats()), 0);
                }
                return 0;
            }
        }
        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player playerToDelete = this.players
                .FirstOrDefault(p => p.Name == playerName);
            if (playerToDelete == null)
            {
                throw new InvalidOperationException(
                    String.Format(ErrorMessages.PlayerNotInTeam, playerName, this.Name));
            }
            this.players.Remove(playerToDelete);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
