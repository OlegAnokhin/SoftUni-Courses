using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Models
{
    public class AddEventViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }
        
        [Required]
        public DateTime End { get; set; }
        
        public int TypeId { get; set; }

        public string OrganiserId { get; set; }

        public List<AllTypesViewModel> Types { get; set; } = new List<AllTypesViewModel>();
    }
}