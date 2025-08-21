namespace MaxNet.Models.ChatPins;

public record PinMessageBody
{
    [JsonProperty("type")]
    public required string MessageId { get; init; }

    [JsonProperty("notify")]
    public required bool? Notify { get; init; }
}