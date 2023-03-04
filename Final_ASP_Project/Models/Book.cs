using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class Book
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int book_Id { get; set; }
        [Required]
        public string book_Title { get; set; }
        [Required]
        public DateTime publication_date { get; set; }
        public string? book_ImagURL { get; set; }
        [Required]
        public string book_Description { get; set; }
        [Required]
        public double book_Price { get; set; }
        [Required]
        public int book_Quantity { get; set; }
        public int genre_Id { get; set; }

        [ForeignKey("genre_Id")]
        public virtual Genre? genres { get; set; }

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }


        [NotMapped]
        public IFormFile? book_Img { get; set; }
    }
}
