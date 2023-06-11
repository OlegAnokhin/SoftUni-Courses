using Library.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Library.Models;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
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
            var model = await bookService.GetAllAsync();
            return View(model);
        }
        
        public async Task<IActionResult> Mine()
        {
            var model = await bookService.GetMyBooksAsync(GetUserId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel model = await bookService.GetCategoriesForAddNewBookAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            var userId = GetUserId();
            await bookService.AddBookToCollectionAsync(userId, book);
            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(Mine));
            }

            var userId = GetUserId();
            await bookService.RemoveBookFromCollectionAsync(userId, book);
            return RedirectToAction(nameof(Mine));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddBookViewModel? book = await bookService.GetBookByIdForEditAsync(id);
            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddBookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await bookService.EditBookAsync(model, id);
            return RedirectToAction(nameof(All));
        }
    }
}