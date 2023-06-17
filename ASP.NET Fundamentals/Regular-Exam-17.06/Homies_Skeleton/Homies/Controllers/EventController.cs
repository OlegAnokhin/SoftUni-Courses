using Homies.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Homies.Models;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
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
            var model = await eventService.GetAllAsync();
            return View(model);
        }

        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetMyJoindedEventsAsync(GetUserId());
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddEventViewModel model = await eventService.GetTypesForAddNewBookAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await eventService.AddEventAsync(model);
            return RedirectToAction(nameof(All));
        }
    }
}
