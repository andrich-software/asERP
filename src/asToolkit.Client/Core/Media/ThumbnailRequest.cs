namespace asToolkit.Client.Core.Media;

/// <summary>
/// Identifies a product image thumbnail to load lazily per realized list container
/// (see <see cref="ThumbnailLoader"/>). Record equality lets the loader detect
/// container recycling with a changed target.
/// </summary>
public sealed record ThumbnailRequest(Guid ProductId, Guid ImageId);
