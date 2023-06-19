using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<List<AllTypesViewModel>> GetAllTypesAsync();
        Task<IEnumerable<AllEventsViewModel>> GetAllEventsAsync();
        Task AddEventAsync(AddEventViewModel model,  string organiserId);

    }
}
