using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Models.Enums;

namespace P01_StudentSystem.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }
        [Required]
        [Column(TypeName = "varchar(255)")]
        public string Content { get; set; }
        public ContentType ContentType {get; set;}
        public DateTime SubmissionTime { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
