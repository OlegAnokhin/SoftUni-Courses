namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Manufacturer
    {
        public Manufacturer()
        {
            this.Guns = new List<Gun>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(40)]
        public string ManufacturerName { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        public string Founded { get; set; }

        public virtual List<Gun> Guns { get; set; }
    }
}