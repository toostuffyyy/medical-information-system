using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class MedicalEvent
{
    public int Id { get; set; }

    public int MedicalCardId { get; set; }

    public int MedicalEventTypeId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Result { get; set; }

    public string? Recommendation { get; set; }

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual MedicalCard MedicalCard { get; set; } = null!;

    public virtual MedicalEventType MedicalEventType { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
}
