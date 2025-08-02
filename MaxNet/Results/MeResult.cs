using MaxNet.Models;
using Newtonsoft.Json;

namespace MaxNet.Results;

public sealed class MeResult
{
    [JsonProperty("user_id")]
    public long UserId { get; init; }

    [JsonProperty("first_name")]
    public required string FirstName { get; init; }

    [JsonProperty("last_name")]
    public string? LastName { get; init; }

    [JsonProperty("name")]
    [Obsolete("Устаревшее поле, скоро будет удалено")]
    public string? Name { get; init; }

    [JsonProperty("username")]
    public string? Username { get; init; }

    [JsonProperty("is_bot")]
    public bool IsBot { get; init; }

    [JsonProperty("last_activity_time")]
    public long LastActivityTime { get; init; }

    [JsonProperty("description")]
    public string? Description { get; init; }

    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonProperty("full_avatar_url")]
    public string? FullAvatarUrl { get; init; }

    [JsonProperty("commands")]
    public BotCommand[]? Commands { get; init; }
}