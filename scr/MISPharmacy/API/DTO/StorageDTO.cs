using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using API.Entities;

namespace API.DTO;

public partial class StorageDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    [JsonConstructor]
    public StorageDTO() { }
    public StorageDTO(Storage storage)
    {
        Id = storage.Id;
        Name = storage.Name;
    }
}
