using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class SoundMessageDTO
{
    public int Id { get; set; }

    public int? MedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateTime { get; set; }
}
