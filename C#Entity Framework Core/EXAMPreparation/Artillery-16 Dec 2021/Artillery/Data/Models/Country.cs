namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            this.CountriesGuns = new List<CountryGun>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(60)]
        public string CountryName { get; set; }

        [Required]
        [Range(50000, 10000000)]
        public int ArmySize { get; set; }

        public virtual List<CountryGun> CountriesGuns { get; set; }
    }
}