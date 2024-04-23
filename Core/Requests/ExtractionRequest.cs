using Core.Entities;

namespace Core.Requests;

public class ExtractionRequest
{


    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public DateTime OperationalDate { get; set; }
}
