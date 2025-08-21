namespace MaxNet.Client;

public record Error
{
    public string? ErrorField { get; init; }

    public string? Code { get; init; }

    public string? Message { get; init; }

    public IDictionary<string, JToken>? Extra { get; init; }
}