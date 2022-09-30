namespace GDBank.Models.Card
{
    public class StudentModel : ICardModel
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

        public StudentModel(CardApplicationModel model)
        {
            CardType = model.CardType;
            Balance = 1000; // new cards start with $1000 for demo purposes
            MonthLimit = 1000;
            AccountType = model.AccountType;
            CardHolder = model.FullName;
            CashBack = 1.0f;
            MonthlyFee = 0;
            InterestRate = 0;
            OverdraftProtection = 1;

            AccountId = model.AccountId;
        }
    }
}
