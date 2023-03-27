namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class ImportPrisonerMailDto
    {
        [Required]
        [JsonProperty(nameof(Description))]
        public string Description { get; set; }

        [Required]
        [JsonProperty(nameof(Sender))]
        public string Sender { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.MailAddressRegex)]
        [JsonProperty(nameof(Address))]
        public string Address { get; set; }
    }
}
