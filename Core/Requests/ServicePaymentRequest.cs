namespace Core.Requests;

public class ServicePaymentRequest
{
    public string Description { get; set; }
    public string DocumentNumber { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }
    public DateTime OperationalDate { get; set; }

    public int ServiceId { get; set; }
   
}
