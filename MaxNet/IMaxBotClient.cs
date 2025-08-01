using MaxNet.Models;

namespace MaxNet;

public interface IMaxBotClient
{
    Task<MeResult> Me(CancellationToken cancellationToken = default);
}