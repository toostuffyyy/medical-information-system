using System;

namespace MISMedicalCardMobile1.Models;

public class SoundMessage
{
    public int Id { get; set; }

    public int? MedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateTime { get; set; }
}