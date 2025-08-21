using MaxNet.Client.Abstraction;
using MaxNet.Enums.Uploads;
using MaxNet.Models.Uploads;

namespace MaxNet.Client.Modules;

public sealed class UploadsModule : IUploadsModule
{
    public IMaxBotClient MaxBotClient { get; }

    public UploadsModule(MaxBotClient maxBotClient)
    {
        MaxBotClient = maxBotClient;
    }

    public Task<UploadEndpoint> GetUploadUrlAsync(UploadType type, CancellationToken cancellationToken = default)
    {
        return MaxBotClient.SendAsync<UploadEndpoint>(HttpMethod.Post, "/uploads", null, new Dictionary<string, string?>
        {
            ["type"] = type.ToString().ToLowerInvariant()
        }, cancellationToken);
    }
}