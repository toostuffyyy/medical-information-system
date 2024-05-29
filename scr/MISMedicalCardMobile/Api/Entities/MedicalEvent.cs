using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class MedicalEvent
{
    public int Id { get; set; }

    public int MedicalCardNumber { get; set; }

    public int TypeMedicalEventId { get; set; }

    public int? RoomId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public string? Recommendation { get; set; }

    public string? Result { get; set; }

    public virtual ICollection<Hospitalization> Hospitalizations { get; set; } = new List<Hospitalization>();

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual MedicalCard MedicalCardNumberNavigation { get; set; } = null!;

    public virtual Room? Room { get; set; }

    public virtual ICollection<SoundMessage> SoundMessages { get; set; } = new List<SoundMessage>();

    public virtual TypeMedicalEvent TypeMedicalEvent { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Medication> Medications { get; set; } = new List<Medication>();
}
