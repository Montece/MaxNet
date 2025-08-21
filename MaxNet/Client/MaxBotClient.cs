using MaxNet.Options;
using MaxNet.Utility;
using Newtonsoft.Json.Converters;
using System.Text;
using MaxNet.Exceptions;
using Newtonsoft.Json.Serialization;
using MaxNet.Client.Abstraction;
using MaxNet.Client.Modules;
using MaxNet.Utility.Json;

namespace MaxNet.Client;

// ReSharper disable once ConvertToPrimaryConstructor

public class MaxBotClient : IMaxBotClient, IDisposable
{
    public IBotsModule Bots
    {
        get
        {
            ThrowIfDisposed();
            return _bots;
        }
    }
    private readonly IBotsModule _bots;

    public IChatsModule Chats
    {
        get
        {
            ThrowIfDisposed();
            return _chats;
        }
    }
    private readonly IChatsModule _chats;

    public IMessagesModule Messages
    {
        get
        {
            ThrowIfDisposed();
            return _messages;
        }
    }
    private readonly IMessagesModule _messages;

    public IUpdatesModule Updates
    {
        get
        {
            ThrowIfDisposed();
            return _updates;
        }
    }
    private readonly IUpdatesModule _updates;

    public IUploadsModule Uploads
    {
        get
        {
            ThrowIfDisposed();
            return _uploads;
        }
    }
    private readonly IUploadsModule _uploads;

    private const string BASE_URL = "https://api.max.ru";

    private readonly HttpClient _http;
    private readonly MaxBotClientOptions _options;
    private readonly JsonSerializerSettings _jsonSettings = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore,
        Converters =
        {
            new StringEnumConverter { NamingStrategy = new CamelCaseNamingStrategy() },
            new UnixMillisDateTimeConverterNewtonsoft()
        }
    };

    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
    /// </summary>
    private bool _isDisposed;

    public MaxBotClient(HttpClient httpClient, MaxBotClientOptions options)
    {
        Guard.NotNull(nameof(httpClient), httpClient);
        Guard.NotNull(nameof(options), options);

        _http = httpClient;
        _options = options;

        _http.BaseAddress = new(BASE_URL);
        _http.DefaultRequestHeaders.Accept.Add(new("application/json"));

        _bots = new BotsModule(this);
        _chats = new ChatsModule(this);
        _messages = new MessagesModule(this);
        _updates = new UpdatesModule(this);
        _uploads = new UploadsModule(this);
    }

    public async Task<T> SendAsync<T>(HttpMethod method, string path, object? body, IDictionary<string, string?>? queryParameters, CancellationToken cancellationToken)
    {
        ThrowIfDisposed();

        var urlBuilder = new StringBuilder(path);
        var fullQueryParameters = new Dictionary<string, string>
        {
            ["access_token"] = _options.ApiToken
        };

        if (queryParameters != null)
        {
            foreach (var parameter in queryParameters)
            {
                if (string.IsNullOrEmpty(parameter.Value))
                {
                    continue;
                }

                fullQueryParameters[parameter.Key] = parameter.Value;
            }
        }

        if (fullQueryParameters.Count > 0)
        {
            urlBuilder.Append('?');
            urlBuilder.Append(string.Join('&', fullQueryParameters.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}")));
        }

        var url = urlBuilder.ToString();
        using var request = new HttpRequestMessage(method, url);

        if (body != null)
        {
            var json = JsonConvert.SerializeObject(body, _jsonSettings);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        using var response = await _http.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        var content = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);

        if (!response.IsSuccessStatusCode)
        {
            var error = TryDeserialize<Error>(content);
            throw new MaxBotApiException((int)response.StatusCode, error?.Code, error?.Message ?? content);
        }

        if (typeof(T) == typeof(SimpleQueryResult) && string.IsNullOrWhiteSpace(content))
        {
            return (T)(object)new SimpleQueryResult
            {
                Success = true
            };
        }

        var result = TryDeserialize<T>(content);

        if (result == null)
        {
            throw new MaxBotApiException((int)response.StatusCode, null, "Failed to deserialize response: " + content);
        }

        return result;
    }

    private T? TryDeserialize<T>(string json)
    {
        ThrowIfDisposed();

        try
        {
            return JsonConvert.DeserializeObject<T>(json, _jsonSettings);
        }
        catch
        {
            return default;
        }
    }

    #region IDisposable

    /// <inheritdoc />
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed)
        {
            return;
        }

        _isDisposed = true;

        if (disposing)
        {
            _http.Dispose();
        }
    }

    ~MaxBotClient()
    {
        Dispose(false);
    }

    private void ThrowIfDisposed()
    {
        if (_isDisposed)
        {
            throw new InvalidOperationException("Object was disposed.");
        }
    }

    #endregion
}