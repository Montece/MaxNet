using System.Text.Json.Serialization;

namespace MaxNet.Models;

public sealed class MeResult
{
    [JsonPropertyName("user_id")]
    public long UserId { get; init; }

    [JsonPropertyName("first_name")]
    public required string FirstName { get; init; }

    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }

    [JsonPropertyName("name")]
    [Obsolete("Устаревшее поле, скоро будет удалено")]
    public string? Name { get; init; }

    [JsonPropertyName("username")]
    public string? Username { get; init; }

    [JsonPropertyName("is_bot")]
    public bool IsBot { get; init; }

    [JsonPropertyName("last_activity_time")]
    public long LastActivityTime { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonPropertyName("full_avatar_url")]
    public string? FullAvatarUrl { get; init; }

    [JsonPropertyName("commands")]
    public BotCommand[]? Commands { get; init; }
}