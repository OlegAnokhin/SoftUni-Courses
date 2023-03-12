namespace FastFood.Web.Controllers;

using FastFood.Services.Data;
using ViewModels.Items;
using Microsoft.AspNetCore.Mvc;

public class ItemsController : Controller
{
    private readonly IItemServices itemServices;
    public ItemsController(IItemServices itemServices)
    {
        this.itemServices = itemServices;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        IEnumerable<CreateItemViewModel> availableCategories =
            await this.itemServices.GetAllAvailableCategoriesAsync();

        return View(availableCategories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateItemInputModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }

        await this.itemServices.CreateAsync(model);

        return this.RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<ItemsAllViewModel> items =
            await this.itemServices.GetAllAsync();

        return this.View(items.ToList());
    }
}