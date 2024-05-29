using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class StatusHospitalization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
}
