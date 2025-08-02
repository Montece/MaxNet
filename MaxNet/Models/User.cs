using Newtonsoft.Json;

namespace MaxNet.Models;

public sealed class User
{
    [JsonProperty("user_id")]
    public required long UserId { get; init; }

    [JsonProperty("first_name")]
    public required string FirstName { get; init; }

    [JsonProperty("last_name")]
    public string? LastName { get; init; }

    [JsonProperty("name")]
    [Obsolete]
    public string? Name { get; init; }

    [JsonProperty("username")]
    public string? Username { get; init; }

    [JsonProperty("is_bot")]
    public bool IsBot { get; init; }

    [JsonProperty("last_activity_time")]
    public long LastActivityTime { get; init; }
}