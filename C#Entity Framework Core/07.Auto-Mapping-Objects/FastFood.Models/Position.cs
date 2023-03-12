﻿using FastFood.Common.EntityConfiguration;

namespace FastFood.Models;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Position
{
    public Position()
    {
        this.Employees = new HashSet<Employee>();
    }
    [Key]
    public int Id { get; set; }

    [MaxLength(EntitiesValidation.PositionMaxLength)]
    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; }
}