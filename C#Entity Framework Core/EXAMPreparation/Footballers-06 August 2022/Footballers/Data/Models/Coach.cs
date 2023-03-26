﻿using System.ComponentModel.DataAnnotations;

namespace Footballers.Data.Models
{
    public class Coach
    {
        public Coach()
        {
            this.Footballers = new HashSet<Footballer>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false)] 
        public string Nationality { get; set; }

        public ICollection<Footballer> Footballers { get; set; }
    }
}