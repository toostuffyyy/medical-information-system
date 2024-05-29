using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class DepartamentDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [JsonConstructor]
    public DepartamentDTO()
    {
        
    }
    public DepartamentDTO(Departament departament)
    {
        Id = departament.Id;
        Name = departament.Name;
    }
}
