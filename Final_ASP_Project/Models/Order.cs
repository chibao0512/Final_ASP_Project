using Final_ASP_Project.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Final_ASP_Project.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required, Display(Name = "Create Date")]
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        public List<OrderDetail> OrderDetails { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser? ApplicationUsers { get; set; }
    }
}
