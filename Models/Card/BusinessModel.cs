namespace GDBank.Models.Card
{
    public class BusinessModel : ICardModel
    {
        public int Id { get; set; }
        public string CardType { get; set; }
        public float Balance { get; set; }
        public int MonthLimit { get; set; }
        public string AccountType { get; set; }
        public string CardHolder { get; set; }
        public float CashBack { get; set; }
        public float MonthlyFee { get; set; }
        public float InterestRate { get; set; }
        public int OverdraftProtection { get; set; }
        public int AccountId { get; set; }

        public BusinessModel(CardApplicationModel model)
        {
            CardType = model.CardType;
            Balance = 1000; // new cards start with $1000 for demo purposes
            MonthLimit = 20000;
            AccountType = model.AccountType;
            CardHolder = model.FullName;
            CashBack = 0;
            MonthlyFee = 300;
            InterestRate = 3;
            OverdraftProtection = 0;

            AccountId = model.AccountId;
        }
    }
}
