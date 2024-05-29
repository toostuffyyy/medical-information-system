using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Medication
{
    public int Id { get; set; }

    public int TypeReceptionId { get; set; }

    public string Name { get; set; } = null!;

    public string Dosage { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Party> Parties { get; set; } = new List<Party>();

    public virtual TypeReception TypeReception { get; set; } = null!;

    public virtual ICollection<MedicalEvent> MedicalEvents { get; set; } = new List<MedicalEvent>();
}
