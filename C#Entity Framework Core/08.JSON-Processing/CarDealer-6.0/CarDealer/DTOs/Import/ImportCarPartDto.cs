using CarDealer.Models;

namespace CarDealer.DTOs.Import
{
    using Newtonsoft.Json;

    public class ImportCarPartDto
    {
        //[JsonProperty("partId")]
        public int[] PartsId { get; set; }
    }
}