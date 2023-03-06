using CarRental.Domain.RentalAggregate;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Infrastructure.Persistence;

public class CarRentalDbContext : DbContext
{
    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
        : base(options)
    {

    }

    public DbSet<Rental> Rentals { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CarRentalDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
