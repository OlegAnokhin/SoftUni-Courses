using Gallery.Models;

namespace Gallery.Contracts
{
    public interface IPictureService
    {
        Task<IEnumerable<AllPicViewModel>> GetAllPicAsync();
        Task<IEnumerable<MyPicturesViewModel>> GetMyPicturesAsync(string userId);
        Task<AddPicViewModel> GetCategoriesForAddNewPictureAsync();
        Task AddPicAsync(AddPicViewModel model);
        Task<AddOrRemovePicToCollectionViewModel> GetPicByIdAsync(int id);
        Task AddOrRemovePicToCollectionAsync(string userId, AddOrRemovePicToCollectionViewModel picModel);
        Task RemovePicFromCollectionAsync(string userId, AddOrRemovePicToCollectionViewModel picture);

    }
}
