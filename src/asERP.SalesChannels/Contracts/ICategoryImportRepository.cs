using asERP.SalesChannels.Abstractions;
using asERP.SalesChannels.Models;

namespace asERP.SalesChannels.Contracts;

public interface ICategoryImportRepository
{
    /// <summary>
    /// Reconciles the channel's complete remote category tree into local categories and channel
    /// links. Connectors collect the full remote set first (category counts are small) and hand it
    /// in as one sweep so orphaned links can be detected safely.
    /// </summary>
    Task<SyncResult> ImportOrUpdateFromSalesChannel(
        Guid salesChannelId,
        IReadOnlyList<SalesChannelImportCategory> remoteCategories,
        CancellationToken cancellationToken);
}
