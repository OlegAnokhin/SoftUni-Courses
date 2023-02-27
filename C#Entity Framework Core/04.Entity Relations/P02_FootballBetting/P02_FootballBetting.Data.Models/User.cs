using System.ComponentModel.DataAnnotations;
using P02_FootballBetting.Data.Common;

namespace P02_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            this.Bets = new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(ValidationConstans.UsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(ValidationConstans.PasswordMaxLength)]
        public string Password { get; set; }

        [Required]
        [MaxLength(ValidationConstans.EmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(ValidationConstans.NameMaxLength)]
        public string Name { get; set; }

        public decimal Balance { get; set; }
        public virtual ICollection<Bet> Bets { get; set; }
    }
}