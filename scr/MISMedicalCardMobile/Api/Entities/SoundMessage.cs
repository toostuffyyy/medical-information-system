using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class SoundMessage
{
    public int Id { get; set; }

    public int? MedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public virtual MedicalEvent? MedicalEvent { get; set; }
}
