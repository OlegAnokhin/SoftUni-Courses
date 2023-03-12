using AutoMapper;
using FastFood.Data;
using FastFood.Services.Data;
using FastFood.Web.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers;

public class CategoriesController : Controller
{
    private readonly ICategoryService categoriaService;

    public CategoriesController(ICategoryService categoriaService)
    {
        this.categoriaService = categoriaService;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryInputModel model)
    {
        if (this.ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }

        await this.categoriaService.CreateAsync(model);

        return this.RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<CategoryAllViewModel> categories =
            await this.categoriaService.GetAllAsync();
        return this.View(categories.ToList());
    }
}