using Microsoft.EntityFrameworkCore;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("ECommercePlatform");
        }
    }
}
