using System.ComponentModel.DataAnnotations;

namespace VaporStore.DataProcessor.ImportDto
{
    public class ImportUserDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string UserName { get; set; } = null!;

        [Required]
        //[RegularExpression(@"^([A-Z]{1}[a-z]+)\\s([A-Z]{1}[a-z]+)$")]
        [RegularExpression(@"[A-Z][a-z]+\s[A-Z][a-z]+")]
        public string FullName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        [Range(3, 103)]
        public int Age { get; set; }

        public ImportCardDto[] Cards { get; set; }
    }
}