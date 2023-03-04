using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }



        [ForeignKey("BookId")]
        public virtual Book? Book { get; set; }

        [ForeignKey("ShoppingCartId")]
        public ShoppingCart ShoppingCart { get; set; }
    }
}
