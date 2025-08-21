using MaxNet.Enums.Uploads;
using MaxNet.Models.Uploads;

namespace MaxNet.Client.Abstraction;

public interface IUploadsModule : IModule
{
    Task<UploadEndpoint> GetUploadUrlAsync(UploadType type, CancellationToken cancellationToken = default);
}