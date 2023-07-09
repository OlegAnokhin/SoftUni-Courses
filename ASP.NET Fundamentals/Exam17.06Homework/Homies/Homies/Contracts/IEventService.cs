namespace Homies.Contracts
{
    using Models.Event;
    using Models.Type;

    public interface IEventService
    {
        Task<List<AllTypesModel>> GetAllTypesAsync();

        Task<List<JoinedEventsViewModel>> GetJoinedEventsAsync(string userId);

        Task<EventViewModel> GetEventById(int id);

        Task JoinToEvent(string userId, EventViewModel model);

        Task LeaveFromEvent(string userId, EventViewModel model);

        Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync();

        Task CreateTaskAsync(EventFormModel model);

        Task EditEventAsync(int id, EventFormModel model);

        EventFormModel GetEventFormModel(int id);

        DetailsEventViewModel GetEventDetails(int id);
    }
}