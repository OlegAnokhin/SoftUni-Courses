using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Homies.Data.Models
{
    public class EventParticipant
    {
        public string HelperId { get; set; } = null!;

        [ForeignKey(nameof(HelperId))]
        public IdentityUser Helper { get; set; } = null!;
        
        public int EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; } = null!;
    }
}