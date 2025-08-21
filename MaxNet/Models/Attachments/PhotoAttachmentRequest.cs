namespace MaxNet.Models.Attachments;

public record PhotoAttachmentRequest : AttachmentRequest
{
    [JsonProperty("payload")]
    public PhotoAttachmentRequestPayload? Payload { get; init; }

    [JsonProperty("type")]
    public override required string Type { get; init; } = "image";
}