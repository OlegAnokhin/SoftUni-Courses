using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext context;

        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AllBookViewModel>> GetAllAsync()
        {
            return await context
                .Books
                .Select(book => new AllBookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<MyBookViewModel>> GetMyBooksAsync(string userId)
        {
            return await context.IdentityUserBooks
                .Where(iub => iub.CollectorId == userId)
                .Select(b => new MyBookViewModel
                {
                    Id = b.Book.Id,
                    Title = b.Book.Title,
                    Author = b.Book.Author,
                    ImageUrl = b.Book.ImageUrl,
                    Description = b.Book.Description,
                    Category = b.Book.Category.Name
                }).ToListAsync();
        }

        public async Task<AddBookViewModel> GetCategoriesForAddNewBookAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var model = new AddBookViewModel
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };
            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, AddBookToCollectionViewModel book)
        {
            bool alreadyAdded = await context.IdentityUserBooks
                .AnyAsync(iub => iub.CollectorId == userId && iub.BookId == book.Id);
            if (!alreadyAdded)
            {
                var bookToAdd = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };
                await context.IdentityUserBooks.AddAsync(bookToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task<AddBookToCollectionViewModel?> GetBookByIdAsync(int id)
        {
            return await context.Books
                .Where(b => b.Id == id)
                .Select(b => new AddBookToCollectionViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    Description = b.Description,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task RemoveBookFromCollectionAsync(string userId, AddBookToCollectionViewModel book)
        {
            var userBook = await context.IdentityUserBooks
                .FirstOrDefaultAsync(iub => iub.CollectorId == userId && iub.BookId == book.Id);
            if (userBook != null)
            {
                context.IdentityUserBooks.Remove(userBook);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditBookAsync(AddBookViewModel model, int id)
        {
            var book = await context.Books.FindAsync(id);
            if (book != null)
            {
                book.Title = model.Title;
                book.Author = model.Author;
                book.ImageUrl = model.Url;
                book.Description = model.Description;
                book.Rating = model.Rating;
                book.CategoryId = model.CategoryId;

                await context.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel?> GetBookByIdForEditAsync(int id)
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            return await context.Books
                .Where(b => b.Id == id)
                .Select(b => new AddBookViewModel
                {
                    Title = b.Title,
                    Author = b.Author,
                    Url = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId,
                    Categories = categories
                }).FirstOrDefaultAsync();
        }
    }
}