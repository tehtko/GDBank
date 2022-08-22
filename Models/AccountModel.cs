namespace GDBank.Models;

public class AccountModel
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public AccountModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
}