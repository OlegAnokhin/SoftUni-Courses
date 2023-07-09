#nullable disable
namespace Homies.Models.Event
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Type;
    using static Common.ValidationConstants.Event;

    public class EventFormModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Display(Name = "Type of event")]
        public int TypeId { get; set; }

        public string OrganiserId { get; set; }

        public List<AllTypesModel> Types { get; set; } = new List<AllTypesModel>();
    }
}