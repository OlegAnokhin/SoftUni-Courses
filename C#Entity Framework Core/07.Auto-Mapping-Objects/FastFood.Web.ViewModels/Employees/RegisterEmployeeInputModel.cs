using System.ComponentModel.DataAnnotations;
using FastFood.Common.EntityConfiguration;

namespace FastFood.Web.ViewModels.Employees;

public class RegisterEmployeeInputModel
{
    [MinLength(EntitiesValidation.EmployeeNameMinLength)]
    [MaxLength(EntitiesValidation.EmployeeNameMaxLength)]
    public string Name { get; set; } = null!;

    [Range(15, 80)]
    public int Age { get; set; }

    public int PositionId { get; set; }

    public string PositionName { get; set; } = null!;

    [MinLength(EntitiesValidation.EmployeeAddressMinLength)]
    [MaxLength(EntitiesValidation.EmployeeAddressMaxLength)]
    public string Address { get; set; } = null!;
}