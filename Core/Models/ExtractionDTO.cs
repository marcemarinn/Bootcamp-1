namespace Core.Models;

public class ExtractionDTO
{

    public int Id { get; set; }

    public int AccountId { get; set; }

    public int BankId { get; set; }


    public decimal Amount { get; set; }

    public DateTime OperationalDate { get; set; }
}
