using MaxNet.Models.Users;

namespace MaxNet.Models.Updates;

public record Callback
{
    [JsonProperty("timestamp")]
    public required long Timestamp { get; init; }

    [JsonProperty("callback_id")]
    public required string CallbackId { get; init; }

    [JsonProperty("payload")]
    public string? Payload { get; init; }

    [JsonProperty("user")]
    public required User User { get; init; }
}