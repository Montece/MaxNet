namespace MaxNet.Models.Videos;

public record VideoAttachmentDetails
{
    [JsonProperty("token")]
    public required string Token { get; init; }

    [JsonProperty("urls")]
    public VideoUrls? Urls { get; init; }

    // TODO PhotoAttachmentPayload
    /*[JsonProperty("thumbnail")]
    public PhotoAttachmentPayload? Thumbnail { get; init; }*/

    [JsonProperty("width")]
    public required int Width { get; init; }

    [JsonProperty("height")]
    public required int Height { get; init; }

    [JsonProperty("duration")]
    public required int Duration { get; init; }
}