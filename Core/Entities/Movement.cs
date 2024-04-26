using Core.Constants;

namespace Core.Entities;

public class Movement
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime? OperationalDate { get; set; } 
    public TransactionType TransactionType { get; set; }
    public int? AccountId { get; set; }
    public Account Account { get; set; } = null!;



}
