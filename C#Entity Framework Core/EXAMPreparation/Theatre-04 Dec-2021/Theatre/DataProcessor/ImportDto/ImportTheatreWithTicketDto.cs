namespace Theatre.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ImportTheatreWithTicketDto
    {
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [JsonProperty("Name")]
        public string Name { get; set; }

        [Required]
        [Range(typeof(sbyte), "1", "10")]
        [JsonProperty("NumberOfHalls")]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        [JsonProperty("Director")]
        public string Director { get; set; }

        [JsonProperty("Tickets")]
        public List<ImportTicketsFromTheatreDto> Tickets { get; set; }
    }
}