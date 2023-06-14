using Gallery.Contracts;
using Gallery.Data;
using Gallery.Data.Models;
using Gallery.Models;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Services
{
    public class PictureService : IPictureService
    {
        private readonly GalleryDbContext context;

        public PictureService(GalleryDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AllPicViewModel>> GetAllPicAsync()
        {
            return await context
                .Pictures
                .Select(book => new AllPicViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ImageUrl = book.ImageUrl,
                    Rating = book.Rating,
                    Category = book.Category.Name,
                }).ToListAsync();
        }

        public async Task<IEnumerable<MyPicturesViewModel>> GetMyPicturesAsync(string userId)
        {
            return await context.IdentityUserPictures
                .Where(up => up.CollectorId == userId)
                .Select(p => new MyPicturesViewModel
                {
                    Id = p.Picture.Id,
                    Title = p.Picture.Title,
                    Author = p.Picture.Author,
                    ImageUrl = p.Picture.ImageUrl,
                    Description = p.Picture.Description,
                    Category = p.Picture.Category.Name
                }).ToListAsync();
        }

        public async Task<AddPicViewModel> GetCategoriesForAddNewPictureAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            var model = new AddPicViewModel
            {
                Categories = categories
            };
            return model;
        }

        public async Task AddPicAsync(AddPicViewModel model)
        {
            Picture picture = new Picture
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                ImageUrl = model.Url,
                Rating = model.Rating,
                CategoryId = model.CategoryId
            };
            await context.Pictures.AddAsync(picture);
            await context.SaveChangesAsync();
        }

        public async Task<AddOrRemovePicToCollectionViewModel?> GetPicByIdAsync(int id)
        {
            return await context.Pictures
                .Where(p => p.Id == id)
                .Select(p => new AddOrRemovePicToCollectionViewModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    Author = p.Author,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Rating = p.Rating,
                    CategoryId = p.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task AddOrRemovePicToCollectionAsync(string userId, AddOrRemovePicToCollectionViewModel picModel)
        {
            bool alreadyAdded = await context.IdentityUserPictures
                .AnyAsync(up => up.CollectorId == userId && up.PictureId == picModel.Id);

            if (!alreadyAdded)
            {
                var picToAdd = new IdentityUserPicture
                {
                    CollectorId = userId,
                    PictureId = picModel.Id
                };
                await context.IdentityUserPictures.AddAsync(picToAdd);
                await context.SaveChangesAsync();
            }
        }

        public async Task RemovePicFromCollectionAsync(string userId, AddOrRemovePicToCollectionViewModel picture)
        {
            var userPic = await context.IdentityUserPictures
                .FirstOrDefaultAsync(up => up.CollectorId == userId && up.PictureId == picture.Id);

            if (userPic != null)
            {
                context.IdentityUserPictures.Remove(userPic);
                await context.SaveChangesAsync();
            }
        }
    }
}
