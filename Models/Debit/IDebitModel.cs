namespace GDBank.Models;

public interface IDebitModel
{
    public Guid Id { get; set; }
    public float Balance { get; set; }
    public int MonthLimit { get; set; }
    public string AccountName { get; set; }
    public string CardHolder { get; set; }
    public float? CashBack { get; set; }
    public float? MonthlyFee { get; set; }
    public bool OverdraftProtection { get; set; }

    public int AccountId { get; set; }
}