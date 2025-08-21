using MaxNet.Models.Attachments;

namespace MaxNet.Models.Bots;

public record BotPatch
{
    [JsonProperty("first_name")]
    public string? FirstName { get; init; }

    [JsonProperty("last_name")]
    public string? LastName { get; init; }

    [JsonProperty("description")]
    public string? Description { get; init; }

    [JsonProperty("commands")]
    public BotCommand[]? Commands { get; init; }

    [JsonProperty("photo")]
    public PhotoAttachmentRequestPayload? Photo { get; init; }
}