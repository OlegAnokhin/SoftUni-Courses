using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(@"\d{4}\s\d{4}\s\d{4}\s\d{4}")]
        //[RegularExpression(@"^(\\d{4})\\s(\\d{4})\\s(\\d{4})\\s(\\d{4})$")]
        public string Number { get; set; } = null!;

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^(\d{3})$")]
        [JsonProperty("CVC")]
        public string Cvc { get; set; } = null!;

        [Required]
        public string Type { get; set; } = null!;
    }
}