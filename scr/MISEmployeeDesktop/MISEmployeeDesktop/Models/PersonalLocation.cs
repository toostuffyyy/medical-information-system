using System.Text.Json.Serialization;

namespace MISEmployeeDesktop.Models;

public class PersonalLocation
{
    [JsonPropertyName("personCode")] public int PersonCode { get; set; }
    [JsonPropertyName("personRole")] public string PersonRole { get; set; }
    [JsonPropertyName("lastSecurityPointNumber")] public int LastSecurityPointNumber { get; set; }
    [JsonPropertyName("lastSecurityPointDirection")] public string LastSecurityPointDirection { get; set; }
    [JsonPropertyName("lastSecurityPointTime")] public string LastSecurityPointTime { get; set; }
    
    [JsonIgnore] public double X { get; set; }
    [JsonIgnore] public double Y { get; set; }
    [JsonIgnore] public string Color => PersonRole == "Клиент" ? "Green" : "Blue";
}