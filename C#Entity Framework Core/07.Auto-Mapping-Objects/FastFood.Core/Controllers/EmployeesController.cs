using FastFood.Services.Data;

namespace FastFood.Web.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Data;
using ViewModels.Employees;

public class EmployeesController : Controller
{
    private readonly IEmployeeService employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        this.employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        //throw new NotImplementedException();

        IEnumerable<RegisterEmployeeViewModel> registerEmployee =
            await this.employeeService.AddEmployeeInPositionAsync();
        return View(registerEmployee);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterEmployeeInputModel model)
    {
        if (!ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }
        await this.employeeService.RegisterAsync(model);

        return this.RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        IEnumerable<EmployeesAllViewModel> employees =
            await this.employeeService.GetAllAsync();

        return View(employees.ToList());
    }
}