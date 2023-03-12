using AutoMapper;
using FastFood.Data;
using FastFood.Web.ViewModels.Employees;

namespace FastFood.Services.Data

{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper mapper;
        private readonly FastFoodContext context;

        public EmployeeService(IMapper mapper, FastFoodContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task RegisterAsync(RegisterEmployeeInputModel model)
        {
            throw new NotImplementedException();
        }
    }
}
