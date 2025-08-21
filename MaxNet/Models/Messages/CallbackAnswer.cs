namespace MaxNet.Models.Messages;

public record CallbackAnswer
{
    [JsonProperty("message")]
    public NewMessageBody? Message { get; init; }

    [JsonProperty("notification")]
    public string? Notification { get; init; }
}