using Microsoft.EntityFrameworkCore;

namespace PracticeWebSQL.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
    }
}