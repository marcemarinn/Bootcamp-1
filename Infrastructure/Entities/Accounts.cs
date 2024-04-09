using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Accounts
{
    public int Id { get; set; }

    public string Holder { get; set; } = null!;

    public string Number { get; set; } = null!;

    public int Type { get; set; }

    public decimal Balance { get; set; }

    public int Status { get; set; }

    public int CurrencyId { get; set; }

    public int CustomerId { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual ICollection<CurrentAccounts> CurrentAccounts { get; set; } = new List<CurrentAccounts>();

    public virtual Customers Customer { get; set; } = null!;

    public virtual ICollection<Movements> Movements { get; set; } = new List<Movements>();

    public virtual ICollection<SavingAccounts> SavingAccounts { get; set; } = new List<SavingAccounts>();
}
