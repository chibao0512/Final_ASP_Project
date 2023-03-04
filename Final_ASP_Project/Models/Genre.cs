using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_ASP_Project.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int genre_Id { get; set; }
        [Required]
        [Display(Name = "genre_Name")]
        public string genre_Name { get; set; }
        [Required]
        [Display(Name = "genre_Description")]
        public string genre_Description { get; set; }
        public string? genre_Status { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
