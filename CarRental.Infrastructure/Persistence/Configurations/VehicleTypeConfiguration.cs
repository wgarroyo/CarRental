using CarRental.Domain.VehicleAggregate.Entities;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations;

public class VehicleTypeConfiguration : IEntityTypeConfiguration<VehicleType>
{
    public void Configure(EntityTypeBuilder<VehicleType> builder)
    {
        builder.ToTable("VehicleTypes");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => VehicleTypeId.Create(value));

        builder.Property(m => m.Description)
            .HasMaxLength(100);
     
    }
}
