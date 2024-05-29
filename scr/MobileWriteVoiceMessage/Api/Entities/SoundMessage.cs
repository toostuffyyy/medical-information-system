using System;
using System.Collections.Generic;

namespace Api.Entities;

public partial class SoundMessage
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string? NameFile { get; set; }
}
