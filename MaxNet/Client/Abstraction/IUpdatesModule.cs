using MaxNet.Models.Updates;

namespace MaxNet.Client.Abstraction;

public interface IUpdatesModule : IModule
{
    Task<GetSubscriptionsResult> GetSubscriptionsAsync(CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> SubscribeAsync(SubscriptionRequestBody body, CancellationToken cancellationToken = default);

    Task<SimpleQueryResult> UnsubscribeAsync(string url, CancellationToken cancellationToken = default);

    Task<UpdateList> GetUpdatesAsync(int limit = 100, int timeoutSec = 30, long? marker = null, IEnumerable<string>? types = null, CancellationToken cancellationToken = default);
}