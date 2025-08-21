namespace MaxNet.Models.Users;

public record UserWithPhoto : User
{
    [JsonProperty("description")]
    public string? Description { get; init; }

    [JsonProperty("avatar_url")]
    public string? AvatarUrl { get; init; }

    [JsonProperty("full_avatar_url")]
    public string? FullAvatarUrl { get; init; }
}