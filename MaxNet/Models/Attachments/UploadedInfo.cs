namespace MaxNet.Models.Attachments;

public record UploadedInfo
{
    [JsonProperty("token")]
    public required string Token { get; init; }
}