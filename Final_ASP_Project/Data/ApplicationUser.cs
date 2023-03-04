using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace Final_ASP_Project.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; }
        public DateTime DoB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public virtual ICollection<ShoppingCart>? ShoppingCarts { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
