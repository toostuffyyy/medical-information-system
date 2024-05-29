using System;
using System.Collections.Generic;

namespace MISSheduleEmployee.Entities;

public partial class StatusDistribution
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();
}
