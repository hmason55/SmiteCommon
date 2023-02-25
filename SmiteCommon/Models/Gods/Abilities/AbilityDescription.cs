
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Gods.Abilities;

public class AbilityDescription
{
    [JsonPropertyName("itemDescription")]
    public ItemDescription ItemDescription { get; set; }

    [JsonPropertyName("rankItems")]
    public List<MenuItem> RankItems { get; set; }
}
