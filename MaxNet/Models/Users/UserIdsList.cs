namespace MaxNet.Models.Users;

public record UserIdsList
{
    [JsonProperty("user_ids")]
    public required long[] UserIds { get; init; }
}