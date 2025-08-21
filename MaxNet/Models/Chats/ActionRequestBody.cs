using MaxNet.Enums.Chats;

namespace MaxNet.Models.Chats;

public record ActionRequestBody
{
    [JsonProperty("action")]
    public required SenderAction Action { get; init; }
}