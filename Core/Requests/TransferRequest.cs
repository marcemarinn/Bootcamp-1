using Core.Constants;

namespace Core.Requests;

public class TransferRequest
{

    public Decimal Amount { get; set; }
    public string Description { get; set; }

    public int bankId { get; set; }
    public DateTime TransferDateTime { get; set; }

    public int CurrencyId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int ReceiverBankId { get; set; }

    public TransactionType TransactionType { get; set; } = TransactionType.ETransfer;

}
