using MaxNet;
using MaxNet.Extensions;
using MaxNet.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

var services = new ServiceCollection();

services.AddLogging(c => c.AddConsole());

services.Configure<MaxBotClientOptions>(config.GetSection("MaxBotClient"));

services.AddMaxBotClient();

var provider = services.BuildServiceProvider();

var logger = provider.GetRequiredService<ILogger<Program>>();
var client = provider.GetRequiredService<IMaxBotClient>();

try
{
    var result = await client.Me();
    logger.LogInformation("Результат: {@Result}", result);
}
catch (Exception ex)
{
    logger.LogError(ex, "Ошибка при вызове API");
}