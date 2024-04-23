using Core.Constants;

namespace Core.Entities;

public class Extraction
{
    public int Id { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }

    public decimal Amount { get; set; }

    public DateTime? OperationalDate { get; set; } = DateTime.UtcNow;

    public TransactionType TransactionType { get; set; } = TransactionType.Extraction;



}
