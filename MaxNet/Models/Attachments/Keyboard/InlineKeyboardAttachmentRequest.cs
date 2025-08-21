namespace MaxNet.Models.Attachments.Keyboard;

public record InlineKeyboardAttachmentRequest : AttachmentRequest
{
    [JsonProperty("payload")]
    public required InlineKeyboardAttachmentRequestPayload Payload { get; init; }

    [JsonProperty("type")]
    public override required string Type { get; init; } = "inline_keyboard";
}