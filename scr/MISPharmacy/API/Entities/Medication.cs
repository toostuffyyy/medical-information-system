using System;
using System.Collections.Generic;

namespace API.Entities;

public partial class Medication
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Dosage { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Distribution> Distributions { get; set; } = new List<Distribution>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();
}
