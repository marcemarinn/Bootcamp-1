using Core.Constants;
using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Requests;

public class TransferRequest
{

    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime TransferDateTime { get; set; }
    public int? SenderId { get; set; }
    public int? ReceiverId { get; set; }
    public int NumberAccount { get; set; }
    public int? CurrencyId { get; set; }

    public int BankId { get; set; }

    public string DocumentNumber { get; set; }

}
