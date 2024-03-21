using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Models;

namespace PhoneStoreBackend.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
