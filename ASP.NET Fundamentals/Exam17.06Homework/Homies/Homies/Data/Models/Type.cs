﻿#nullable disable
namespace Homies.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static Homies.Common.ValidationConstants.Type;

    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        public List<Event> Events { get; set; } = new List<Event>();
    }
}