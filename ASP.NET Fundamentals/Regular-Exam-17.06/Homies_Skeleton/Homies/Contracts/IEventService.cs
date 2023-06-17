using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventsViewModel>> GetAllAsync();
        Task<IEnumerable<JoinedEventsViewModel>> GetMyJoindedEventsAsync(string userId);
        Task<AddEventViewModel> GetTypesForAddNewBookAsync();
        Task AddEventAsync(AddEventViewModel model);

    }
}
