using MaxNet.Utility.Attributes;

namespace MaxNet.Client.Abstraction;

[PublicApi]
public interface IModule
{
    IMaxBotClient MaxBotClient { get; }
}