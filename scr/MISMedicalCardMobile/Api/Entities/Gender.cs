﻿using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Gender
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
}
