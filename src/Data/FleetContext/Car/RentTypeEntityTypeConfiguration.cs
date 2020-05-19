using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public sealed class RentTypeEntityTypeConfiguration : IEntityTypeConfiguration<RentType>
    {
        public void Configure(EntityTypeBuilder<RentType> builder)
        {
            builder.ToTable("RentType", FleetContext.SCHEMA);
            builder.HasKey(b => b.Name);
            
            builder.Property<int>("BonusOnRent").HasColumnName("BonusOnRent").IsRequired();
            builder.Property<TimeSpan>("DiscountAfter").HasColumnName("DiscountAfter").IsRequired();
            builder.Property<decimal>("Discount").HasColumnName("Discount").IsRequired();

            builder
                .HasOne(model => model.PricePolicy)
                .WithMany(e => e.RentTypes)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}