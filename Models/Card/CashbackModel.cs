namespace GDBank.Models.Card
{
    public class CashbackModel : ICardModel
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

        public CashbackModel(CardApplicationModel model)
        {
            CardType = model.CardType;
            Balance = 1000; // new cards start with $1000 for demo purposes
            MonthLimit = 1500;
            AccountType = model.AccountType;
            CardHolder = model.FullName;
            CashBack = 3.00f;
            MonthlyFee = 50;

            if (model.CardType == "Credit")
                InterestRate = 1.2f;
            else
                InterestRate = 0;

            if (model.CardType == "Debit")
                OverdraftProtection = 1;
            else
                OverdraftProtection = 0;

            AccountId = model.AccountId;
        }
    }
}
