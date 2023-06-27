using System.Security.Claims;
using Homies.Contracts;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService eventService;
        private string GetUserId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public async Task<IActionResult> All()
        {
            var model = await eventService.GetAllEventsAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddEventViewModel()
            {
                Types = await eventService.GetAllTypesAsync()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetAllTypesAsync();
                return View(model);
            }

            try
            {
                var userId = GetUserId();
                model.OrganiserId = userId;
                await eventService.AddEventAsync(model, userId);
            }
            catch (Exception e)
            {
                model.Types = await eventService.GetAllTypesAsync();
                ModelState.AddModelError("", e.Message);
                return View(model);
            }

            return RedirectToAction(nameof(All));
        }
    }
}
