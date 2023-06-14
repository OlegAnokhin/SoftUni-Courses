using Gallery.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Gallery.Models;

namespace Gallery.Controllers
{
    [Authorize]
    public class PictureController : Controller
    {
        private readonly IPictureService pictureService;

        public PictureController(IPictureService pictureService)
        {
            this.pictureService = pictureService;
        }

        protected string GetUserId()
        {
            string id = string.Empty;

            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            return id;
        }
        public async Task<IActionResult> All()
        {
            var model = await pictureService.GetAllPicAsync();
            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await pictureService.GetMyPicturesAsync(GetUserId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddPicViewModel model = await pictureService.GetCategoriesForAddNewPictureAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPicViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await pictureService.AddPicAsync(model);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var pic = await pictureService.GetPicByIdAsync(id);
            if (pic == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();
            await pictureService.AddOrRemovePicToCollectionAsync(userId, pic);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var pic = await pictureService.GetPicByIdAsync(id);
            if (pic == null)
            {
                return RedirectToAction(nameof(Mine));
            }
            var userId = GetUserId();
            await pictureService.RemovePicFromCollectionAsync(userId, pic);
            return RedirectToAction(nameof(Mine));
        }
    }
}
