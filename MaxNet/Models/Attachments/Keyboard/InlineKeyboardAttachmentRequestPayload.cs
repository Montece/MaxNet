namespace MaxNet.Models.Attachments.Keyboard;

public record InlineKeyboardAttachmentRequestPayload
{
    [JsonProperty("buttons")]
    public required Keyboard Buttons { get; init; }
}