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
        public string OrganiserId { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime CreatedOn { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime End { get; set; }

        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
