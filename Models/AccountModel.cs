namespace GDBank.Models;

public class AccountModel
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public AccountModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}