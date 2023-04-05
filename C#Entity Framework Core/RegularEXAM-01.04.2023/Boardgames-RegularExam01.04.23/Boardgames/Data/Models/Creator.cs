using System.ComponentModel.DataAnnotations;
using Boardgames.Common;

namespace Boardgames.Data.Models
{
    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CreatorFirstNameMaxLenght)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CreatorLastNameMaxLenght)]
        public string LastName { get; set; }

        public virtual ICollection<Boardgame> Boardgames { get; set; }
    }
}