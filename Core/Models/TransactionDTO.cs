namespace Core.Models;

public class TransactionDTO
{

    public int Id { get; set; }

    public string Description { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }
}
