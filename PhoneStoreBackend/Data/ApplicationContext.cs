using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Models;
using BCrypt.Net;

namespace PhoneStoreBackend.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetails>()
                .HasKey(od => new { od.OrderDetailsID, od.ProductId });
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<OrderStatus> OrderStatuses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public async Task Initialize(ApplicationContext context)
        {
            var roles = new List<Role>
    {
                new Role
        {
            RoleId = 2,
            RoleName = "Администратор магазина"
        },
        new Role
        {
            RoleId = 2,
            RoleName = "Администратор магазина"
        },
        new Role
        {
            RoleId = 1,
            RoleName = "Пользователь"
        }
    };

            foreach (var role in roles)
            {
                if (!context.Roles.Any(r => r.RoleName == role.RoleName))
                {
                    context.Roles.Add(role);
                }
            }


            var orderStatuses = new List<OrderStatus>
    {
        new OrderStatus
        {
            OrderStatusId = 1,
            OrderStatusName = "В ожидании"
        },
        new OrderStatus
        {
            OrderStatusId = 2,
            OrderStatusName = "Закончен"
        }
    };

            foreach (var status in orderStatuses)
            {
                if (!context.OrderStatuses.Any(os => os.OrderStatusName == status.OrderStatusName))
                {
                    context.OrderStatuses.Add(status);
                }
            }

            var adminUser = new User
            {
                UserId = 1,
                UserName = "admin",
                Email = "admin@mail.ru",
                RoleId = 2
            };

            if (!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                adminUser.Password = BCrypt.Net.BCrypt.HashPassword("123456!");

                context.Users.Add(adminUser);

                var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Admin");
                if (adminRole != null)
                {
                    adminUser.Role = adminRole;
                }
            }

            await context.SaveChangesAsync();

            var user = await context.Users.FirstOrDefaultAsync(u => u.UserId == 1);
            if (user != null)
            {
                var adminRole = await context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Admin");
                if (adminRole != null)
                {
                    if (user.RoleId != adminRole.RoleId)
                    {
                        user.RoleId = adminRole.RoleId;
                        await context.SaveChangesAsync();
                    }
                }
            }
        }

    }
}
