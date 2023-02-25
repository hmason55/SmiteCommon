
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Gods.Abilities;

public class MenuItem
{
    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("value")]
    public string Value { get; set; }
}
