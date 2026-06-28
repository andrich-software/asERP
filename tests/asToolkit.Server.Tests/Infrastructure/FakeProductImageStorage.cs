using System.Collections.Concurrent;
using System.IO;
using asToolkit.Application.Contracts.Infrastructure;

namespace asToolkit.Server.Tests.Infrastructure;

/// <summary>
/// In-memory <see cref="IProductImageStorage"/> for integration tests: no disk writes and no
/// real image decoding (any bytes are accepted), so tests can use tiny placeholder payloads.
/// Registered as a singleton so stored bytes survive across request scopes.
/// </summary>
public class FakeProductImageStorage : IProductImageStorage
{
    private readonly ConcurrentDictionary<string, byte[]> _files = new();

    public Task<StoredImage> SaveAsync(Stream content, CancellationToken cancellationToken = default)
    {
        using var ms = new MemoryStream();
        content.CopyTo(ms);
        var bytes = ms.ToArray();

        var guid = Guid.NewGuid().ToString("N");
        var shard = guid[..2];
        var relativePath = $"products/{shard}/{guid}.png";
        var thumbnailPath = $"products/{shard}/{guid}_thumb.png";

        _files[relativePath] = bytes;
        _files[thumbnailPath] = bytes;

        return Task.FromResult(new StoredImage($"{guid}.png", relativePath, thumbnailPath, 100, 80, bytes.Length));
    }

    public Task<Stream?> OpenReadAsync(string relativePath, CancellationToken cancellationToken = default)
        => Task.FromResult<Stream?>(_files.TryGetValue(relativePath, out var bytes) ? new MemoryStream(bytes) : null);

    public Task DeleteAsync(string relativePath, string? thumbnailPath, CancellationToken cancellationToken = default)
    {
        _files.TryRemove(relativePath, out _);
        if (!string.IsNullOrEmpty(thumbnailPath))
        {
            _files.TryRemove(thumbnailPath, out _);
        }

        return Task.CompletedTask;
    }

    /// <summary>Test helper: number of stored files (originals + thumbnails).</summary>
    public int FileCount => _files.Count;

    /// <summary>Test helper: whether a relative path currently exists in the store.</summary>
    public bool Exists(string relativePath) => _files.ContainsKey(relativePath);
}
