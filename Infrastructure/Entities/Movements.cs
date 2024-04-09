using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Movements
{
    public int Id { get; set; }

    public string Destination { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime? TransferredDateTime { get; set; }

    public int TransferStatus { get; set; }

    public int AccountId { get; set; }

    public virtual Accounts Account { get; set; } = null!;
}
