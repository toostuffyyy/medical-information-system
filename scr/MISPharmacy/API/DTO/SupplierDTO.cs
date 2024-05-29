using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class SupplierDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonConstructor]
    public SupplierDTO() { }
    public SupplierDTO(Supplier storage)
    {
        Id = storage.Id;
        Name = storage.Name;
    }
}
