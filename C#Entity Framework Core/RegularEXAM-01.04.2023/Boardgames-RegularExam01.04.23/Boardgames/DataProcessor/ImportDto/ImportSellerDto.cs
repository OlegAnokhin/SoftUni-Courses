using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Boardgames.Common;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [Required]
        [MinLength(ValidationConstants.SellerNameMinLenght)]
        [MaxLength(ValidationConstants.SellerNameMaxLenght)]
        [JsonProperty("Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(ValidationConstants.SellerAddressMinLenght)]
        [MaxLength(ValidationConstants.SellerAddressMaxLenght)]
        [JsonProperty("Address")]
        public string Address { get; set; } = null!;

        [Required]
        [JsonProperty("Country")]
        public string Country { get; set; } = null!;

        [Required]
        [RegularExpression(ValidationConstants.SellerWebsiteRegex)]
        [JsonProperty("Website")]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")]
        public int[] BoardgameIds { get; set; }
    }
}