using MaxNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using MaxNet.Client.Abstraction;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();

services.AddLogging(c => c.AddConsole());

services.AddMaxMessenger(config.GetSection("MaxBotClient"));

var provider = services.BuildServiceProvider();

var logger = provider.GetRequiredService<ILogger<Program>>();
var client = provider.GetRequiredService<IMaxBotClient>();

try
{
    var result = await client.Bots.GetMeAsync();
    logger.LogInformation("Результат: {@Result}", result);
}
catch (Exception ex)
{
    logger.LogError(ex, "Ошибка при вызове API");
}