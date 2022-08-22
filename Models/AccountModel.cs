namespace GDBank.Models;

public class AccountModel
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public AccountModel(string email, string password)
    {
        Email = email;
        Password = password;
    }
}