namespace FastFood.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Web.ViewModels.Employees;

    public interface IEmployeeService
    {
        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();
    }
}
