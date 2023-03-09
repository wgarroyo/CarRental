using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.Entities;
using CarRental.Domain.UserAggregate;
using CarRental.Domain.VehicleAggregate;
using CarRental.Domain.VehicleAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Common.Interfaces.Persistence;

public interface IDataContext
{
    DbSet<Rental> Rentals { get; set; }
    DbSet<Vehicle> Vehicles { get; set; }
    DbSet<VehicleType> VehicleTypes { get; set; }
    DbSet<VehicleBrand> VehicleBrands { get; set; }
    DbSet<Client> Clients { get; set; }
    DbSet<User> Users { get; set; }

    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}
