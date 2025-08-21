namespace MaxNet.Models.Messages;

public record SendMessageResult
{
    [JsonProperty("message")]
    public required Message Message { get; init; }
}