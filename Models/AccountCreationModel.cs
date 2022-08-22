namespace GDBank.Models;

public class AccountCreationModel
{
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? ConfirmPassword { get; set; }

    public AccountCreationModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
}