using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class GenderDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public GenderDTO(Gender gender)
    {
        Id = gender.Id;
        Name = gender.Name;
    }
}
