using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.RentalAggregate.ValueObjects;
using CarRental.Domain.VehicleAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Infrastructure.Persistence.Configurations;

public class ClientConfigurations : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ClientId.Create(value));

        builder.Property(m => m.Name)
            .HasMaxLength(100);

        builder.Property(m => m.MiddleName)
            .HasMaxLength(100);

        builder.Property(m => m.LastName)
            .HasMaxLength(100);
    }
}
