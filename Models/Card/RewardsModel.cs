namespace GDBank.Models.Card
{
    public class RewardsModel : ICardModel
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

        public RewardsModel(CardApplicationModel model)
        {
            CardType = model.CardType;
            Balance = 1000; // new cards start with $1000 for demo purposes
            MonthLimit = 1500;
            AccountType = model.AccountType;
            CardHolder = model.FullName;
            CashBack = 5.00f;
            MonthlyFee = 75;
            InterestRate = 1.2f;
            
            if (model.CardType == 0)
                OverdraftProtection = 1;
            else
                OverdraftProtection = 0;

            AccountId = model.AccountId;
        }
    }
}
