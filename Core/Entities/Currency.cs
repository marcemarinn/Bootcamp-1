namespace Core.Entities;

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal BuyValue { get; set; }
    public decimal SellValue { get; set; }

    public ICollection<Transfer> Transfers { get; set; } = new List<Transfer>();

    public ICollection<ProductRequest> ProductRequests { get; set; } = new List<ProductRequest>();
    public ICollection<Account> Accounts { get; set; } = new List<Account>();
    public ICollection<ExternalAccount> ExternalAccounts { get; set; } = new List<ExternalAccount>();

}
