using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class SavingAccounts
{
    public int Id { get; set; }

    public int SavingType { get; set; }

    public string HolderName { get; set; } = null!;

    public int AccountId { get; set; }

    public virtual Accounts Account { get; set; } = null!;
}
