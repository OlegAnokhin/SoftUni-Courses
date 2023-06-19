using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task<List<AllTypesViewModel>> GetAllTypesAsync()
        {
            return await context.Types
                .Select(t => new AllTypesViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();
        }

        public async Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync()
        {
            return await context.Events
                .Select(e => new AllEventsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name,
                    Organiser = e.Organiser.UserName
                }).ToListAsync();
        }

        public async Task AddEventAsync(AddEventViewModel model, string organiserId)
        {
            var ev = new Event()
            {
                Name = model.Name,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                OrganiserId = organiserId
            };
            await context.Events.AddAsync(ev);
            await context.SaveChangesAsync();
        }
    }
}
