namespace MaxNet.Models.Attachments;

public abstract record AttachmentRequest
{
    [JsonProperty("type")]
    public abstract required string Type { get; init; }
}