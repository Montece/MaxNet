using MaxNet.Client;
using MaxNet.Options;
using MaxNet.Utility;
using MaxNet.Utility.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MaxNet;

[PublicApi]
public static class MaxBotServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация через делегат конфигурации
    /// </summary>
    public static IServiceCollection AddMaxMessenger(this IServiceCollection services, Action<MaxBotClientOptions> configure)
    {
        Guard.NotNull(nameof(services), services);
        Guard.NotNull(nameof(configure), configure);

        var maxBotClientOptions = new MaxBotClientOptions(string.Empty);

        configure(maxBotClientOptions);

        services.AddSingleton<MaxBotClient>(_ => new(new(), maxBotClientOptions));
        
        return services;
    }

    /// <summary>
    /// Регистрация через IConfiguration-секцию
    /// </summary>
    public static IServiceCollection AddMaxMessenger(this IServiceCollection services, IConfiguration configurationSection)
    {
        Guard.NotNull(nameof(services), services);
        Guard.NotNull(nameof(configurationSection), configurationSection);

        var maxBotClientOptions = configurationSection.Get<MaxBotClientOptions>() ?? throw new InvalidOperationException("MaxMessenger options are not configured");
        
        services.AddSingleton<MaxBotClient>(_ => new(new(), maxBotClientOptions));
        
        return services;
    }

    /// <summary>
    /// Регистрация через прямые параметры
    /// </summary>
    public static IServiceCollection AddMaxMessenger(this IServiceCollection services, string apiToken)
    {
        Guard.NotNull(nameof(services), services);
        Guard.NotNullOrEmpty(nameof(apiToken), apiToken);

        var maxBotClientOptions = new MaxBotClientOptions(apiToken);

        services.AddSingleton<MaxBotClient>(_ => new(new(), maxBotClientOptions));

        return services;
    }
}