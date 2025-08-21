namespace MaxNet.Models.Messages;

public record MessageStat
{
    [JsonProperty("views")]
    public required int Views { get; init; }
}