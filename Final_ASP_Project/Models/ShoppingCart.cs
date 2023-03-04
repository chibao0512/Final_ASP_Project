using Final_ASP_Project.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class ShoppingCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string UserId { get; set; }

        public ICollection<Cart> Carts { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUsers { get; set; }
    }
}
