using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarRental.Infrastructure.Persistence;

public class CarRentalDbContext : DbContext, IDataContext
{
    private IDbContextTransaction _transaction = null!;

    public CarRentalDbContext(DbContextOptions<CarRentalDbContext> options)
        : base(options)
    {
    }

    public DbSet<Rental> Rentals { get; set; } = null!;
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<VehicleType> VehicleTypes { get; set; } = null!;
    public DbSet<VehicleBrand> VehicleBrands { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(CarRentalDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await SaveChangesAsync();
            if (_transaction is not null)
                await _transaction.CommitAsync();
        }
        finally
        {
            if (_transaction is not null)
                await _transaction.DisposeAsync();
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }
    }

}
