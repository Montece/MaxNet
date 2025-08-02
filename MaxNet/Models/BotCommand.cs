using Newtonsoft.Json;

namespace MaxNet.Models;

public sealed class BotCommand
{
    [JsonProperty("name")]
    public required string Name { get; init; }

    [JsonProperty("description")]
    public string? Description { get; init; }
}