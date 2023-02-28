using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Models
{
    public class Student
    {
        public Student()
        {
            Homeworks = new HashSet<Homework>();
            Courses = new HashSet<Course>();
            //StudentsCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Column(TypeName = "char(10)")]
        public string? PhoneNumber { get; set; }
        public bool RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }

        //public ICollection<StudentCourse> StudentsCourses { get; set; }
    }
}
