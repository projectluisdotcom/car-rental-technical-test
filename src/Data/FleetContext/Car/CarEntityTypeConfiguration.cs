using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public sealed class CarEntityTypeConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Car", FleetContext.SCHEMA);
            builder.HasKey(b => b.License);
            
            builder.Property<bool>("IsFree").HasColumnName("IsFree").IsRequired();

            builder
                .HasOne(model => model.Model)
                .WithMany(e => e.Car)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}