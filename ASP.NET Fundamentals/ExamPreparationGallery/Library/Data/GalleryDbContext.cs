using Gallery.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Gallery.Data;

public class GalleryDbContext : IdentityDbContext
{
    public GalleryDbContext(DbContextOptions<GalleryDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityUserPicture>()
            .HasKey(up => new { up.PictureId, up.CollectorId });

        builder.Entity<Picture>()
            .Property(p => p.Rating)
            .HasPrecision(18, 2);

        //seeding
        builder
           .Entity<Picture>()
           .HasData(new Picture()
           {
               Id = 1,
               Title = "Lion",
               Author = "Petya Mitkova",
               ImageUrl = "https://images.unsplash.com/photo-1607490703747-0519d2e398a1?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxleHBsb3JlLWZlZWR8MTR8fHxlbnwwfHx8fHw%3D&w=1000&q=80",
               Description = "Akwarel prety picture.",
               CategoryId = 1,
               Rating = 9.5m
           });

        builder
       .Entity<Category>()
       .HasData(new Category()
       {
           Id = 1,
           Name = "Animals"
       },
       new Category()
       {
           Id = 2,
           Name = "People"
       },
       new Category()
       {
           Id = 3,
           Name = "Houses"
       },
       new Category()
       {
           Id = 4,
           Name = "Nature"
       },
       new Category()
       {
           Id = 5,
           Name = "Fantasy"
       });


        base.OnModelCreating(builder);
    }

    public DbSet<Picture> Pictures { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<IdentityUserPicture> IdentityUserPictures { get; set; }
}