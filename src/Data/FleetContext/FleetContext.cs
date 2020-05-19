using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class FleetContext : DbContext
    {
        public const string SCHEMA = "Fleet";

        public FleetContext(DbContextOptions<FleetContext> contextOptions): base(contextOptions)
        {
        }
        
        public DbSet<Customer> Customers  { get; set; }
        public DbSet<CarRent> CarRents { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<RentType> RentTypes { get; set; }
        public DbSet<PricePolicy> PricePolicies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new CarModelEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new RentTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PricePolicyEntityTypeConfiguration());
        }
    }
}