using asERP.Application.Contracts.Infrastructure;
using asERP.Application.Contracts.Persistence;
using asERP.Domain.Entities;
using asERP.Domain.Enums;
using asERP.SalesChannels.Logging;
using asERP.SalesChannels.Models;
using asERP.SalesChannels.Repositories;
using asERP.Server.Infrastructure.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using Xunit;

namespace asERP.Server.Tests.SalesChannels;

/// <summary>
/// How far the sync-log sink actually reaches, driven rather than reasoned about. Two reviewers
/// disagreed on whether a line logged by <see cref="ProductImageImportService"/> — a different logger
/// category from the one that opened the dispatcher's scope — is captured into the tenant-readable
/// <c>ChannelSyncLog</c> at all. It decides whether that call site is a disclosure or is unreachable,
/// so it is settled here against a real Serilog pipeline and a real MEL scope instead of by reading
/// call graphs.
/// </summary>
public class SyncLogSinkReachTests
{
    private static readonly Guid ChannelId = Guid.NewGuid();

    private sealed record Harness(SalesChannelSyncLogBuffer Buffer, SerilogLoggerFactory Factory, Serilog.Core.Logger Serilog);

    private static Harness NewHarness()
    {
        var buffer = new SalesChannelSyncLogBuffer();
        var serilog = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Sink(new SalesChannelSyncLogSink(buffer))
            .CreateLogger();
        return new Harness(buffer, new SerilogLoggerFactory(serilog), serilog);
    }

    /// <summary>The scope <c>SyncDispatcher.BeginSyncLogScope</c> opens, on the dispatcher's category.</summary>
    private static IDisposable? BeginDispatcherScope(ILoggerFactory factory) =>
        factory.CreateLogger("asERP.SalesChannels.Orchestration.SyncDispatcher")
            .BeginScope(new Dictionary<string, object>
            {
                ["SalesChannelId"] = ChannelId,
                ["SyncRunCorrelationId"] = Guid.NewGuid(),
                ["SyncOperation"] = ChannelSyncOperation.ImportProducts,
            });

    private static List<SyncLogRecord> Drain(SalesChannelSyncLogBuffer buffer)
    {
        var drained = new List<SyncLogRecord>();
        buffer.Drain(drained, 50);
        return drained;
    }

    /// <summary>
    /// The decisive one. A private literal is rejected by <c>SalesChannelUrlValidator</c> before any
    /// socket is opened, on the input-derived branch that deliberately keeps its own wording — so
    /// whether the line is captured depends purely on the scope reaching another logger category.
    /// </summary>
    [Fact]
    public async Task ImageRejection_LoggedUnderTheDispatchersScope_IsCapturedForTheTenant()
    {
        var harness = NewHarness();
        using var serilog = harness.Serilog;
        using var factory = harness.Factory;

        using (BeginDispatcherScope(factory))
        {
            var service = new ProductImageImportService(
                new EmptyImageRepository(),
                new UnusedImageStorage(),
                new UnusedHttpClientFactory(),
                factory.CreateLogger<ProductImageImportService>());

            await service.ImportImagesAsync(
                Guid.NewGuid(),
                ChannelId,
                [new SalesChannelImportImage { RemoteImageId = "img-1", Url = "https://10.0.0.7/photo.jpg", SortOrder = 0 }],
                CancellationToken.None);
        }

        var record = Assert.Single(Drain(harness.Buffer));
        Assert.Equal(ChannelId, record.SalesChannelId);
        Assert.Contains("Skipping image", record.Message, StringComparison.Ordinal);
    }

    /// <summary>
    /// The same line outside the scope carries no <c>SalesChannelId</c>, so the sink ignores it. This
    /// is the control: without it, the test above could pass for the wrong reason.
    /// </summary>
    [Fact]
    public async Task ImageRejection_LoggedOutsideAnySyncScope_IsNotCaptured()
    {
        var harness = NewHarness();
        using var serilog = harness.Serilog;
        using var factory = harness.Factory;

        var service = new ProductImageImportService(
            new EmptyImageRepository(),
            new UnusedImageStorage(),
            new UnusedHttpClientFactory(),
            factory.CreateLogger<ProductImageImportService>());

        await service.ImportImagesAsync(
            Guid.NewGuid(),
            ChannelId,
            [new SalesChannelImportImage { RemoteImageId = "img-1", Url = "https://10.0.0.7/photo.jpg", SortOrder = 0 }],
            CancellationToken.None);

        Assert.Empty(Drain(harness.Buffer));
    }

    /// <summary>
    /// And the payoff: a rejection that depends on resolving the name is marked as a transport
    /// failure, so the sink drops the whole line even though it is inside the scope. One line per
    /// image is what would otherwise make this a bulk probe of the server's resolver.
    /// </summary>
    [Fact]
    public async Task ImageRejectionThatDependedOnResolving_IsWithheldFromTheTenant()
    {
        var harness = NewHarness();
        using var serilog = harness.Serilog;
        using var factory = harness.Factory;

        using (BeginDispatcherScope(factory))
        {
            var service = new ProductImageImportService(
                new EmptyImageRepository(),
                new UnusedImageStorage(),
                new UnusedHttpClientFactory(),
                factory.CreateLogger<ProductImageImportService>());

            await service.ImportImagesAsync(
                Guid.NewGuid(),
                ChannelId,
                // ".invalid" is reserved by RFC 2606 and never resolves, so the rejection comes from
                // the resolution branch without the test depending on a particular resolver's view.
                [new SalesChannelImportImage { RemoteImageId = "img-1", Url = "https://nx.invalid/photo.jpg", SortOrder = 0 }],
                CancellationToken.None);
        }

        Assert.Empty(Drain(harness.Buffer));
    }

    // --- stubs -------------------------------------------------------------------------------------

    private sealed class EmptyImageRepository : IProductImageRepository
    {
        public Task<List<ProductImage>> GetByProductIdAsync(Guid productId) => Task.FromResult(new List<ProductImage>());
        public Task<int> GetMaxSortOrderAsync(Guid productId) => Task.FromResult(-1);
        public IQueryable<ProductImage> Entities => throw new NotSupportedException();
        public IQueryable<TCt> GetContext<TCt>() where TCt : class => throw new NotSupportedException();
        public void Attach(ProductImage entity) => throw new NotSupportedException();
        public void AttachRange(IEnumerable<ProductImage> entities) => throw new NotSupportedException();
        public Task<Guid> CreateAsync(ProductImage entity) => throw new NotSupportedException();
        public Task<ICollection<ProductImage>> GetAllAsync() => throw new NotSupportedException();
        public Task<ProductImage?> GetByIdAsync(Guid id, bool asNoTracking = false) => throw new NotSupportedException();
        public Task UpdateAsync(ProductImage entity) => throw new NotSupportedException();
        public Task DeleteAsync(ProductImage entity) => throw new NotSupportedException();
        public Task<bool> ExistsAsync(Guid id) => throw new NotSupportedException();
        public Task<bool> ExistsGloballyAsync(Guid id) => throw new NotSupportedException();
        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public Task SaveChangesAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        public void Add(ProductImage entity) => throw new NotSupportedException();
    }

    private sealed class UnusedImageStorage : IProductImageStorage
    {
        public Task<StoredImage> SaveAsync(Stream content, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public Task<Stream?> OpenReadAsync(string relativePath, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public Task DeleteAsync(string relativePath, string? thumbnailPath, CancellationToken cancellationToken = default) => throw new NotSupportedException();
        public Task<ReencodedFile?> ReencodeAsync(string relativePath, CancellationToken cancellationToken = default) => throw new NotSupportedException();
    }

    /// <summary>No image is ever downloaded in these tests — the URL is rejected before the client is used.</summary>
    private sealed class UnusedHttpClientFactory : IHttpClientFactory
    {
        public HttpClient CreateClient(string name) => new();
    }
}
