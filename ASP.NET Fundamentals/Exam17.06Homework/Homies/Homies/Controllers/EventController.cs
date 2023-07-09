namespace Homies.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Security.Claims;
    using Contracts;
    using Models.Event;

    public class EventController : BaseController
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

        public async Task<IActionResult> Joined()
        {
            var model = await eventService.GetJoinedEventsAsync(GetUserId());

            return View(model);
        }

        public async Task<IActionResult> Join(int id)
        {
            var eventToJoin = await eventService.GetEventById(id);
            var model = await eventService.GetJoinedEventsAsync(GetUserId());

            if (model.Any(m => m.Id == id))
            {
                return RedirectToAction(nameof(All));
            }
            await eventService.JoinToEvent(GetUserId(), eventToJoin);

            return RedirectToAction(nameof(Joined));
        }

        public async Task<IActionResult> Leave(int id)
        {
            var eventToLeave = await eventService.GetEventById(id);
            await eventService.LeaveFromEvent(GetUserId(), eventToLeave);

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormModel()
            {
                Types = await eventService.GetAllTypesAsync()
            };
            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(EventFormModel model)
        {
            var types = await eventService.GetAllTypesAsync();

            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetAllTypesAsync();
                return View(model);
            }

            if (!types.Any(t => t.Id == model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist");
            }
            try
            {
                var userId = GetUserId();
                model.OrganiserId = userId;
                await eventService.CreateTaskAsync(model);
                return RedirectToAction(nameof(All));
            }
            catch (Exception e)
            {
                model.Types = await eventService.GetAllTypesAsync();
                ModelState.AddModelError("", e.Message);
                return View(model);
            }
        }

        public IActionResult Details(int id)
        {
            var model = eventService.GetEventDetails(id);

            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = eventService.GetEventFormModel(id);
            var user = GetUserId();
            if (user != model.OrganiserId)
            {
                return Unauthorized();
            }

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, EventFormModel model)
        {
            if (!eventService.GetAllTypesAsync().Result.Any(t => t.Id == model.TypeId))
            {
                ModelState.AddModelError(nameof(model.TypeId), "Type does not exist!");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await eventService.GetAllTypesAsync();
               // model.Types = eventService.GetAllTypesAsync().Result;
               return View(model);
            }

            await eventService.EditEventAsync(id, model);
            return RedirectToAction(nameof(All));
        }
    }
}
