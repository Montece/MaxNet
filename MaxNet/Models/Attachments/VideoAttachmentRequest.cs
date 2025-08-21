namespace MaxNet.Models.Attachments;

public record VideoAttachmentRequest : AttachmentRequest
{
    [JsonProperty("payload")]
    public required UploadedInfo Payload { get; init; }

    [JsonProperty("token")]
    public override required string Type { get; init; } = "video";
}