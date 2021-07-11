using Infrastructure.Data.Models.Car;
using Infrastructure.Data.Models.Warehouse;
using Infrastructure.Data.Seed.Warehouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
//migrations are generated from the Infrastructure project using the command:
//dotnet ef --startup-project ../API/ migrations add InitialCreate -o Data/Migrations
//dotnet ef --startup-project ../API/ database update

namespace Infrastructure.Data.Configuration
{
    public class CarsDbContext : DbContext
    {
        readonly IConfiguration Configuration;

        public CarsDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("Default"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new WarehouseConfiguration());
            WarehousesAndCarsSeeder.Seed(modelBuilder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
    }
}