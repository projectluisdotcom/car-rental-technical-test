using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public sealed class CarModelEntityTypeConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.ToTable("CarModel", FleetContext.SCHEMA);
            builder.HasKey(b => b.Name);
            
            builder.Property<string>("Brand").HasColumnName("Brand").IsRequired();

            builder
                .HasOne(model => model.RentType)
                .WithMany(e => e.CarModels)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}