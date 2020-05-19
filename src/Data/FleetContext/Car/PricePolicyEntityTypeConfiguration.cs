using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public sealed class PricePolicyEntityTypeConfiguration : IEntityTypeConfiguration<PricePolicy>
    {
        public void Configure(EntityTypeBuilder<PricePolicy> builder)
        {
            builder.ToTable("PricePolicy", FleetContext.SCHEMA);
            builder.HasKey(b => b.Name);
            
            builder.Property<int>("Price").HasColumnName("Price").IsRequired();
        }
    }
}