using MaxNet.Models.Messages;

namespace MaxNet.Models.Updates;

public record Update
{
    [JsonProperty("update_type")]
    public required string UpdateType { get; init; }

    [JsonProperty("timestamp")]
    public required long Timestamp { get; init; }

    [JsonProperty("callback")]
    public Callback? Callback { get; init; }

    [JsonProperty("message")]
    public Message? Message { get; init; }

    [JsonProperty("user_locale")]
    public string? UserLocale { get; init; }

    [JsonProperty("extra")]
    public Dictionary<string, JToken>? Extra { get; init; }
}