using MaxNet.Models.Users;

namespace MaxNet.Models.Chats;

public record ChatMember : UserWithPhoto
{
    [JsonProperty("last_access_time")]
    public required long LastAccessTime { get; init; }

    [JsonProperty("is_owner")]
    public required bool IsOwner { get; init; }

    [JsonProperty("is_admin")]
    public required bool IsAdmin { get; init; }

    [JsonProperty("join_time")]
    public required long JoinTime { get; init; }

    [JsonProperty("permissions")]
    public string[]? Permissions { get; init; }

    [JsonProperty("alias")]
    public string? Alias { get; init; }
}