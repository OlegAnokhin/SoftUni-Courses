﻿// <auto-generated />
using System;
using Forum.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum.Data.Migrations
{
    [DbContext(typeof(ForumDbContext))]
    [Migration("20230627171145_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Forum.Data.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1500)
                        .HasColumnType("nvarchar(1500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b1e149e9-a094-4104-bf1a-c1b5b14917d4"),
                            Content = "I SAY first post",
                            Title = "My first post"
                        },
                        new
                        {
                            Id = new Guid("ce5e9820-5d42-4ebf-aec7-b9b56d0b973c"),
                            Content = "I SAY second post",
                            Title = "My second post"
                        },
                        new
                        {
                            Id = new Guid("543b7fc1-a704-4fc1-b3d6-0868c75aac8e"),
                            Content = "I SAY third post",
                            Title = "My thitd post"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
