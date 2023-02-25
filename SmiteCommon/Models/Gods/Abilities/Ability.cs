
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Gods.Abilities;

public class Ability
{
    public int Id { get; set; }
    public string Summary { get; set; }

    [JsonPropertyName("URL")]
    public string Url { get; set; }
    public AbilityDescription Description { get; set; }
}
