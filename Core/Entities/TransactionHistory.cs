namespace Core.Entities
{
    public class TransactionHistory
    {
        public int Int { get; set; }

        public string Description { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal  Amount { get; set; }
    }
}
