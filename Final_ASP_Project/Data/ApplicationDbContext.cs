using Final_ASP_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_ASP_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingCart> carts { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OrderDetail>().HasKey(m => new { m.OrderId, m.BookId });
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                  new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "Admin" },
                  new IdentityRole { Id = "2", Name = "Owner", NormalizedName = "Owner" },
                  new IdentityRole { Id = "3", Name = "Customer", NormalizedName = "Customer" }
              );

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "1",
                    FullName = "ADMIN PROJECT",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@EXAMPLE.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@EXAMPLE.COM",
                    DoB = new DateTime(2002, 02, 02),
                    Gender = "M",
                    Address = "CAN THO",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    SecurityStamp = string.Empty
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "1", RoleId = "1" }
            );
        }
    }
}