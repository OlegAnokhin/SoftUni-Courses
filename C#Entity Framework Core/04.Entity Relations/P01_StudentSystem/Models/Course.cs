using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace P01_StudentSystem.Models
{
    public class Course
    {
        public Course()
        {
            Homeworks = new HashSet<Homework>();
            Resources = new HashSet<Resource>();
            Students = new HashSet<Student>();
           // StudentsCourses = new HashSet<StudentCourse>();
        }
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
