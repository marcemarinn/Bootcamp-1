using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Banks
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Customers> Customers { get; set; } = new List<Customers>();
}
