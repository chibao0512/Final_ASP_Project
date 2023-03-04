using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_ASP_Project.Models
{
    public class Genre
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Gen_Id { get; set; }
        [Required]
        public string Gen_Name { get; set; }
        public string Gen_Description { get; set; }
        public virtual ICollection<Book>? books { get; set; }

    }
}
