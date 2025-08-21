namespace MaxNet.Models.Attachments;

public record FileAttachmentRequest : AttachmentRequest
{
    [JsonProperty("payload")]
    public required UploadedInfo Payload { get; init; }

    [JsonProperty("chat_id")]
    public override required string Type { get; init; } = "file";
}