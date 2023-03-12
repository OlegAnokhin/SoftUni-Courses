using FastFood.Common.EntityConfiguration;

namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Category
{
    public Category()
    {
        this.Items = new HashSet<Item>();
    }
    [Key]
    public int Id { get; set; }

    [MinLength(ViewModelsValidation.CategoryNameMinLength)]
    [MaxLength(ViewModelsValidation.CategoryNameMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; }
}