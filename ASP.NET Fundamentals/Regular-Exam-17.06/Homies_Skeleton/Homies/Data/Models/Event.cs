using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using static Homies.Common.ValidationConstants.Event;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

       // [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        public IdentityUser Organiser { get; set; } = null!;

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime CreatedOn { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime Start { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Полето '{0}' е задължително")]
        public DateTime End { get; set;}

        [Required]
        public int TypeId { get; set; }

        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public List<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}