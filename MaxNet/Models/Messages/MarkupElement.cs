namespace MaxNet.Models.Messages;

public record MarkupElement
{
    [JsonProperty("type")]
    public required string Type { get; init; }

    [JsonProperty("from")]
    public required int From { get; init; }

    [JsonProperty("length")]
    public required int Length { get; init; }

    [JsonProperty("url")]
    public string? Url { get; init; }
}