using System.Linq.Expressions;
using asERP.Domain.Entities;
using asERP.Domain.Enums;

namespace asERP.Application.Features.Shipping.Shared;

/// <summary>
/// Shared definition of a problem shipment, used by the shipping list and the dashboard
/// to-do count so both agree on what counts as a problem.
/// </summary>
public static class ShippingProblemFilter
{
    /// <summary>A shipped, undelivered parcel older than this is flagged as a problem.</summary>
    public static readonly TimeSpan OverdueAfter = TimeSpan.FromDays(3);

    /// <summary>
    /// Problem predicate over shipments. Keep in sync with the inline IsProblem projection in
    /// ShippingListHandler, which cannot reuse this expression inside its Select.
    /// </summary>
    public static Expression<Func<Domain.Entities.Shipping, bool>> IsProblem(
        IQueryable<ShippingLabelOutbox> labelOutbox, DateTime overdueCutoff) =>
        s => s.Status == ShippingStatus.Lost
             || s.Status == ShippingStatus.ReturnedToSender
             || s.Status == ShippingStatus.DeliveryFailed
             || (s.ShippedAt != null && s.Status != ShippingStatus.Delivered && s.ShippedAt < overdueCutoff)
             || labelOutbox.Any(o => o.ShippingId == s.Id && o.Status == ShippingOutboxStatus.DeadLetter);
}
