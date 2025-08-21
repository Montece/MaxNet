namespace MaxNet.Client;

public record SimpleQueryResult
{
    public required bool Success { get; init; }

    public string? Message { get; init; }
}