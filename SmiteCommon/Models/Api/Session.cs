using System.Text.Json.Serialization;

namespace SmiteCommon.Models.Api;

public class Session
{
    [JsonPropertyName("ret_msg")]
    public string Result { get; set; }

    [JsonPropertyName("session_id")]
    public string Id { get; set; }

    public string Timestamp { get; set; } = DateTime.MinValue.ToString();

    public bool IsExpired()
    {
        DateTime creationDate = DateTime.Parse(Timestamp);
        DateTime expirationDate = creationDate + TimeSpan.FromMinutes(15);
        return DateTime.UtcNow > expirationDate;
    }
}
