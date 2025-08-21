using MaxNet.Enums.Messages;

namespace MaxNet.Models.Messages;

public record NewMessageLink
{
    [JsonProperty("type")]
    public required MessageLinkType Type { get; init; }

    [JsonProperty("mid")]
    public required string Mid { get; init; }
}