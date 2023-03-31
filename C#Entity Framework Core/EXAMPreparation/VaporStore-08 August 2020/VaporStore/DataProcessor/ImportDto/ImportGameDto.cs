using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportGameDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public string ReleaseDate { get; set; } = null!;

        [Required]
        public string Developer { get; set; } = null!;

        [Required]
        public string Genre { get; set; } = null!;

        public string[] Tags { get; set; }
    }
}