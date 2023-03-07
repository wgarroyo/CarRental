using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Clients;

public record AddClientRequest(
 string Email,
string Password);
