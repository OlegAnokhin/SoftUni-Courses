﻿using System.ComponentModel.DataAnnotations.Schema;

namespace FastFood.Models;

using FastFood.Common.EntityConfiguration;
using System.ComponentModel.DataAnnotations;

public class OrderItem
{
    [ForeignKey(nameof(Order))]
    // [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string OrderId { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;

    [ForeignKey(nameof(Item))]
    // [MaxLength(EntitiesValidation.GuidMaxLength)]
    public string ItemId { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Quantity { get; set; }
}