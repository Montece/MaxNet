namespace MaxNet.Models.Attachments;

public record AudioAttachmentRequest : AttachmentRequest
{
    [JsonProperty("payload")]
    public required UploadedInfo Payload { get; init; }

    [JsonProperty("type")]
    public override required string Type { get; init; } = "audio";
}