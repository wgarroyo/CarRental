using CarRental.Application.Authentication.Commands.Register;
using CarRental.Application.Authentication.Common;
using CarRental.Application.Authentication.Queries.Login;
using CarRental.Contracts.Authentication;
using Mapster;

namespace CarRental.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token)
            .Map(dest => dest, src => src.User);
    }
}
