using Core.Constants;
using Core.DTOs;

namespace Core.Requests;

public class CreateAccountRequest
{
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public int CurrencyId { get; set; }
    public int CustomerId { get; set; }
    public AccountType AccountType { get; set; }
    public CreateSavingAccountRequest? CreateSavingAccount { get; set; }
    public CreateCurrentAccountRequest? CreateCurrentAccount { get; set; }


}
