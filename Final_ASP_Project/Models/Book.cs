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
        public DateTime publication_date { get; set; } = DateTime.UtcNow;
        public string book_Author { get; set; }
        [Required]
        public double Book_Price { get; set; }
        [Required]
        public int book_Quantity { get; set; }// so luong trong kho
        public string book_Publisher { get; set; }
        public string book_Description { get; set; }
        
        
        public string? book_urlImage { get; set; }
        public int genre_Id { get; set; }
        [ForeignKey("genre_Id")]
        public virtual Genre? genre { get; set; }
        public virtual ICollection<OrderDetail>? OrderDetails { get; set; }
        [NotMapped]
        public IFormFile? book_Img { get; set; }
    }
}
