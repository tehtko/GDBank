namespace GDBank.Models
{
    public interface IDebitModel
    {
        public int Id { get; set; }
        public int MonthLimit { get; set; }
        public string AccountName { get; set; }
        public string CardHolder { get; set; }
        public float? CashBack { get; set; }

        public int AccountId { get; set; }
    }
}
