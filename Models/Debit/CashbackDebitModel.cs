namespace GDBank.Models.Debit
{
    public class CashbackDebitModel : IDebitModel
    {
        public int Id { get; set; }
        public float Balance { get; set; } = 1000;
        public int MonthLimit { get; set; } = 5000;
        public string AccountName { get; set; } = "Cashback Debit";
        public string CardHolder { get; set; }
        public float? CashBack { get; set; } = 3.00f;
        public float? MonthlyFee { get; set; } = 50.00f;
        public bool OverdraftProtection { get; set; } = false;
        public int AccountId { get; set; }

        public CashbackDebitModel(AccountModel user)
        {
            CardHolder = user.FullName;
            AccountId = user.Id;
        }
    }
}
