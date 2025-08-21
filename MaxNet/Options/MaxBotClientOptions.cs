namespace MaxNet.Options;

// ReSharper disable once ConvertToPrimaryConstructor

public sealed class MaxBotClientOptions
{
    public string ApiToken { get; }

    public MaxBotClientOptions(string apiToken)
    {
        ApiToken = apiToken;
    }
}