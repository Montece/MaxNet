using MaxNet.Models.Users;

namespace MaxNet.Models.Messages;

public record Message
{
    [JsonProperty("sender")]
    public required User Sender { get; init; }

    [JsonProperty("recipient")]
    public required Recipient Recipient { get; init; }

    [JsonProperty("timestamp")]
    public required long Timestamp { get; init; }

    [JsonProperty("link")]
    public LinkedMessage? Link { get; init; }

    [JsonProperty("body")]
    public MessageBody? Body { get; init; }

    [JsonProperty("stat")]
    public MessageStat? Stat { get; init; }

    [JsonProperty("url")]
    public string? Url { get; init; }
}