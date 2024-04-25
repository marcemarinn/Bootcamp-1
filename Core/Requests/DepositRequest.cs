using Core.Constants;

namespace Core.Requests;

public class DepositRequest
{
    public int AccountId { get; set; }

    public int BankId { get; set; }

    public decimal Amount { get; set; }

    public DateTime OperationDate { get; set; }


    public TransactionType TransactionType { get; set; }

}
