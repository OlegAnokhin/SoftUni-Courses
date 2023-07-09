#nullable disable
namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Identity;

    public class EventParticipant
    {
        public string HelperId { get; set; }

        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; }

        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
    }
}