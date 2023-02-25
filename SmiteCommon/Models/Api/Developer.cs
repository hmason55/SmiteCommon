
using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Api;

public class Developer
{
    [JsonPropertyName("devId")]
    public string Id { get; set; } = "4109";
    public string AuthKey { get; set; } = "3096C059E58E4B739F31FEC9935ABC4D";
}
