using System.ComponentModel.DataAnnotations;

namespace Final_ASP_Project.Models
{
    public class OrderDetail
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]


        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
        public Book Book { get; set; }
    }
}
