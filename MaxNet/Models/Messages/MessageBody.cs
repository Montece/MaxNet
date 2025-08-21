namespace MaxNet.Models.Messages;

public record MessageBody
{
    [JsonProperty("mid")]
    public required string Mid { get; init; }

    [JsonProperty("seq")]
    public required long Seq { get; init; }

    [JsonProperty("text")]
    public string? Text { get; init; }

    [JsonProperty("attachments")]
    public List<object>? Attachments { get; init; }

    [JsonProperty("markup")]
    public List<MarkupElement>? Markup { get; init; }
}