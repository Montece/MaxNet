using MaxNet.Enums.Messages;

namespace MaxNet.Models.Messages;

public record NewMessageBody
{
    [JsonProperty("text")]
    public string? Text { get; init; }

    [JsonProperty("attachments")]
    public List<object>? Attachments { get; init; }

    [JsonProperty("link")]
    public NewMessageLink? Link { get; init; }

    [JsonProperty("notify")]
    public bool? Notify { get; init; }

    [JsonProperty("format")]
    public TextFormat? Format { get; init; }
}