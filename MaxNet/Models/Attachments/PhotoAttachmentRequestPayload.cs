namespace MaxNet.Models.Attachments;

public record PhotoAttachmentRequestPayload
{
    [JsonProperty("url")]
    public string? Url { get; init; }

    [JsonProperty("token")]
    public string? Token { get; init; }

    [JsonProperty("photos")]
    public Dictionary<string, PhotoToken>? Photos { get; init; }
}