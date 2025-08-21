namespace MaxNet.Models.Messages;

public record MessageList
{
    [JsonProperty("messages")]
    public required Message[] Messages { get; init; }
}