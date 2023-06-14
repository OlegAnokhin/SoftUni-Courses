using System.ComponentModel.DataAnnotations;

namespace Gallery.Data.Models;

public class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    public List<Picture> Pictures { get; set; } = new List<Picture>();
}