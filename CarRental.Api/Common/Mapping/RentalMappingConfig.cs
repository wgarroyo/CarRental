using CarRental.Contracts.Rentals;
using CarRental.Domain.RentalAggregate;
using Mapster;

namespace CarRental.Api.Common.Mapping
{
    public class RentalMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Rental, RentalResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.VehicleType, src => src.Vehicle.VehicleType.Description)
                .Map(dest => dest.VehicleBrand, src => src.Vehicle.VehicleBrand.Description)
                .Map(dest => dest.VehicleDescription, src => src.Vehicle.Description)
                .Map(dest => dest.VehicleVin, src => src.Vehicle.Vin)
                .Map(dest => dest.ClientName, src => src.Client.Name)
                .Map(dest => dest.ClientLastName, src => src.Client.LastName)
                .Map(dest => dest.ClientSocialNumberId, src => src.Client.SocialNumberId)
                .Map(dest => dest.Price, src => src.Price)
                .Map(dest => dest.From, src => src.From)
                .Map(dest => dest.To, src => src.To);
        }
    }
}