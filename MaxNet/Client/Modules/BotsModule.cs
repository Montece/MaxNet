using MaxNet.Client.Abstraction;
using MaxNet.Models.Bots;

namespace MaxNet.Client.Modules;

public sealed class BotsModule : IBotsModule
{
    public IMaxBotClient MaxBotClient { get; }

    public BotsModule(MaxBotClient maxBotClient)
    {
        MaxBotClient = maxBotClient;
    }

    public Task<BotInfo> GetMeAsync(CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<BotInfo>(HttpMethod.Get, "/me", null, null, cancellationToken);
    }

    public Task<BotInfo> EditMeAsync(BotPatch patch, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<BotInfo>(HttpMethod.Patch, "/me", patch, null, cancellationToken);
    }
}