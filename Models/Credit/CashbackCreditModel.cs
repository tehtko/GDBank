namespace GDBank.Models.Credit
{
    public class CashbackCreditModel : ICardModel
    {
        public int Id { get; set; }
        public float Balance { get; set; } = 0;
        public int MonthLimit { get; set; } = 10000;
        public string AccountName { get; set; } = "Cashback Credit";
        public string CardHolder { get; set; }
        public float? CashBack { get; set; } = 3.00f;
        public float MonthlyFee { get; set; } = 50.00f;
        public float InterestRate { get; set; } = 1.2f;
        public int AccountId { get; set; }
    }
}
