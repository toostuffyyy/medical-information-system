using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public int GenderId { get; set; }

    public int SpecializationId { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public virtual Gender Gender { get; set; } = null!;

    public virtual Specialization Specialization { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();
}
