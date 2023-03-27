namespace SoftJail.DataProcessor.ImportDto
{
    using Newtonsoft.Json;
    using Data.Common;
    using System.ComponentModel.DataAnnotations;


    public class ImportDepartmentWithCellsDto
    {
        [Required]
        [MinLength(ValidationConstants.DepartmentNameMinLength)]
        [MaxLength(ValidationConstants.DepartmentNameMaxLength)]
        [JsonProperty(nameof(Name))]
        public string Name { get; set; }

        [JsonProperty(nameof(Cells))]
        public ImportDepatmentCellDto[] Cells { get; set; }
    }
}