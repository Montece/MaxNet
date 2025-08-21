using MaxNet.Models.Attachments;

namespace MaxNet.Models.Chats;

public record ChatPatch
{
    [JsonProperty("icon")]
    public PhotoAttachmentRequestPayload? Icon { get; init; }
    
    [JsonProperty("title")]
    public string? Title { get; init; }
    
    [JsonProperty("pin")]
    public string? Pin { get; init; }
    
    [JsonProperty("notify")]
    public bool? Notify { get; init; }
}