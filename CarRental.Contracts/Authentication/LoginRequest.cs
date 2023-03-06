using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Authentication;

public record LoginRequest(
    [Required, EmailAddress()] string Email,
    [DataType(DataType.Password), Required] string Password);
