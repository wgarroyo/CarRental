using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Clients;

public record AddClientRequest(
[Required, MinLength(3), MaxLength(100)] string FirstName,
[Required, MinLength(3), MaxLength(100)] string MiddleName,
[Required, MinLength(3), MaxLength(100)] string LastName,
[Required, MinLength(5), MaxLength(20)] string SocialNumberId);
