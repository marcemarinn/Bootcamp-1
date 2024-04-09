using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class CurrentAccounts
{
    public int Id { get; set; }

    public decimal? OperationalLimit { get; set; }

    public decimal? MonthAverage { get; set; }

    public decimal? Interest { get; set; }

    public int AccountId { get; set; }

    public virtual Accounts Account { get; set; } = null!;
}
