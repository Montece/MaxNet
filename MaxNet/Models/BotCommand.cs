using System.Text.Json.Serialization;

namespace MaxNet.Models;

public sealed class BotCommand
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }
}