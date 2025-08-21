namespace MaxNet.Models.Updates;

public record GetSubscriptionsResult
{
    [JsonProperty("subscriptions")]
    public required Subscription[] Subscriptions { get; init; }
}