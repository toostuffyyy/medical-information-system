using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MISEmployeeDesktop.Models;

public class ResponceRersonalLocation
{
    [JsonPropertyName("response")]
    public List<PersonalLocation> Responce { get; set; }
}