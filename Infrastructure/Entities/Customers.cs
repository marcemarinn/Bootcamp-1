using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Customers
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Lastname { get; set; }

    public string DocumentNumber { get; set; } = null!;

    public string? Address { get; set; }

    public string? Mail { get; set; }

    public string? Phone { get; set; }

    public int CustomerStatus { get; set; }

    public int BankId { get; set; }

    public DateTime? Birth { get; set; }

    public virtual ICollection<Accounts> Accounts { get; set; } = new List<Accounts>();

    public virtual Banks Bank { get; set; } = null!;
}
