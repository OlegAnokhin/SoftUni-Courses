namespace FastFood.Services.Data
{
    using Web.ViewModels.Employees;

    public interface IEmployeeService
    {
        Task RegisterAsync(RegisterEmployeeInputModel model);

        Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();

        Task<IEnumerable<RegisterEmployeeViewModel>> AddEmployeeInPositionAsync();

    }
}
