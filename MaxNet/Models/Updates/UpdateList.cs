namespace MaxNet.Models.Updates;

public record UpdateList
{
    [JsonProperty("updates")]
    public required Update[] Updates { get; init; }

    [JsonProperty("marker")]
    public long? Marker { get; init; }
}