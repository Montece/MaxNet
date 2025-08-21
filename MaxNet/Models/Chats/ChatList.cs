namespace MaxNet.Models.Chats;

public record ChatList
{
    [JsonProperty("chats")]
    public required Chat[] Chats { get; init; }

    [JsonProperty("marker")]
    public required long? Marker { get; init; }
}