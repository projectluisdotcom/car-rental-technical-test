using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public sealed class CustomerEntityTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", FleetContext.SCHEMA);
                
            builder.HasKey(o => o.Name);

            builder.OwnsMany<CarRent>("CarRents", carRental =>
            {
                carRental.ToTable("CarRental", FleetContext.SCHEMA);
                carRental.WithOwner().HasForeignKey("Name");
                carRental.HasKey("Name", "CarId");
                carRental.Property(c => c.CarId).HasColumnName("CardId").IsRequired();
                carRental.Property(c => c.Started).HasColumnName("Started").IsRequired();
                carRental.Property(c => c.ContractedEnd).HasColumnName("ContractedEnd").IsRequired();
                carRental.Property(c => c.ContractedPrice).HasColumnName("ContractedPrice").IsRequired();
                carRental.Property(c => c.Status).HasColumnName("Status").IsRequired();
                carRental.Property(c => c.BonusWon).HasColumnName("BonusWon").IsRequired();
                carRental.Property(c => c.End).HasColumnName("End").IsRequired();
                carRental.Property(c => c.PricePayed).HasColumnName("PricePayed").IsRequired();
            });
        }
    }
}