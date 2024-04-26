using Core.Constants;

namespace Core.Models;

public class TransferDTO
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }

    public DateTime TransferDateTime { get; set; }

    public int CurrencyId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int ReceiverBankId { get; set; }

    public string DocumentNumber { get; set; }

    public string AccountNumber { get; set; }


    public int NumberAccount { get; set; }
    public TransactionType TransactionType { get; set; } = TransactionType.ETransfer;


}
