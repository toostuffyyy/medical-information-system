using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class TypeMedicalEvent
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();
}
