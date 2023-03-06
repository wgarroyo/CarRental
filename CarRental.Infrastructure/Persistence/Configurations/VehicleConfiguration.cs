using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.ToTable("Vehicles");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => VehicleId.Create(value));

        builder.Property(m => m.VehicleTypeId)
            .HasConversion(
                id => id.Value,
                value => VehicleTypeId.Create(value));

        builder.Property(m => m.VehicleBrandId)
            .HasConversion(
                id => id.Value,
                value => VehicleBrandId.Create(value));

        builder.Property(m => m.Price)
            .HasPrecision(10, 3);

        builder.Property(m => m.Description)
            .HasMaxLength(100);

        builder.Property(m => m.WheelsNumber)
            .HasPrecision(1, 0);

        builder.Property(m => m.Vin)
            .HasMaxLength(10);
        
        builder.HasOne(x=> x.VehicleType)
            .WithMany(x=> x.Vehicles)
            .HasForeignKey(m => m.VehicleTypeId);

        builder.HasOne(x => x.VehicleBrand)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(m => m.VehicleBrandId);
    }
}
