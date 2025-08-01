using MaxNet.Models;
using MaxNet.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace MaxNet;

// ReSharper disable once ConvertToPrimaryConstructor

public sealed class MaxBotClient : IMaxBotClient
{
    private readonly HttpClient _http;
    private readonly MaxBotClientOptions _options;

    public MaxBotClient(HttpClient httpClient, IOptions<MaxBotClientOptions> options)
    {
        _http = httpClient;
        _options = options.Value;
    }

    public async Task<MeResult> Me(CancellationToken cancellationToken = default)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, $"{_options.BaseUrl}/me");
        request.Headers.Authorization = new("Bearer", _options.ApiToken);

        var response = await _http.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);
        var result = JsonSerializer.Deserialize<MeResult>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;

        return result;
    }
}