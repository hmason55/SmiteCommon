
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Gods.Abilities;

public class ItemDescription
{
    [JsonPropertyName("cooldown")]
    public string Cooldown { get; set; }

    [JsonPropertyName("cost")]
    public string Cost { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("menuItems")]
    public List<MenuItem> MenuItems { get; set; }
}
