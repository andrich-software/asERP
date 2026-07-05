using System.Text;
using asERP.Domain.Enums;

namespace asERP.Client.Presentation;

/// <summary>
/// Central registry mapping status values to their localized display text and a semantic color kind.
/// Consumed by the <c>StatusBadge</c> control; each <see cref="Kind"/> maps to a
/// <c>Status{Kind}BackgroundBrush</c> / <c>Status{Kind}ForegroundBrush</c> pair defined in
/// <c>Styles/StatusColors.xaml</c> (theme-aware, Light + Dark).
/// </summary>
public static class StatusVisuals
{
    public enum Kind
    {
        Neutral,
        Info,
        Success,
        Positive,
        Warning,
        Caution,
        Danger,
        Special,
    }

    public static (string Text, Kind Kind) Resolve(object? status) => status switch
    {
        SalesStatus s => (LocalizeEnum(s), s switch
        {
            SalesStatus.Completed => Kind.Success,
            SalesStatus.ReadyForDelivery => Kind.Positive,
            SalesStatus.Processing => Kind.Info,
            SalesStatus.Pending => Kind.Warning,
            SalesStatus.PartiallyDelivered => Kind.Warning,
            SalesStatus.OnHold => Kind.Caution,
            SalesStatus.Returned => Kind.Caution,
            SalesStatus.Failed => Kind.Danger,
            SalesStatus.Refunded => Kind.Special,
            _ => Kind.Neutral,
        }),
        PaymentStatus p => (LocalizeEnum(p), p switch
        {
            PaymentStatus.CompletelyPaid => Kind.Success,
            PaymentStatus.Invoiced => Kind.Info,
            PaymentStatus.Reserved => Kind.Info,
            PaymentStatus.PartiallyPaid => Kind.Warning,
            PaymentStatus.FirstReminder => Kind.Warning,
            PaymentStatus.SecondReminder => Kind.Caution,
            PaymentStatus.ThirdReminder => Kind.Caution,
            PaymentStatus.Delayed => Kind.Caution,
            PaymentStatus.Encashment => Kind.Danger,
            PaymentStatus.NoCreditApproved => Kind.Danger,
            PaymentStatus.ReviewNecessary => Kind.Danger,
            PaymentStatus.ReCrediting => Kind.Special,
            _ => Kind.Neutral,
        }),
        InvoiceStatus i => (LocalizeEnum(i), i switch
        {
            InvoiceStatus.Paid => Kind.Success,
            InvoiceStatus.Sent => Kind.Info,
            InvoiceStatus.PartiallyPaid => Kind.Warning,
            InvoiceStatus.Overdue => Kind.Caution,
            InvoiceStatus.Disputed => Kind.Danger,
            InvoiceStatus.Refunded => Kind.Special,
            _ => Kind.Neutral,
        }),
        CustomerStatus c => (LocalizeEnum(c), c switch
        {
            CustomerStatus.Active => Kind.Success,
            CustomerStatus.NoDoi => Kind.Warning,
            _ => Kind.Neutral,
        }),
        ShippingStatus sh => (LocalizeEnum(sh), sh switch
        {
            ShippingStatus.Delivered => Kind.Success,
            ShippingStatus.ReadyForShipping => Kind.Positive,
            ShippingStatus.LabelCreated => Kind.Positive,
            ShippingStatus.Shipped => Kind.Info,
            ShippingStatus.InTransit => Kind.Info,
            ShippingStatus.OutForDelivery => Kind.Info,
            ShippingStatus.InProgess => Kind.Warning,
            ShippingStatus.DeliveryFailed => Kind.Danger,
            ShippingStatus.ReturnedToSender => Kind.Danger,
            ShippingStatus.Lost => Kind.Danger,
            _ => Kind.Neutral, // Open, Cancelled
        }),
        ReturnShipmentStatus r => (LocalizeEnum(r), r switch
        {
            ReturnShipmentStatus.Completed => Kind.Success,
            ReturnShipmentStatus.Received => Kind.Positive,
            ReturnShipmentStatus.LabelCreated => Kind.Info,
            ReturnShipmentStatus.InTransit => Kind.Info,
            ReturnShipmentStatus.Requested => Kind.Warning,
            ReturnShipmentStatus.Rejected => Kind.Danger,
            _ => Kind.Neutral, // Cancelled
        }),
        ShippingOutboxStatus o => (LocalizeEnum(o), o switch
        {
            ShippingOutboxStatus.Done => Kind.Success,
            ShippingOutboxStatus.Pending => Kind.Warning,
            ShippingOutboxStatus.InFlight => Kind.Warning,
            ShippingOutboxStatus.DeadLetter => Kind.Danger,
            _ => Kind.Neutral,
        }),
        bool syncEnabled => syncEnabled
            ? (LocalizationHelper.GetLocalizedString("SyncStatus.Enabled", "Enabled"), Kind.Success)
            : (LocalizationHelper.GetLocalizedString("SyncStatus.Disabled", "Disabled"), Kind.Neutral),
        null => (string.Empty, Kind.Neutral),
        _ => (status.ToString() ?? string.Empty, Kind.Neutral),
    };

    private static string LocalizeEnum<TEnum>(TEnum value) where TEnum : struct, Enum
    {
        var key = $"{typeof(TEnum).Name}.{value}";
        return LocalizationHelper.GetLocalizedString(key, Humanize(value.ToString()));
    }

    /// <summary>Fallback when no resource exists: splits PascalCase into words ("ReadyForDelivery" → "Ready For Delivery").</summary>
    private static string Humanize(string pascalCase)
    {
        var builder = new StringBuilder(pascalCase.Length + 4);
        foreach (var c in pascalCase)
        {
            if (char.IsUpper(c) && builder.Length > 0)
            {
                builder.Append(' ');
            }
            builder.Append(c);
        }
        return builder.ToString();
    }
}
