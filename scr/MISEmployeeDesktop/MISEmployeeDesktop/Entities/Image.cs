using System;
using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class Image
{
    public int Id { get; set; }

    public int MedicalEventId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime DateTime { get; set; }

    public virtual MedicalEvent MedicalEvent { get; set; } = null!;
}
