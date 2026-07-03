using System.Collections.Concurrent;
using asToolkit.Client.Features.Products.Services;

namespace asToolkit.Client.Core.Media;

/// <summary>
/// <see cref="IThumbnailCache"/> backed by <see cref="IProductService"/> with a simple
/// FIFO cap so long sessions across many product pages cannot grow memory unbounded.
/// </summary>
public sealed class ProductThumbnailCache(IProductService productService) : IThumbnailCache
{
    private const int MaxEntries = 500;

    private readonly ConcurrentDictionary<Guid, byte[]> _cache = new();
    private readonly ConcurrentQueue<Guid> _insertions = new();

    public async ValueTask<byte[]?> GetOrLoadAsync(ThumbnailRequest request, CancellationToken ct = default)
    {
        if (_cache.TryGetValue(request.ImageId, out var cached))
        {
            return cached;
        }

        var bytes = await productService.GetProductImageBytesAsync(
            request.ProductId, request.ImageId, thumbnail: true, ct);

        if (bytes is { Length: > 0 } && _cache.TryAdd(request.ImageId, bytes))
        {
            _insertions.Enqueue(request.ImageId);
            TrimIfNeeded();
        }

        return bytes;
    }

    private void TrimIfNeeded()
    {
        while (_cache.Count > MaxEntries && _insertions.TryDequeue(out var oldest))
        {
            _cache.TryRemove(oldest, out _);
        }
    }
}
