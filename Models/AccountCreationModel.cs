using System.ComponentModel.DataAnnotations;

namespace GDBank.Models;

public class AccountCreationModel
{
    [Required(ErrorMessage = "Please provide your full name")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Please provide a valid email")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Please provide a valid password")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    public string? ConfirmPassword { get; set; }
}