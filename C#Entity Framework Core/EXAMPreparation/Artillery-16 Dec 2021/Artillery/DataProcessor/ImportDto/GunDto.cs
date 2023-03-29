namespace Artillery.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    public class GunDto
    {
        [Required]
        [JsonProperty("ManufacturerId")]
        public int ManufacturerId { get; set; }

        [Required]
        [Range(100, 1350000)]
        [JsonProperty("GunWeight")]
        public int GunWeight { get; set; }

        [Required]
        [Range(2.00, 35.00)]
        [JsonProperty("BarrelLength")]
        public double BarrelLength { get; set; }

        [JsonProperty("NumberBuild")]
        public int? NumberBuild { get; set; }

        [Required]
        [Range(1, 100000)]
        [JsonProperty("Range")]
        public int Range { get; set; }

        [Required]
        [JsonProperty("GunType")]
        public string GunType { get; set; }

        [JsonProperty("ShellId")]
        public int ShellId { get; set; }

        [JsonProperty("Countries")]
        public CountriesGunDto[] Countries { get; set; }
    }
}