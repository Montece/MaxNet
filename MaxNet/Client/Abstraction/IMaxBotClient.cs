using MaxNet.Utility.Attributes;

namespace MaxNet.Client.Abstraction;

[PublicApi]
public interface IMaxBotClient
{
    IBotsModule Bots { get; }

    IChatsModule Chats { get; }

    IMessagesModule Messages { get; }

    IUpdatesModule Updates { get; }

    IUploadsModule Uploads { get; }

    Task<T> SendAsync<T>(HttpMethod method, string path, object? body, IDictionary<string, string?>? queryParameters, CancellationToken cancellationToken);
}