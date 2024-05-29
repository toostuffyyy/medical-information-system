using System;
using System.Collections.Generic;

namespace MisBigBoartPatientWeb.Entities;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Doctor> Doctors { get; } = new List<Doctor>();

    public virtual ICollection<Patient> Patients { get; } = new List<Patient>();
}
