namespace MaxNet.Models.Updates;

public record SubscriptionRequestBody
{
    [JsonProperty("url")]
    public required string Url { get; init; }

    [JsonProperty("update_types")]
    public string[]? UpdateTypes { get; init; }

    [JsonProperty("secret")]
    public string? Secret { get; init; }
}