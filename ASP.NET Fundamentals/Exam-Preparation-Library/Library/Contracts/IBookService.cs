using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllAsync();
        Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string userId);
        Task<AddBookViewModel> GetCategoriesForAddNewBookAsync();
        Task AddBookAsync(AddBookViewModel model);
        Task AddBookToCollectionAsync(string userId, AddBookToCollectionViewModel book);
        Task<AddBookToCollectionViewModel> GetBookByIdAsync(int id);
        Task RemoveBookFromCollectionAsync(string userId, AddBookToCollectionViewModel book);
        Task EditBookAsync(AddBookViewModel model, int id);
        Task<AddBookViewModel> GetBookByIdForEditAsync(int id);
    }
}