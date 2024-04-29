namespace Core.Entities;

public class ExternalAccount
{

    public int Id { get; set; }

    public string DocumentNumber { get; set; }
    public int BankId { get; set; }

    public Bank Bank { get; set; }

    public int NumberAccount { get; set; }

    public int? CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;



}
