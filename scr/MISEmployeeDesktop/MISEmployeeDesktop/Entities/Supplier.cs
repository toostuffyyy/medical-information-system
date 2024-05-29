using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();
}
