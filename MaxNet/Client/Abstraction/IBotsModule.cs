using MaxNet.Models.Bots;

namespace MaxNet.Client.Abstraction;

public interface IBotsModule : IModule
{
    Task<BotInfo> GetMeAsync(CancellationToken cancellationToken = default);

    Task<BotInfo> EditMeAsync(BotPatch patch, CancellationToken cancellationToken = default);
}