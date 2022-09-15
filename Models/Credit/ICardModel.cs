namespace GDBank.Models;

public interface ICardModel
{
    public int Id { get; set; }
    public int CardType { get; set; } // 0 = debit, 1 = credit
    public float Balance { get; set; }
    public int MonthLimit { get; set; } // monthly spending power
    public string AccountName { get; set; } // eg. cashback, business, travel
    public string CardHolder { get; set; }
    public float CashBack { get; set; }
    public float MonthlyFee { get; set; } // none for students
    public float InterestRate { get; set; } // credit only
    public int OverdraftProtection { get; set; } // debit only

    public int AccountId { get; set; }
}