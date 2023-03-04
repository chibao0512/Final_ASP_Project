using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Book_Id { get; set; }
        [Required]
        public string Book_Title { get; set; }
        [Required]
        public string Book_Author { get; set; }
        [Required]
        public decimal Book_Price { get; set; }
        [Required]
        public int Book_Quantity { get; set; }               // so luong nhap kho
        public string Book_Publisher { get; set; }
        public string Book_Description { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public string? urlImage { get; set; }
        public int Gen_Id { get; set; }
        [ForeignKey("Gen_Id")]
        public virtual Genre? genre { get; set; }
    }
}
