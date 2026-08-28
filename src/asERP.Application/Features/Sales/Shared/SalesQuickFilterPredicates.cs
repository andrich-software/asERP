using System.Linq.Expressions;
using asERP.Domain.Enums;

namespace asERP.Application.Features.Sales.Shared;

/// <summary>
/// EF-translatable predicates behind the sales quick filters, shared by the list handlers
/// and the dashboard to-do counts so every view agrees on what it shows.
/// </summary>
public static class SalesQuickFilterPredicates
{
    /// <summary>A still-unpaid sale ordered longer ago than this needs attention.</summary>
    public static readonly TimeSpan PaymentOverdueAfter = TimeSpan.FromDays(7);

    public static readonly SalesStatus[] ReadyToShipStatuses =
    {
        SalesStatus.Pending,
        SalesStatus.Processing,
        SalesStatus.ReadyForDelivery,
        SalesStatus.PartiallyDelivered
    };

    public static readonly SalesStatus[] NotPaidRelevantStatuses =
    {
        SalesStatus.Pending,
        SalesStatus.Processing,
        SalesStatus.ReadyForDelivery,
        SalesStatus.OnHold
    };

    public static readonly PaymentStatus[] NotPaidStatuses =
    {
        PaymentStatus.Unknown,
        PaymentStatus.Invoiced,
        PaymentStatus.PartiallyPaid,
        PaymentStatus.FirstReminder,
        PaymentStatus.SecondReminder,
        PaymentStatus.ThirdReminder,
        PaymentStatus.Encashment,
        PaymentStatus.Reserved,
        PaymentStatus.Delayed,
        PaymentStatus.ReviewNecessary,
        PaymentStatus.NoCreditApproved,
        PaymentStatus.CreditPreliminarilyAccepted
    };

    /// <summary>Fully paid, shippable sales with at least one unshipped item.</summary>
    public static Expression<Func<Domain.Entities.Sales, bool>> ReadyToShip() =>
        o => ReadyToShipStatuses.Contains(o.Status)
             && o.SalesItems.Any(i => i.ShippingId == null)
             && o.PaymentStatus == PaymentStatus.CompletelyPaid;

    /// <summary>Still shippable sales without a completed payment.</summary>
    public static Expression<Func<Domain.Entities.Sales, bool>> NotPaid() =>
        o => NotPaidStatuses.Contains(o.PaymentStatus)
             && NotPaidRelevantStatuses.Contains(o.Status);

    /// <summary>Still shippable, unpaid sales ordered before <paramref name="cutoff"/>.</summary>
    public static Expression<Func<Domain.Entities.Sales, bool>> PaymentOverdue(DateTime cutoff) =>
        o => NotPaidStatuses.Contains(o.PaymentStatus)
             && NotPaidRelevantStatuses.Contains(o.Status)
             && o.DateSalesed < cutoff;
}
