﻿using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Models.Enums;

namespace P01_StudentSystem.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "varchar(2048)")]
        public string Url { get; set; }
        public ResourceType ResourceType { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
