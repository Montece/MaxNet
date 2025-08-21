namespace MaxNet.Models.Updates;

public record Subscription
{
    [JsonProperty("url")]
    public required string Url { get; init; }

    [JsonProperty("time")]
    public required long Time { get; init; }

    [JsonProperty("update_types")]
    public string[]? UpdateTypes { get; init; }
}