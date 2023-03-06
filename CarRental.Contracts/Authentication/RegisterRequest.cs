using System.ComponentModel.DataAnnotations;

namespace CarRental.Contracts.Authentication;

public record RegisterRequest(
    [Required, MinLength(3), MaxLength(50)] string FirstName,
    [Required, MinLength(3), MaxLength(50)] string LastName,
    [Required, EmailAddress()] string Email,
    [DataType(DataType.Password), Required, MinLength(6), MaxLength(100)] string Password);

