using Core.Constants;

namespace Core.Entities
{
    public class TransactionHistory
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public decimal  Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        
        public  DateTime OperationDate { get; set; }

        public int MovementId { get; set; }
        public Movement Movement { get; set; }




    }
}
