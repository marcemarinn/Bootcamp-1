using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Currency
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal BuyValue { get; set; }

    public decimal SellValue { get; set; }

    public virtual ICollection<Accounts> Accounts { get; set; } = new List<Accounts>();
}
