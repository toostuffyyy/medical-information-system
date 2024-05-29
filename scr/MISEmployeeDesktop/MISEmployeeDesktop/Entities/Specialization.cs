﻿using System.Collections.Generic;

namespace MISEmployeeDesktop.Entities;

public partial class Specialization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
