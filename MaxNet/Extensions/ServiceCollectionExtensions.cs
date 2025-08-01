using Microsoft.Extensions.DependencyInjection;

namespace MaxNet.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMaxBotClient(this IServiceCollection services)
    {
        services.AddHttpClient<IMaxBotClient, MaxBotClient>();

        return services;
    }
}