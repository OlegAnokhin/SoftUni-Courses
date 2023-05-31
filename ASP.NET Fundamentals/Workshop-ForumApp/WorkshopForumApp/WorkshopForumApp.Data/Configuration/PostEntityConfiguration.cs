using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkshopForumApp.Common;
using WorkshopForumApp.Data.Seeding;
using WorkshopForumApp.Models;

namespace WorkshopForumApp.Data.Configuration;

public class PostEntityConfiguration : IEntityTypeConfiguration<EntityValidations.Post>
{
    private readonly PostSeeder postSeeder;

    public PostEntityConfiguration()
    {
        this.postSeeder = new PostSeeder();
    }

    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasData(this.postSeeder.GeneratePosts());
    }
}