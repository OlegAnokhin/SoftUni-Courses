using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Gallery.Data.Models;

public class IdentityUserPicture
{
    public string CollectorId { get; set; } = null!;

    [ForeignKey(nameof(CollectorId))]
    public IdentityUser Collector { get; set; } = null!;

    public int PictureId { get; set; }

    [ForeignKey(nameof(PictureId))]
    public Picture Picture { get; set; } = null!;
}