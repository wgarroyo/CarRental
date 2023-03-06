using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations;

public class RentalConfigurations : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.ToTable("Rentals");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => RentalId.Create(value));

        builder.Property(m => m.ClientId)
            .HasConversion(
                id => id.Value,
                value => ClientId.Create(value));

        builder.Property(m => m.VehicleId)
            .HasConversion(
                id => id.Value,
                value => VehicleId.Create(value));

        builder.Property(m => m.Price)
            .HasPrecision(10, 3);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Rentals)
            .HasForeignKey(m => m.VehicleId);

        builder.HasOne(x => x.Client)
            .WithMany(x => x.Rentals)
            .HasForeignKey(m => m.ClientId);
    }
}
