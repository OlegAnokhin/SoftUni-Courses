using System.ComponentModel.DataAnnotations.Schema;
using FastFood.Common.EntityConfiguration;

namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Item
{
    public Item()
    {
        this.Id = Guid.NewGuid().ToString();
        this.OrderItems = new HashSet<OrderItem>();
    }
    [Key]
    // [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string Id { get; set; }

    [MaxLength(EntitiesValidation.ItemMaxLength)]
    public string? Name { get; set; }

    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}