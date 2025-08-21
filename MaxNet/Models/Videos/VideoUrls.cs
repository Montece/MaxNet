using System.Diagnostics.CodeAnalysis;

namespace MaxNet.Models.Videos;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public record VideoUrls
{
    [JsonProperty("mp4_1080")]
    public string? Mp4_1080 { get; init; }

    [JsonProperty("mp4_720")]
    public string? Mp4_720 { get; init; }

    [JsonProperty("mp4_480")]
    public string? Mp4_480 { get; init; }

    [JsonProperty("mp4_360")]
    public string? Mp4_360 { get; init; }

    [JsonProperty("mp4_240")]
    public string? Mp4_240 { get; init; }

    [JsonProperty("mp4_144")]
    public string? Mp4_144 { get; init; }

    [JsonProperty("hls")]
    public string? Hls { get; init; }
}