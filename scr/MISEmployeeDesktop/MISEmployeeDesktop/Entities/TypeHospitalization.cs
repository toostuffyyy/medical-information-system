using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class TypeHospitalization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();
}
