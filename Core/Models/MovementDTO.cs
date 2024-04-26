using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class MovementDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public DateTime? OperationalDate { get; set; } 
    public TransactionType TransactionType { get; set; }
    public int? AccountId { get; set; }


}
