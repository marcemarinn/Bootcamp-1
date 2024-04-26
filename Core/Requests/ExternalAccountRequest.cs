namespace Core.Requests;

public class ExternalAccountRequest
{

    public int CurrencyId { get; set; }


    public int BankId { get; set; }

    public string DocumentNumber { get; set; }


    public int NumberAccount { get; set; }
}
