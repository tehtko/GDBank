namespace GDBank.Models;

public class AccountCreationModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public AccountCreationModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}