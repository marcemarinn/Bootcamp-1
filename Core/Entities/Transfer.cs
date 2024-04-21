namespace Core.Entities;

public class Transfer
{
    public int Id { get; set; }
    
    public string Description { get; set; } 

    public Decimal Amount { get; set; } 

    public DateTime TransferDateTime { get; set; }

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }

    
    public int SenderId { get; set; }
    public Account SenderAccount { get; set; }

    public int ReceiverId { get; set; }
    public Account ReceiverAccount { get; set; }

    

}
