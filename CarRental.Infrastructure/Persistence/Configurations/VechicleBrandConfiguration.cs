using CarRental.Domain.VehicleAggregate.Entities;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations;

public class VechicleBrandConfiguration : IEntityTypeConfiguration<VehicleBrand>
{
    public void Configure(EntityTypeBuilder<VehicleBrand> builder)
    {
        builder.ToTable("VehicleBrands");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => VehicleBrandId.Create(value));

        builder.Property(m => m.Description)
            .HasMaxLength(100);
    }
}
