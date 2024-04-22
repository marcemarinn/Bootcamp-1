using Core.Entities;

namespace Core.Models;

public class DepositDTO
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BankId { get; set; }

    public decimal Amount { get; set; }

    public DateTime OperationDate { get; set; }

}
