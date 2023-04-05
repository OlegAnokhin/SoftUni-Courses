using System.ComponentModel.DataAnnotations;
using Boardgames.Common;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public Seller()
        {
            this.BoardgamesSellers = new HashSet<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SellerNameMaxLenght)]
        public string Name { get; set; }

        [Required]
        [MaxLength(ValidationConstants.SellerAddressMaxLenght)]
        public string Address { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Website { get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}