using GDBank.Data;
using GDBank.Models;
using GDBank.Models.Card;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Reflection;

namespace GDBank.Services;

public class AccountService
{
    public bool CreateUser(AccountCreationModel user)
    {
        if (user.Password is null)
            return false;

        try
        {
            GDContext context = new();
            SqlDataAdapter adapter = new();

            string password = Hash.HashPassword(user.Password);

            context.connection.Open();

            SqlCommand command = new()
            {
                Connection = context.connection,
                CommandText = $"INSERT INTO GDUsers (full_name, email, password) VALUES ('{user.FullName}', '{user.Email}', '{password}')"
            };

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            context.connection.Close();

            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }

    public bool ValidateLogin(AccountModel user)
    {
        try
        {
            GDContext context = new();
            SqlDataReader dataReader;

            string password = Hash.HashPassword(user.Password);

            context.connection.Open();

            SqlCommand command = new($"SELECT email, password FROM GDUsers WHERE email = '{user.Email}' AND password = '{password}';", context.connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                if (dataReader.GetString(0) == user.Email && dataReader.GetString(1) == password)
                    return true;
                else
                    break;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public AccountModel GetUser(string email)
    {
        try
        {
            AccountModel model = null;
            GDContext context = new();
            SqlDataReader dataReader;

            context.connection.Open();

            SqlCommand command = new($"SELECT full_name, id FROM GDUsers WHERE email = '{email}'", context.connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                model = new AccountModel
                {
                    FullName = dataReader.GetString(0),
                    Email = email,
                    Id = dataReader.GetInt32(1)
                };
            }

            return model;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public bool CreateCard(ICardModel card, int id)
    {
        if (card.CardType == "Debit" && CheckUsersDebitCards(id) > 2)
            return false;

        if (card.CardType == "Credit" && CheckUsersCreditCards(id) > 2)
            return false;

        try
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            GDContext context = new();
            SqlDataAdapter adapter = new();

            context.connection.Open();

            SqlCommand command = new()
            {
                Connection = context.connection,
                CommandText = $"INSERT INTO GDUsers_Cards (card_type, balance, month_limit, account_name, card_holder, cashback, monthly_fee, interest_rate, overdraft_protection, creation_date, account_id) VALUES ('{card.CardType}', '{card.Balance}', '{card.MonthLimit}', '{card.AccountType}', '{card.CardHolder}', '{card.CashBack}', '{card.MonthlyFee}', '{card.InterestRate}', '{card.OverdraftProtection}', '{date}', '{id}')"
            };

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            context.connection.Close();

            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }

    public int CheckUsersDebitCards(int id)
    {
        int count = 0;
        try
        {
            GDContext context = new();
            SqlDataReader dataReader;

            context.connection.Open();

            SqlCommand command = new($"SELECT id FROM GDUsers_Cards WHERE account_id = '{id}' AND card_type = 'Debit'", context.connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                count++;
            }

            return count;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public int CheckUsersCreditCards(int id)
    {
        int count = 0;
        try
        {
            GDContext context = new();
            SqlDataReader dataReader;

            context.connection.Open();

            SqlCommand command = new($"SELECT id FROM GDUsers_Cards WHERE account_id = '{id}' AND card_type = 'Credit'", context.connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                count++;
            }

            return count;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public List<ICardModel> GetCards(int id)
    {
        List<ICardModel> cards = new();
        try
        {
            GDContext context = new();
            SqlDataReader dataReader;

            context.connection.Open();

            SqlCommand command = new($"SELECT id, balance, account_name FROM GDUsers_Cards WHERE account_id = '{id}'", context.connection);

            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                cards.Add(new BaseModel
                {
                    Id = dataReader.GetInt32(0),
                    Balance = dataReader.GetDouble(1),
                    AccountType = dataReader.GetString(2)
                });
            }

            return cards;
        }
        catch (Exception)
        {
            return cards;
        }

    }

    public bool DeleteCard(int id)
    {
        try
        {
            var date = DateTime.Now.ToString("yyyy-MM-dd");

            GDContext context = new();
            SqlDataAdapter adapter = new();

            context.connection.Open();

            SqlCommand command = new()
            {
                Connection = context.connection,
                CommandText = $"DELETE FROM GDUsers_Cards WHERE id = '{id}'"
            };

            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();

            command.Dispose();
            context.connection.Close();

            return true;
        }
        catch (SqlException)
        {
            return false;
        }
    }
}