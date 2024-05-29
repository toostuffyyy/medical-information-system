using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class TypeHospitalization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; } = new List<Hospitalization>();
}
