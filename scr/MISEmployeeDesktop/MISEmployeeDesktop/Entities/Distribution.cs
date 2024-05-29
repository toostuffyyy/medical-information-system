using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class Distribution
{
    public int OrderId { get; set; }

    public int DepartamentId { get; set; }

    public int StatusDistributionId { get; set; }

    public virtual Department Departament { get; set; } = null!;

    public virtual StatusDistribution StatusDistribution { get; set; } = null!;
}
