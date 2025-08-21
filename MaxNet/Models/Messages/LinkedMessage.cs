using MaxNet.Models.Users;

namespace MaxNet.Models.Messages;

public record LinkedMessage
{
    [JsonProperty("type")]
    public required string Type { get; init; }

    [JsonProperty("sender")]
    public required User Sender { get; init; }

    [JsonProperty("chat_id")]
    public long? ChatId { get; init; }

    [JsonProperty("message")]
    public required MessageBody Message { get; init; }
}