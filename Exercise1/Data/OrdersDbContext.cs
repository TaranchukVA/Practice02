using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Exercise1
{
    public class OrdersDbContext : DbContext
    {
        public OrdersDbContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string appsettingsPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;


            var config = new ConfigurationBuilder()
               .SetBasePath(appsettingsPath)
               .AddJsonFile("appsettings.json")
               .Build();
            optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Customers> Customers { get; set; }
        public DbSet<Purchases> Purchses { get; set; }
        public DbSet<OrderedProducts> OrderedProducts { get; set; }
    }
}
