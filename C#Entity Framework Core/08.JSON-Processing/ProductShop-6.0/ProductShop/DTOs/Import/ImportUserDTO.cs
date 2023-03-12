namespace ProductShop.DTOs.Import
{
    using Newtonsoft.Json;
    using System.Text.Json.Serialization;

    public class ImportUserDTO
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; } = null!;

        [JsonProperty("lastName")]
        public string LastName { get; set; } = null!;

        [JsonProperty("age")]
        public int?  Age { get; set; }
    }
}
