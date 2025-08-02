namespace MaxNet.Options;

// ReSharper disable once ConvertToPrimaryConstructor

public sealed class MaxBotClientOptions
{
    public string ApiToken { get; set; }

    public MaxBotClientOptions(string apiToken)
    {
        ApiToken = apiToken;
    }
}