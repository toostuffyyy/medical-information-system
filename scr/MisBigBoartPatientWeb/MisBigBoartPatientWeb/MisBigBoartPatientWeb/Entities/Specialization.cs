﻿using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class Specialization
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();
}
