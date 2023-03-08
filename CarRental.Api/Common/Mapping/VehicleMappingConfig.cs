using CarRental.Application.Vehicles.Commands.AddVehicle;
using CarRental.Contracts.Vehicles;
using CarRental.Domain.VehicleAggregate;
using Mapster;

namespace CarRental.Api.Common.Mapping
{
    public class VehicleMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<AddVehicleRequest, AddVehicleCommand>();

            config.NewConfig<Vehicle, VehicleResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Type, src => src.VehicleType.Description)
                .Map(dest => dest.Brand, src => src.VehicleBrand.Description)
                .Map(dest => dest.Description, src => src.Description)
                .Map(dest => dest.WheelsNumber, src => src.WheelsNumber)
                .Map(dest => dest.Vin, src => src.Vin)
                .Map(dest => dest.Price, src => src.Price);
        }
    }
}