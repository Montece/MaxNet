namespace MaxNet.Models.Chats;

public record ChatMembersList
{
    [JsonProperty("members")]
    public required ChatMember[] Members { get; init; }

    [JsonProperty("marker")]
    public long? Marker { get; init; }
}