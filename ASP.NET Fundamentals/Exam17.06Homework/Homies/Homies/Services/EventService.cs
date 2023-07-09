namespace Homies.Services
{
    using Microsoft.EntityFrameworkCore;
    using Data;
    using Contracts;
    using Homies.Data.Models;
    using Models.Event;
    using Models.Type;

    public class EventService : IEventService
    {
        private readonly HomiesDbContext context;

        public EventService(HomiesDbContext context)
        {
            this.context = context;
        }

        public async Task<List<AllTypesModel>> GetAllTypesAsync()
        {
            return await context.Types
                .Select(t => new AllTypesModel
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToListAsync();
        }

        public async Task<List<JoinedEventsViewModel>> GetJoinedEventsAsync(string userId)
        {
            return await context.EventsParticipants
                .Where(e => e.HelperId == userId)
                .Select(e => new JoinedEventsViewModel
                {
                    Id = e.EventId,
                    Name = e.Event.Name,
                    Start = e.Event.Start,
                    Type = e.Event.Type.Name
                }).ToListAsync();
        }

        public async Task<EventViewModel> GetEventById(int id)
        {
            return await context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start,
                    Type = e.Type.Name
                }).FirstAsync();
        }

        public async Task JoinToEvent(string userId, EventViewModel model)
        {
            if (!await context.EventsParticipants.AnyAsync(e => e.HelperId == userId && e.EventId == model.Id))
            {
                await context.EventsParticipants.AddAsync(new EventParticipant
                {
                    HelperId = userId,
                    EventId = model.Id
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task LeaveFromEvent(string userId, EventViewModel model)
        {
            var participant = await context.EventsParticipants
                .FirstOrDefaultAsync(e => e.HelperId == userId && e.EventId == model.Id);
            if (participant != null)
            {
                context.EventsParticipants.Remove(participant);
                await context.SaveChangesAsync();
            }
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

        public async Task CreateTaskAsync(EventFormModel model)
        {
            var newEvent = new Event
            {
                Name = model.Name,
                Description = model.Description,
                OrganiserId = model.OrganiserId,
                CreatedOn = DateTime.UtcNow,
                Start = model.Start,
                End = model.End,
                TypeId = model.TypeId
            };
            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();
        }

        public async Task EditEventAsync(int id, EventFormModel model)
        {
            var newEvent = await context.Events.FindAsync(id);
            newEvent.Name = model.Name;
            newEvent.Description = model.Description;
            newEvent.Start = model.Start;
            newEvent.End = model.End;
            newEvent.TypeId = model.TypeId;

            await context.SaveChangesAsync();
        }

        public EventFormModel GetEventFormModel(int id)
        {
            return context.Events
                .Where(e => e.Id == id)
                .Select(e => new EventFormModel
                {
                    Name = e.Name,
                    Description = e.Description,
                    OrganiserId = e.OrganiserId,
                    Start = e.Start,
                    End = e.End,
                    TypeId = e.TypeId,
                    Types = context.Types
                        .Select(t => new AllTypesModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        }).ToList()
                }).First();
        }

        public DetailsEventViewModel GetEventDetails(int id)
        {
            var newEvent = context.Events
                .Where(e => e.Id == id)
                .Select(e => new DetailsEventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    CreatedOn = e.CreatedOn,
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name,
                }).First();
            return newEvent;
        }
    }
}