using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class MedicalCard
{
    public int IdPacient { get; set; }

    public DateTime DateCreate { get; set; }

    public virtual Pacient IdPacientNavigation { get; set; } = null!;
}
