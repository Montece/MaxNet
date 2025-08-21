namespace MaxNet.Models.Uploads;

public record UploadEndpoint
{
    [JsonProperty("url")]
    public required string Url { get; init; }

    [JsonProperty("token")]
    public string? Token { get; init; }
}