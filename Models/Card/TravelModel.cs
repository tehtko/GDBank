namespace GDBank.Models.Card
{
    public class TravelModel : ICardModel
    {
        public int Id { get; set; }
        public int CardType { get; set; }
        public float Balance { get; set; }
        public int MonthLimit { get; set; }
        public int AccountType { get; set; }
        public string CardHolder { get; set; }
        public float CashBack { get; set; }
        public float MonthlyFee { get; set; }
        public float InterestRate { get; set; }
        public int OverdraftProtection { get; set; }
        public int AccountId { get; set; }

        public TravelModel(CardApplicationModel model)
        {
            CardType = 1;
            Balance = 1000; // new cards start with $1000 for demo purposes
            MonthLimit = 10000;
            AccountType = model.AccountType;
            CardHolder = model.FullName;
            CashBack = 0;
            MonthlyFee = 200;
            InterestRate = 1.2f;
            OverdraftProtection = 0;

            AccountId = model.AccountId;
        }
    }
}
