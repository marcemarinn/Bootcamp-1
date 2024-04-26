using Core.Constants;
using Core.Entities;

namespace Core.Models;

public class AccountDTO
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; } = AccountType.Current;
    public decimal Balance { get; set; }
    public string Status { get; set; } = string.Empty;

    public int CurrencyId { get; set; }
    public int CustomerId { get; set; } 

    public SavingAccountDTO? SavingAccount { get; set; }
    public CurrentAccount? CurrentAccount { get; set; }
}
