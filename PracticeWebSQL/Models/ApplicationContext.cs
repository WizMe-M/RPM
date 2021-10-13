using Microsoft.EntityFrameworkCore;

namespace PracticeWebSQL.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var adminRole = new Role { ID = 1, Name = "Админ" };
            var userRole = new Role { ID = 2, Name = "Пользователь" };
            var adminAccount = new Account()
            {
                ID = 1, 
                Email = "admin@mail.ru", 
                Login = "Admin",
                Password = "admin",
                RoleID = adminRole.ID
            };

            modelBuilder.Entity<Role>().HasData(adminRole, userRole);
            modelBuilder.Entity<Account>().HasData(adminAccount);
            base.OnModelCreating(modelBuilder);
        }
    }
}