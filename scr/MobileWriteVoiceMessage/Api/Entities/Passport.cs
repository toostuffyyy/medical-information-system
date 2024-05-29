using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class Passport
{
    public int IdPacient { get; set; }

    public string? PassportSeries { get; set; }

    public string? PassportNumber { get; set; }

    public virtual Pacient IdPacientNavigation { get; set; } = null!;
}
