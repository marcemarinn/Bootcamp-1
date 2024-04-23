namespace Core.Models;

public class TransactionHistoryDTO
{

    public int Id { get; set; }

    public string Description { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime OperationDate { get; set; }
}
