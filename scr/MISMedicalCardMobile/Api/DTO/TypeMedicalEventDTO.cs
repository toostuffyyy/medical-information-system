using System;
using System.Collections.Generic;
using Api.Entities;

namespace Api.DTO;

public partial class TypeMedicalEventDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TypeMedicalEventDTO(TypeMedicalEvent typeMedicalEvent)
    {
        Id = typeMedicalEvent.Id;
        Name = typeMedicalEvent.Name;
    }
}
