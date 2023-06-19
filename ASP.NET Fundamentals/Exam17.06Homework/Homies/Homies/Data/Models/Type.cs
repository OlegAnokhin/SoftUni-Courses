using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Type;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public List<Event> Events { get; set; } = new List<Event>();
    }
}