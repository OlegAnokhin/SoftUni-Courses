namespace FastFood.Services.Data
{
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.ViewModels.Items;

    public interface IItemServices
    {
        Task CreateAsync(CreateItemInputModel model);

        Task<IEnumerable<ItemsAllViewModel>> GetAllAsync();

        Task<IEnumerable<CreateItemViewModel>> GetAllAvailableCategoriesAsync();
    }
}
