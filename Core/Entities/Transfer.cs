using Core.Constants;

namespace Core.Entities;

public class Transfer
{
    public int Id { get; set; }

    public string Description { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public DateTime TransferDateTime { get; set; }

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }

    public ExternalAccount? ExternalAccount { get; set; }

    public int SenderId { get; set; }
    public Account SenderAccount { get; set; }

    public int ReceiverId { get; set; }
    public Account ReceiverAccount { get; set; }

    public TransactionType TransactionType { get; set; } = TransactionType.ETransfer;




}
