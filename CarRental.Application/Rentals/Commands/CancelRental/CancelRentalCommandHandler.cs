using CarRental.Application.Common.Interfaces.Persistence;
using CarRental.Domain.Common.Errors;
using CarRental.Domain.RentalAggregate;
using CarRental.Domain.RentalAggregate.ValueObjects;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Application.Rentals.Commands.CancelRental
{
    internal class CancelRentalCommandHandler : IRequestHandler<CancelRentalCommand, ErrorOr<Rental>>
    {
        private readonly IDataContext _dataContext = null!;
        public CancelRentalCommandHandler(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ErrorOr<Rental>> Handle(CancelRentalCommand command, CancellationToken cancellationToken)
        {
            Rental? rental = await _dataContext
               .Rentals
               .FirstOrDefaultAsync(x => x.Id == RentalId.Create(command.Id), cancellationToken);

            if (rental is null)
            {
                return Errors.Rental.NotFound;
            }

            _dataContext.Rentals.Remove(rental);
            await _dataContext.CommitAsync();

            return rental;
        }
    }
}
