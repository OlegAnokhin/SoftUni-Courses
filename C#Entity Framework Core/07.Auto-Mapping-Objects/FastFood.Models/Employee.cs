namespace FastFood.Models;

using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common.EntityConfiguration;

public class Employee
{
    public Employee()
    {
        this.Id = Guid.NewGuid().ToString();
        this.Orders = new HashSet<Order>();
    }
    [Key]
   // [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string Id { get; set; }

    [MinLength(ViewModelsValidation.EmployeeNameMinLength)]
    [MaxLength(ViewModelsValidation.EmployeeNameMaxLength)]
    public string Name { get; set; } = null!;

    [Range(15, 80)]
    public int Age { get; set; }

    [MinLength(ViewModelsValidation.EmployeeAddressMinLength)]
    [MaxLength(ViewModelsValidation.EmployeeAddressMaxLength)]
    public string Address { get; set; } = null!;

    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    public virtual Position Position { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; }
}