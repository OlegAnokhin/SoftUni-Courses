using Gallery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Gallery.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("All", "Picture");
        }
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}