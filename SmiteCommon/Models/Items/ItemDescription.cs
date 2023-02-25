
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Items;

public class ItemDescription
{
    public string Description { get; set; }

    [JsonPropertyName("Menuitems")]
    public List<MenuItem> MenuItems { get; set; }

    public string SecondaryDescription { get; set; }
}
