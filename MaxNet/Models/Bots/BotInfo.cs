using MaxNet.Models.Users;

namespace MaxNet.Models.Bots;

public record BotInfo : UserWithPhoto
{
    [JsonProperty("commands")]
    public BotCommand[]? Commands { get; init; }
}