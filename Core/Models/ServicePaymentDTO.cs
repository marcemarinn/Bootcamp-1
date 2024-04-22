namespace Core.Models;

public class ServicePaymentDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string DocumentNumber { get; set; }
    public decimal Amount { get; set; }
    public int AccountId { get; set; }

}
