using MaxNet.Enums.Chats;

namespace MaxNet.Models.Messages;

public record Recipient
{
    [JsonProperty("chat_id")]
    public long? ChatId { get; init; }

    [JsonProperty("chat_type")]
    public required ChatType ChatType { get; init; }

    [JsonProperty("user_id")]
    public long? UserId { get; init; }
}