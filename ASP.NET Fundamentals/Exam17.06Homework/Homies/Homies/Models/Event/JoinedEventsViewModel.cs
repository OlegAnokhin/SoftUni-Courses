#nullable disable
namespace Homies.Models.Event
{
    public class JoinedEventsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Start { get; set; }

        public string Organiser { get; set; }
        
        public string Type { get; set; } 
    }
}