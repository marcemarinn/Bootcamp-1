using Core.Entities;

namespace Core.DTOs;

public class TransferDTO
{
    public int Id { get; set; }
    public string Description { get; set; }

    public Decimal Amount { get; set; }

    public DateTime TransferDateTime { get; set; }

    public int CurrencyId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }
}
