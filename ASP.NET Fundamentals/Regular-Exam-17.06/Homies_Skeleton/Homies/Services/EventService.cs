using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AllEventsViewModel>> GetAllAsync()
        {
            return await context
                .Events
                .Select(e => new AllEventsViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Start = e.Start,
                Type = e.Type.Name
            }).ToListAsync();
        }

        public async Task<IEnumerable<JoinedEventsViewModel>> GetMyJoindedEventsAsync(string userId)
        {
            return await context.EventParticipants
                .Where(ep => ep.HelperId == userId)
                .Select(e => new JoinedEventsViewModel()
                {
                    Id = e.Event.Id,
                    Name = e.Event.Name,
                    Start = e.Event.Start,
                    Type = e.Event.Type.Name
                }).ToListAsync();
        }

        public async Task<AddEventViewModel> GetTypesForAddNewBookAsync()
        {
            var types = await context.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();
            var model = new AddEventViewModel()
            {
                Types = types
            };
            return model;
        }

        public async Task AddEventAsync(AddEventViewModel model)
        {
            Event ev = new Event
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = model.OrganiserId,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId,
                CreatedOn = model.CreatedOn
            };
            await context.Events.AddAsync(ev);
            await context.SaveChangesAsync();
        }

        
    }
}
