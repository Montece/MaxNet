using System.Globalization;
using MaxNet.Client.Abstraction;
using MaxNet.Models.Updates;

namespace MaxNet.Client.Modules;

public sealed class UpdatesModule : IUpdatesModule
{
    public IMaxBotClient MaxBotClient { get; }

    public UpdatesModule(MaxBotClient maxBotClient)
    {
        MaxBotClient = maxBotClient;
    }

    public Task<GetSubscriptionsResult> GetSubscriptionsAsync(CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<GetSubscriptionsResult>(HttpMethod.Get, "/subscriptions", null, null, cancellationToken);
    }

    public Task<SimpleQueryResult> SubscribeAsync(SubscriptionRequestBody body, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Post, "/subscriptions", body, null, cancellationToken);
    }

    public Task<SimpleQueryResult> UnsubscribeAsync(string url, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<SimpleQueryResult>(HttpMethod.Delete, "/subscriptions", null, new Dictionary<string, string?>
        {
            ["url"] = url
        }, cancellationToken);
    }

    public Task<UpdateList> GetUpdatesAsync(int limit = 100, int timeoutSec = 30, long? marker = null, IEnumerable<string>? types = null, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<UpdateList>(HttpMethod.Get, "/updates", null, new Dictionary<string, string?>
        {
            ["limit"] = limit.ToString(CultureInfo.InvariantCulture),
            ["timeout"] = timeoutSec.ToString(CultureInfo.InvariantCulture),
            ["marker"] = marker?.ToString(CultureInfo.InvariantCulture),
            ["types"] = types is null ? null : string.Join(",", types)
        }, cancellationToken);
    }
}