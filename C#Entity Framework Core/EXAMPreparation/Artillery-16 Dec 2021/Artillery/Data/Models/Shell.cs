namespace Artillery.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Shell
    {
        public Shell()
        {
            this.Guns = new List<Gun>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(2, 1680)]
        public double ShellWeight { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Caliber { get; set; } = null!;

        public virtual List<Gun> Guns { get; set; } = null!;
    }
}