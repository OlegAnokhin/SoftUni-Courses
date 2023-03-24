namespace Footballers.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class TeamFootballer
    {
        public int TeamId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        public int FootballerId { get; set; }

        [ForeignKey(nameof(FootballerId))]
        public Footballer Footballer { get; set; } = null!;
    }
}