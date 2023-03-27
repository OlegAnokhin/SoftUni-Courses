namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using Data.Common;
    using System.ComponentModel.DataAnnotations;

    public class ImportDepatmentCellDto
    {
        [Range(ValidationConstants.CellNumberMinValue, ValidationConstants.CellNumberMaxValue)]
        [JsonProperty(nameof(CellNumber))]
        public int CellNumber { get; set; }

        [JsonProperty(nameof(HasWindow))]
        public bool HasWindow { get; set; }
    }
}