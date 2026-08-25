using asERP.Application.Mediator;

namespace asERP.Application.Notifications;

/// <summary>
/// Raised when a product's category assignments change (ProductCategory rows added/removed).
/// Handlers push the assignment set to channels supporting partial category updates.
/// </summary>
public sealed record ProductCategoriesChangedNotification(
    Guid ProductId,
    Guid? TenantId) : INotification;
