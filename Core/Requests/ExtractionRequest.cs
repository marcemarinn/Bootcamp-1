using Core.Entities;

namespace Core.Requests;

public class ExtractionRequest
{


    public int AccountId { get; set; }

    public int BankId { get; set; }


    public decimal Amount { get; set; }

    public DateTime OperationalDate { get; set; }
}
