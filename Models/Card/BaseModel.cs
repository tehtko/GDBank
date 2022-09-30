namespace GDBank.Models.Card
{
    public class BaseModel : ICardModel
    {
        public int Id { get; set; }
        public string CardType { get; set; }
        public double Balance { get; set; }
        public int MonthLimit { get; set; }
        public string AccountType { get; set; }
        public string CardHolder { get; set; }
        public float CashBack { get; set; }
        public float MonthlyFee { get; set; }
        public float InterestRate { get; set; }
        public int OverdraftProtection { get; set; }
        public int AccountId { get; set; }
    }
}
