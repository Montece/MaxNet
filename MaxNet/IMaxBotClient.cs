using MaxNet.Results;

namespace MaxNet;

public interface IMaxBotClient
{
    Task<MeResult> Me(CancellationToken cancellationToken = default);
}