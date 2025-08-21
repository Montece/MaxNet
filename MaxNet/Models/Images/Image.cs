namespace MaxNet.Models.Images;

public class Image
{
    [JsonProperty("url")]
    public required string Url { get; init; }
}