using CarRental.Contracts.Clients;
using CarRental.Domain.RentalAggregate.Entities;
using Mapster;

namespace CarRental.Api.Common.Mapping
{
    public class ClientMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Client, ClientResponse>()
                .Map(dest => dest.Id, src => src.Id.Value)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.MiddleName, src => src.MiddleName)
                .Map(dest => dest.LastName, src => src.LastName)
                .Map(dest => dest.SocialNumberId, src => src.SocialNumberId);
        }
    }
}
