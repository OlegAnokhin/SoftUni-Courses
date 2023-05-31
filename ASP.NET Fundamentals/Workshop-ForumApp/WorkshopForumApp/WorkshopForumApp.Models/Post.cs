using System.ComponentModel.DataAnnotations;
using static WorkshopForumApp.Common.EntityValidations.Post;


namespace WorkshopForumApp.Models
{
    public class Post
    {
        public Post()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}