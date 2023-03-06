using CarRental.Domain.RentalAggregate;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence;

public class CarRentalDbContext : DbContext
{
    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    public DbSet<VehicleBrand> VehicleBrands { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CarRentalDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
