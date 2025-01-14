﻿using Core.Constants;

namespace Core.Entities;

public class Account
{
    public int Id { get; set; }
    public string Holder { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public AccountType Type { get; set; } = AccountType.Current;
    public decimal Balance { get; set; }
    public AccountStatus Status { get; set; } = AccountStatus.Active;

    public int CurrencyId { get; set; }
    public Currency Currency { get; set; } = null!;
    
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;

    public virtual ICollection<SavingAccount> SavingAccounts { get; set; } = new List<SavingAccount>();
    public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; } = new List<CurrentAccount>();
    public virtual ICollection<Movement> Movements { get; set; } = new List<Movement>();
}
