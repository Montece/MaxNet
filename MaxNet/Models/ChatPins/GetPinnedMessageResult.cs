using MaxNet.Models.Messages;

namespace MaxNet.Models.ChatPins;

public record GetPinnedMessageResult
{
    [JsonProperty("message")]
    public Message? Message { get; init; }
}