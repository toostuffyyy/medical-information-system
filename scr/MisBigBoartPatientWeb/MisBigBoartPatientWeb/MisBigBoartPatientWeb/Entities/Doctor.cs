using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class Doctor
{
    public int Id { get; set; }

    public int SpecializationId { get; set; }

    public int GenderId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; } = new List<MedicalEvent>();

    public virtual Specialization Specialization { get; set; } = null!;
}
