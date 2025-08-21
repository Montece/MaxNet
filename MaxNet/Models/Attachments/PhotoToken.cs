namespace MaxNet.Models.Attachments;

public record PhotoToken
{
    [JsonProperty("token")]
    public required string Token { get; init; }
};