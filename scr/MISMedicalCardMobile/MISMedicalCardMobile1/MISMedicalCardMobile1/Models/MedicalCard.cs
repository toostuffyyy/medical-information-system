using System;

namespace MISMedicalCardMobile1.Models;

public class MedicalCard
{
    public int Number { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime LastVisitDate { get; set; }

    public DateTime? NextVisitDate { get; set; }

    public virtual Patient Patient { get; set; } = null!;
}