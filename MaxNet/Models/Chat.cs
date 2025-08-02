using MaxNet.Enums;
using Newtonsoft.Json;

namespace MaxNet.Models;

public sealed class Chat
{
    [JsonProperty("chat_id")]
    public required long ChatId { get; init; }

    [JsonProperty("type")]
    public required ChatType Type { get; init; }

    [JsonProperty("status")]
    public required ChatStatus Status { get; init; }

    [JsonProperty("title")]
    public required string? Title { get; init; }

    [JsonProperty("icon")]
    public required object? Icon { get; init; }

    // TODO
}