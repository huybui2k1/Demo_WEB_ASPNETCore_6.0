using Microsoft.EntityFrameworkCore;

namespace MyCodeFirstApprochDemo.Models
{
    public class CustomerContext : DbContext
    {
       // public CustomerContext() { }
        public DbSet<Customer> Customer { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DemoWAD"));
        }
    }
}
