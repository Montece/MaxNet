using MaxNet.Options;
using MaxNet.Results;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MaxNet;

// ReSharper disable once ConvertToPrimaryConstructor

public sealed class MaxBotClient : IMaxBotClient
{
    private const string BASE_URL = "https://api.max.ru";

    private readonly HttpClient _http;
    private readonly MaxBotClientOptions _options;
    private readonly JsonSerializerSettings _jsonSettings = new()
    {
        Converters =
        {
            new StringEnumConverter()
        }
    };

    public MaxBotClient(HttpClient httpClient, MaxBotClientOptions options)
    {
        _http = httpClient;
        _options = options;
    }

    public async Task<MeResult> Me(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{BASE_URL}/me");
        request.Headers.Authorization = new("Bearer", _options.ApiToken);

        var response = await _http.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonConvert.DeserializeObject<MeResult>(json, _jsonSettings)!;

        return result;
    }
}